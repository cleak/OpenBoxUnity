using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using LiteBox.LMath;

namespace OpenBox {
    public class MagicaFile {
        public struct Chunk {
            public string chunkId;
            public int numBytes;
            public int numChildBytes;
            public byte[] bytes;

            public BinaryReader OpenReader() {
                return new BinaryReader(new MemoryStream(bytes));
            }

            public override string ToString() {
                return string.Format("{0} <{1}> <{2}>", chunkId, numBytes, numChildBytes);
            }
        }

        public enum MaterialType : int {
            Diffuse = 0,
            Metal = 1,
            Glass = 2,
            Emissive = 3
        }

        public struct Material {
            public MaterialType materialType;

            public float diffuse;
            public float metal;
            public float glass;
            public float emissive;

            // TODO: Additional properties here

            public float GetAlpha() {
                if (materialType != MaterialType.Glass) {
                    return 1.0f;
                }

                return 1.0f - glass;
            }
        }

        BinaryReader fileReader;
        VoxelSet<Vec4b>[] models;
        Vec4b[] palette;
        Dictionary<int, Material> materials;

        // Index to the current model being manipulated.
        int modelIdx;

        MagicaFile(string filename) {
            fileReader = new BinaryReader(File.OpenRead(filename));
            palette = new Vec4b[256];
            materials = new Dictionary<int, Material>();

            // Setup default palette
            for (int i = 0; i < defaultColorsRaw.Length; ++i) {
                palette[i] = ParseRawColor(defaultColorsRaw[i]);
            }

            // Read header
            string header = BytesToString(fileReader.ReadBytes(4));
            if (header != kHeader) {
                throw new Exception("Bad header magic");
            }

            int version = fileReader.ReadInt32();
            if (version != kVersion) {
                throw new Exception("Bad header version");
            }

            // Read main chunk
            Chunk mainChunk = ReadChunk();
            if (mainChunk.chunkId != kChunkMain) {
                throw new Exception("Bad main chunk ID");
            }

            // (Optional) Read pack chunk
            int numModels = 1;
            if (fileReader.PeekChar() == 'P') {
                Chunk packChunk = ReadChunk();
                if (packChunk.chunkId != kChunkPack) {
                    throw new Exception("Bad pack chunk");
                }

                numModels = packChunk.OpenReader().ReadInt32();
            }

            models = new VoxelSet<Vec4b>[numModels];
            modelIdx = 0;

            // Read all remaining chunks
            while (fileReader.PeekChar() >= 0) {
                Chunk chunk = ReadChunk();

                switch (chunk.chunkId) {
                    case kChunkSize:
                        models[modelIdx] = LoadModelChunk(chunk, ReadChunk());
                        modelIdx++;
                        break;

                    case kChunkRgba:
                        LoadPaletteChunk(chunk);
                        break;

                    case kChunkMatt:
                        LoadOldMaterial(chunk);
                        break;

                    case kChunkMatl:
                        LoadNewMaterial(chunk);
                        break;

                    default:
                        Console.WriteLine("Warning: Unknown chunk {0}", chunk);
                        break;
                }
            }
        }

        // Bake all materials onto the loaded voxel sets.
        void BakeMaterials() {
            // Populate colors
            foreach (var m in models) {
                m.Apply((ref Vec4b val) => {
                    var c = palette[val.x];

                    if (materials.ContainsKey(val.x)) {
                        var mat = materials[val.x];
                        c.w = (byte)Math.Round(mat.GetAlpha() * 255.0f);
                    }

                    val = c;
                });
            }
        }

        // Loads a string prefixed by its length.
        string ReadPrefixString(BinaryReader br) {
            int len = br.ReadInt32();
            return BytesToString(br.ReadBytes(len));
        }

        Vec4b ParseRawColor(uint rawColor) {
            Vec4b color = new Vec4b();
            for (int j = 0; j < 4; ++j) {
                color[j] = (byte)((rawColor >> (j * 8)) & 0xff);
            }

            return color;
        }

        // Loads the given model into a voxel set and returns it.
        VoxelSet<Vec4b> LoadModelChunk(Chunk sizeChunk, Chunk idxChunk) {
            if (sizeChunk.chunkId != kChunkSize) {
                throw new Exception("Bad size chunk");
            }

            if (idxChunk.chunkId != kChunkXyzi) {
                throw new Exception("Bad index chunk");
            }

            BinaryReader sizeReader = sizeChunk.OpenReader();
            BinaryReader idxReader = idxChunk.OpenReader();

            // TODO: This seems to load models rotated 180 degrees
            Vec3i size = new Vec3i();
            size.x = sizeReader.ReadInt32();
            size.z = sizeReader.ReadInt32();
            size.y = sizeReader.ReadInt32();
            VoxelSet<Vec4b> model = new VoxelSet<Vec4b>(size);

            // Read individual voxels
            int numVoxels = idxReader.ReadInt32();
            for (int j = 0; j < numVoxels; ++j) {
                //Vec3i idx = new Vec3i(br.ReadByte(), br.ReadByte(), br.ReadByte());
                Vec3i idx = new Vec3i(0);
                idx.x = idxReader.ReadByte();
                idx.z = idxReader.ReadByte();
                idx.y = idxReader.ReadByte();

                // For now just store the index into the palette
                model[idx] = new Vec4b(idxReader.ReadByte());
            }

            return model;
        }

        // Replaces the current palette with palette in the given chunk.
        void LoadPaletteChunk(Chunk palChunk) {
            if (palChunk.chunkId != kChunkRgba) {
                throw new Exception("Bad palette chunk");
            }

            var br = palChunk.OpenReader();

            for (int i = 0; i < 255; ++i) {
                for (int j = 0; j < 4; ++j) {
                    palette[i + 1][j] = br.ReadByte();
                }
            }

            // Discard unused color
            br.ReadInt32();
        }

        // Loads a material using the old material format.
        void LoadOldMaterial(Chunk matChunk) {
            var br = matChunk.OpenReader();
            if (matChunk.chunkId != kChunkMatt) {
                throw new Exception("Bad material chunk");
            }

            Material m = new Material();
            int id = br.ReadInt32();
            m.materialType = (MaterialType)br.ReadInt32();

            float weight = br.ReadSingle();
            int propertyBits = br.ReadInt32();
            int propValueCount = CountBits(propertyBits & 0x7);

            switch (m.materialType) {
                case MaterialType.Diffuse:
                    m.diffuse = weight;
                    break;

                case MaterialType.Emissive:
                    m.emissive = weight;
                    break;

                case MaterialType.Glass:
                    m.glass = weight;
                    break;

                case MaterialType.Metal:
                    m.metal = weight;
                    break;
            }

            // Skip property values
            for (int i = 0; i < propValueCount; ++i) {
                // Ignore property value
                br.ReadSingle();
            }

            materials[id] = m;
        }

        // Loads a material using the new material format.
        void LoadNewMaterial(Chunk matChunk) {
            var br = matChunk.OpenReader();
            int id = br.ReadInt32();
            int unknown = br.ReadInt32();

            string type = "";
            Dictionary<string, float> props = new Dictionary<string, float>();
            while (br.PeekChar() >= 0) {
                string propName = ReadPrefixString(br);
                string valueStr = ReadPrefixString(br);

                if (propName == "_type") {
                    type = valueStr;
                    continue;
                }

                float value = float.Parse(valueStr);

                props[propName] = value;
            }

            if (type == "_glass") {
                Material m = new Material();
                m.glass = props["_weight"];
                m.materialType = MaterialType.Glass;
                materials[id] = m;
            }
        }

        // Convert the given byte array to its string form.
        static string BytesToString(byte[] bytes) {
            return System.Text.Encoding.Default.GetString(bytes);
        }

        // Read the next chunk and return it.
        Chunk ReadChunk() {
            Chunk chunk = new Chunk();
            chunk.chunkId = BytesToString(fileReader.ReadBytes(4));
            chunk.numBytes = fileReader.ReadInt32();
            chunk.numChildBytes = fileReader.ReadInt32();
            chunk.bytes = fileReader.ReadBytes(chunk.numBytes);

            return chunk;
        }

        static int CountBits(int bits) {
            int total = 0;
            while(bits > 0) {
                total += (bits & 1);
                bits >>= 1;
            }

            return total;
        }

        public static VoxelSet<Vec4b>[] Load(string filename) {
            MagicaFile mf = new MagicaFile(filename);
            mf.BakeMaterials();
            return mf.models;
        }

        // Known chunk headers
        public const string kHeader = "VOX ";
        public const string kChunkMain = "MAIN";
        public const string kChunkPack = "PACK";
        public const string kChunkSize = "SIZE";
        public const string kChunkXyzi = "XYZI";
        public const string kChunkRgba = "RGBA";
        public const string kChunkMatt = "MATT";
        public const string kChunkMatl = "MATL"; // New material format from 0.99 onwards

        public const int kVersion = 150;

        // Default palette
        static uint[] defaultColorsRaw = {
            0x00000000, 0xffffffff, 0xffccffff, 0xff99ffff, 0xff66ffff, 0xff33ffff, 0xff00ffff, 0xffffccff, 0xffccccff, 0xff99ccff, 0xff66ccff, 0xff33ccff, 0xff00ccff, 0xffff99ff, 0xffcc99ff, 0xff9999ff,
            0xff6699ff, 0xff3399ff, 0xff0099ff, 0xffff66ff, 0xffcc66ff, 0xff9966ff, 0xff6666ff, 0xff3366ff, 0xff0066ff, 0xffff33ff, 0xffcc33ff, 0xff9933ff, 0xff6633ff, 0xff3333ff, 0xff0033ff, 0xffff00ff,
            0xffcc00ff, 0xff9900ff, 0xff6600ff, 0xff3300ff, 0xff0000ff, 0xffffffcc, 0xffccffcc, 0xff99ffcc, 0xff66ffcc, 0xff33ffcc, 0xff00ffcc, 0xffffcccc, 0xffcccccc, 0xff99cccc, 0xff66cccc, 0xff33cccc,
            0xff00cccc, 0xffff99cc, 0xffcc99cc, 0xff9999cc, 0xff6699cc, 0xff3399cc, 0xff0099cc, 0xffff66cc, 0xffcc66cc, 0xff9966cc, 0xff6666cc, 0xff3366cc, 0xff0066cc, 0xffff33cc, 0xffcc33cc, 0xff9933cc,
            0xff6633cc, 0xff3333cc, 0xff0033cc, 0xffff00cc, 0xffcc00cc, 0xff9900cc, 0xff6600cc, 0xff3300cc, 0xff0000cc, 0xffffff99, 0xffccff99, 0xff99ff99, 0xff66ff99, 0xff33ff99, 0xff00ff99, 0xffffcc99,
            0xffcccc99, 0xff99cc99, 0xff66cc99, 0xff33cc99, 0xff00cc99, 0xffff9999, 0xffcc9999, 0xff999999, 0xff669999, 0xff339999, 0xff009999, 0xffff6699, 0xffcc6699, 0xff996699, 0xff666699, 0xff336699,
            0xff006699, 0xffff3399, 0xffcc3399, 0xff993399, 0xff663399, 0xff333399, 0xff003399, 0xffff0099, 0xffcc0099, 0xff990099, 0xff660099, 0xff330099, 0xff000099, 0xffffff66, 0xffccff66, 0xff99ff66,
            0xff66ff66, 0xff33ff66, 0xff00ff66, 0xffffcc66, 0xffcccc66, 0xff99cc66, 0xff66cc66, 0xff33cc66, 0xff00cc66, 0xffff9966, 0xffcc9966, 0xff999966, 0xff669966, 0xff339966, 0xff009966, 0xffff6666,
            0xffcc6666, 0xff996666, 0xff666666, 0xff336666, 0xff006666, 0xffff3366, 0xffcc3366, 0xff993366, 0xff663366, 0xff333366, 0xff003366, 0xffff0066, 0xffcc0066, 0xff990066, 0xff660066, 0xff330066,
            0xff000066, 0xffffff33, 0xffccff33, 0xff99ff33, 0xff66ff33, 0xff33ff33, 0xff00ff33, 0xffffcc33, 0xffcccc33, 0xff99cc33, 0xff66cc33, 0xff33cc33, 0xff00cc33, 0xffff9933, 0xffcc9933, 0xff999933,
            0xff669933, 0xff339933, 0xff009933, 0xffff6633, 0xffcc6633, 0xff996633, 0xff666633, 0xff336633, 0xff006633, 0xffff3333, 0xffcc3333, 0xff993333, 0xff663333, 0xff333333, 0xff003333, 0xffff0033,
            0xffcc0033, 0xff990033, 0xff660033, 0xff330033, 0xff000033, 0xffffff00, 0xffccff00, 0xff99ff00, 0xff66ff00, 0xff33ff00, 0xff00ff00, 0xffffcc00, 0xffcccc00, 0xff99cc00, 0xff66cc00, 0xff33cc00,
            0xff00cc00, 0xffff9900, 0xffcc9900, 0xff999900, 0xff669900, 0xff339900, 0xff009900, 0xffff6600, 0xffcc6600, 0xff996600, 0xff666600, 0xff336600, 0xff006600, 0xffff3300, 0xffcc3300, 0xff993300,
            0xff663300, 0xff333300, 0xff003300, 0xffff0000, 0xffcc0000, 0xff990000, 0xff660000, 0xff330000, 0xff0000ee, 0xff0000dd, 0xff0000bb, 0xff0000aa, 0xff000088, 0xff000077, 0xff000055, 0xff000044,
            0xff000022, 0xff000011, 0xff00ee00, 0xff00dd00, 0xff00bb00, 0xff00aa00, 0xff008800, 0xff007700, 0xff005500, 0xff004400, 0xff002200, 0xff001100, 0xffee0000, 0xffdd0000, 0xffbb0000, 0xffaa0000,
            0xff880000, 0xff770000, 0xff550000, 0xff440000, 0xff220000, 0xff110000, 0xffeeeeee, 0xffdddddd, 0xffbbbbbb, 0xffaaaaaa, 0xff888888, 0xff777777, 0xff555555, 0xff444444, 0xff222222, 0xff111111
        };
    }
}
