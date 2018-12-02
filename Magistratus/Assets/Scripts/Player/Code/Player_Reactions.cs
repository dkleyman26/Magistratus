using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Reactions : MonoBehaviour {

    public bool stunned;
    int stunCounter;
    int freeCounter;
    int repeatCounter;
    GameObject player; // Reference to the player
    Vector3 respawn = new Vector3(205, 5, 16);

	// Initializes the script
	void Start () {
		
	}

    public void stunPlayer(int stunStrength) {
        player = GameObject.Find("Player"); // Get the reference to the player
        stunned = true;
        stunCounter = stunStrength;
    }
	
	// Update is called once per frame
	void Update () {
		if (stunned) {
            freeCounter = 0;
            repeatCounter++;
            if (repeatCounter > 100) {
                player.transform.position = respawn; // Send the player back to public safety
                repeatCounter = 0;
                stunCounter = 0;
            }
            stunCounter--;
            if (stunCounter <= 0) {
                stunned = false;
            }
        }
        else {
            freeCounter++;
            if (freeCounter > 25) {
                repeatCounter = 0;
            }
        }
	}
}
