using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure_Delivery_Control : MonoBehaviour {

    public GameObject player; // Reference to the player
    public Inventory_Manager inventory; // Reference to the inventory
    int cureInBox; // Number of cures in the delivery box

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        inventory = player.GetComponent<Inventory_Manager>();
        cureInBox = Random.Range(1, 6);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 toPlayer = transform.position - player.transform.position; // Vector to the player's current position
        if (toPlayer.magnitude < 3) { // If the player walks over the delivery box
            inventory.addCures(cureInBox); // Add the cures to the inventory
            Destroy(gameObject); // Destroys the delivery box
        }
    }
}
