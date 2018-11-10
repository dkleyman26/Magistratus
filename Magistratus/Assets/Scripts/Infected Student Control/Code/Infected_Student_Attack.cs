using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infected_Student_Attack : MonoBehaviour {
    public GameObject player; // Reference to the player
    public Player_Reactions playerReactions; // Reference to the player reactions script
    public Vector3 toPlayer; // Vector distance to the player
    public bool canAttack;
    public int attackTimer;

    // Checks if the player is within hit range and stuns the player
    void hitPlayer() {
        toPlayer = player.transform.position - transform.position;
        if (toPlayer.magnitude < 5) {
            playerReactions.stunPlayer(25);
        }
    }

    // Initializes the script
    void Start () {
        player = GameObject.Find("Player"); // Initialize reference to the player
        toPlayer = player.transform.position - transform.position; // Initialize the distance to the player
        playerReactions = player.GetComponent<Player_Reactions>();
        canAttack = true;
    }
	
	// Update is called once per frame
	void Update () {
        toPlayer = player.transform.position - transform.position; // Recalculate the distance to the player
        if (toPlayer.magnitude < 4 && canAttack) {
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
