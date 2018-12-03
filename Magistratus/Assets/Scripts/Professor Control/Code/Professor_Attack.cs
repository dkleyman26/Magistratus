using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Professor_Attack : MonoBehaviour {
    public GameObject player; // Reference to the player
    public Player_Reactions playerReactions; // Reference to the player reactions script
    public Vector3 toPlayer; // Vector distance to the player
    public Global_Time gameTime; // Reference to the current game time
    public bool canAttack;
    public int attackTimer;
    int strength;

    // Checks if the player is within hit range and stuns the player
    void hitPlayer() {
        toPlayer = player.transform.position - transform.position;
        if (toPlayer.magnitude < 6) {
            playerReactions.stunPlayer(20 * strength);
        }
    }

    // Sets the strngth of the professor's attacks based off of the professor.
    void getStrength() {
        if (gameTime.currentTime < 520) {
            strength = 1;
        }
        else if (gameTime.currentTime < 960) {
            strength = 2;
        }
        else if (gameTime.currentTime < 1440) {
            strength = 3;
        }
        else {
            strength = 4;
        }
    }

    // Use this for initialization
    void Start () {
        gameTime = GameObject.Find("Time_Manager").GetComponent<Global_Time>();
        player = GameObject.Find("Player"); // Initialize reference to the player
        toPlayer = player.transform.position - transform.position; // Initialize the distance to the player
        playerReactions = player.GetComponent<Player_Reactions>();
        canAttack = true;
        getStrength();
    }
	
	// Update is called once per frame
	void Update () {
        toPlayer = player.transform.position - transform.position; // Recalculate the distance to the player
        if (toPlayer.magnitude < 6 && canAttack) {
            // trigger attack animation
            hitPlayer();
            canAttack = false;
            attackTimer = 100;
        }
        if (!canAttack) {
            attackTimer--;
            if (attackTimer <= 0) {
                canAttack = true;
            }
        }
    }
}
