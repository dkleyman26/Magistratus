using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public float h, v, lr;
    public float speed = 10; // The speed at which the player travels
    public float rotationSpeed = 8; // The speed at which the player rotates

    Rigidbody rb; // Rigidbody of the player
    Vector3 targetMotion; // Vector of the direction that the player moves in

	// Initialize the player movement script
	void Start () {
        rb = GetComponent<Rigidbody>(); // Gets the players Rigidbody
        rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal"); // Get the input from the A and D keys
        v = Input.GetAxis("Vertical"); // Get the input from the W and S keys
        lr = Input.GetAxis("Mouse X"); // Get the horizontal movement of the mouse
        Movement(h, v); // Call the Movement function
        Rotation(lr); // Call the Rotation function
	}

    // Move the player based on the key input
    void Movement(float h, float v) {
        // Set the direction vector by multiplying forward by the vertical vector and right by the horizontal vector
        targetMotion = transform.right * speed * Time.deltaTime * h + transform.forward * speed * Time.deltaTime * v;
        rb.MovePosition(transform.position + targetMotion); // Use the Rigidbody to move the player to the new position
    }

    // Rotate the player based on the mouse input
    void Rotation(float lr) {
        lr = lr * rotationSpeed;
        rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(0f, lr, 0f)); // Use the Rigidbody to rotate the player
    }
}
