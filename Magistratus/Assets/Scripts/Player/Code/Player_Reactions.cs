using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Reactions : MonoBehaviour {

    public bool stunned;
    int stunCounter;

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
            stunCounter--;
            if (stunCounter <= 0) {
                stunned = false;
            }
        }
	}
}
