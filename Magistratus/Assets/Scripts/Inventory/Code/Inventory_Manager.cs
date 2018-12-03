using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Manager : MonoBehaviour {

    public int curesAvailable;
    public Text cureCountText; // Reference to the cure text UI

	// Initialize the inventory manager
	void Start () {
        curesAvailable = 0;
        cureCountText.text = " 0 Cures";
	}
	
	// Adds the new cures to the total cures available
    public void addCures(int newCures) {
        curesAvailable = curesAvailable + newCures;
        cureCountText.text = " " + curesAvailable.ToString() + " Cures";
    }

    public bool hasCureAvailable() {
        if (curesAvailable > 0) {
            curesAvailable = curesAvailable - 1;
            cureCountText.text = " " + curesAvailable.ToString() + " Cures";
            return true;
        }
        else {
            return false;
        }
    }
}
