using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Reactions : MonoBehaviour {

    public Text stunnedText;
    public Image background;
    public bool stunned;
    int stunCounter;
    int freeCounter;
    int repeatCounter;
    int notificationCounter = 101;
    GameObject player; // Reference to the player
    Vector3 respawn = new Vector3(205, 5, 16);

	// Initializes the script
	void Start () {
        stunnedText.text = "";
        background.enabled = false;
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
                notificationCounter = 0;
            }
            stunCounter--;
            if (stunCounter <= 0) {
                stunned = false;
            }
            stunnedText.text = "Stunned!";
            background.enabled = true;
        }
        else {
            freeCounter++;
            notificationCounter++;
            if (freeCounter > 50) {
                repeatCounter = 0;
            }
            if (notificationCounter > 50) {
                stunnedText.text = "";
                background.enabled = false;
            }
            else {
                stunnedText.text = "Knocked Out!";
                background.enabled = true;
            }
        }
	}
}
