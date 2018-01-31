using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiteBox.LMath;

namespace OpenBox {
    public struct Bin : IComparable<Bin> {
        public Vec2i Size { get; set; }
        public Vec2i Position { get; set; }
        public Object UserData { get; set; }

        public int CompareTo(Bin other) {
            // Descending by height
            return other.Size.y.CompareTo(Size.y);
        }
    }

    public class BinPacker {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Shelf> Shelves { get; private set; }

        public Vec2i BinPadding { get; set; }

        public class Shelf {
            public Shelf() {
                Bins = new List<Bin>();
            }

            public int RemainingWidth { get; set; }
            public int Height { get; set; }
            public List<Bin> Bins { get; set; }
            public int YOffset { get; set; }
        }

        public IEnumerable<Bin> Bins
        { 
            get {
                foreach (var shelf in Shelves) {
                    foreach (var bin in shelf.Bins) {
                        yield return bin;
                    }
                }
            }
        }

        public BinPacker(int width) {
            Width = width;
            Shelves = new List<Shelf>();
        }

        public void Pack(List<Bin> bins) {
            Bin[] binArray = bins.ToArray();
            Array.Sort(binArray);

            foreach (var bin in binArray) {
                Pack(bin);
            }
        }

        public void Pack(Bin bin) {
            Shelf shelf = null;

            int y = 0;
            foreach (var s in Shelves) {
                if (s.RemainingWidth >= bin.Size.x && s.Height >= bin.Size.y) {
                    shelf = s;
                    break;
                }
                y += s.Height + BinPadding.y;
            }

            if (shelf == null) {
                // Didn't fit on any shelves; add a new one
                shelf = new Shelf();
                shelf.RemainingWidth = Width;
                shelf.Height = bin.Size.y;
                shelf.YOffset = y;
                Shelves.Insert(0, shelf);
                Height += bin.Size.y;
            }

            bin.Position = new Vec2i(Width - shelf.RemainingWidth, shelf.YOffset);

            shelf.Bins.Add(bin);
            shelf.RemainingWidth -= bin.Size.x + BinPadding.x;
        }

        public void MakePow2() {
            if (((Width - 1) & Width) != 0) {
                throw new Exception("Width must be a power of 2");
            }

            int y = 1;
            while (y < Height) {
                y *= 2;
            }
            Height = y;
        }
    }
}
