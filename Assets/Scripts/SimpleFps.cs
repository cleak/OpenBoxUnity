using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleFps : MonoBehaviour {

    CharacterController controller;

    public new Camera camera;

    public float moveSpeed = 16;
    public float turnSpeed = 16;
    public float jumpSpeed = 10.0f;

    public float fallGravityMultiplier = 2.0f;

    public bool canJump = true;

    public Vector3 velocity = Vector3.zero;
    public float gravity = 9.8f;
    public Vector3 gravityDirection = new Vector3(0, -1, 0);

    public GameObject projectilePrefab;
    public float projectileSpeed = 16.0f;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.isGrounded) {
            canJump = true;

            float gravProj = Vector3.Dot(velocity, gravityDirection);
            if (gravProj > 0) {
                velocity -= gravProj * gravityDirection;
            }
        }

        float speedMultiplier = 1.0f;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            speedMultiplier = 2.5f;
        }

        Vector3 delta = Vector3.zero;
        float accel = gravity;

        if (velocity.y < 0) {
            accel *= fallGravityMultiplier;
        }

        delta += velocity * Time.deltaTime + gravityDirection * 0.5f * accel * Time.deltaTime * Time.deltaTime;
        velocity += accel * gravityDirection * Time.deltaTime;

        if (canJump && Input.GetKeyDown(KeyCode.Space)) {
            canJump = false;
            velocity += jumpSpeed * -gravityDirection;
        }


        // Movement
		if (Input.GetKey(KeyCode.W)) {
            delta += transform.forward * Time.deltaTime * moveSpeed * speedMultiplier;
        }

        if (Input.GetKey(KeyCode.S)) {
            delta -= transform.forward * Time.deltaTime * moveSpeed * speedMultiplier;
        }

        if (Vector3.Dot(delta, delta) > 0) {
            controller.Move(delta);
        }

        // Rotation
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * speedMultiplier);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.up, -Time.deltaTime * turnSpeed * speedMultiplier);
        }

        if (Input.GetKey(KeyCode.PageDown)) {
            camera.transform.Rotate(Vector3.right, Time.deltaTime * turnSpeed * speedMultiplier);
        }

        if (Input.GetKey(KeyCode.PageUp)) {
            camera.transform.Rotate(Vector3.right, -Time.deltaTime * turnSpeed * speedMultiplier);
        }

        if (Input.GetKeyDown(KeyCode.Home)) {
            camera.transform.localRotation = Quaternion.identity;
        }

        // Projectiles
        if (Input.GetKeyDown(KeyCode.Q)) {
            GameObject projectile = Instantiate(projectilePrefab);
            var projectileBody = projectile.GetComponent<Rigidbody>();

            projectileBody.transform.position = camera.transform.position + camera.transform.forward * 0.25f;
            projectileBody.transform.forward = camera.transform.forward;
            projectileBody.velocity = projectileBody.transform.forward * projectileSpeed;
        }
    }
}
