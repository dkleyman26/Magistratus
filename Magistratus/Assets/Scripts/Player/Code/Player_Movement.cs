using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public float h, v, lr;
    public float speed = 10; // The speed at which the player travels
    public float rotationSpeed = 8; // The speed at which the player rotates
    public Player_Reactions playerReactions; // Reference to the player reactions script

    bool canThrow = true; // Boolean indicating that the player can throw a cure
    int throwTimer; // Delay count for how long until the player can throw again
    Rigidbody rb; // Rigidbody of the player
    Vector3 targetMotion; // Vector of the direction that the player moves in
    Inventory_Manager inventory; // Reference to the player's inventory
    Terrain_Modifiers terra; // Reference to the game's terrain modifiers

	// Initialize the player movement script
	void Start () {
        playerReactions = GetComponent<Player_Reactions>(); // Gets the players reactions script
        inventory = GetComponent<Inventory_Manager>(); // Get the players inventory
        terra = GameObject.Find("Terra_Mod").GetComponent<Terrain_Modifiers>(); // Get the terrain modifiers
        rb = GetComponent<Rigidbody>(); // Gets the players Rigidbody
        rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal"); // Get the input from the A and D keys
        v = Input.GetAxis("Vertical"); // Get the input from the W and S keys
        lr = Input.GetAxis("Mouse X"); // Get the horizontal movement of the mouse
        bool sb = Input.GetKeyDown("space"); // Check the state of the spacebar
        if (!playerReactions.stunned) { // If the Player is not stunned, move
            Movement(h, v); // Call the Movement function
            Rotation(lr); // Call the Rotation function
            if (sb) {
                throwCure();
            }
        }
        if (!canThrow) {
            throwTimer--;
            if (throwTimer == 0) {
                canThrow = true;
            }
        }
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

    // Sets an area in front of the player to be a cure area
    void throwCure() {
        if (canThrow && inventory.hasCureAvailable()) {
            canThrow = false; // The player can't immediately throw again
            throwTimer = 10; // Delay for how long until the player can throw again
            terra.setCurePatch(transform.position + transform.forward * 2);// Set the infected ground
        }
    }
}
