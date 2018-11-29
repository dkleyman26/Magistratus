using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Reactions : MonoBehaviour {

    public bool stunned;
    int stunCounter;
    int freeCounter;
    int repeatCounter;

	// Initializes the script
	void Start () {
		
	}

    public void stunPlayer(int stunStrength) {
        stunned = true;
        stunCounter = stunStrength;
    }
	
	// Update is called once per frame
	void Update () {
		if (stunned) {
            freeCounter = 0;
            repeatCounter++;
            if (repeatCounter > 100)
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
