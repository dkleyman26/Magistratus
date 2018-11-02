using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour {

    public int curesAvailable;

	// Initialize the inventory manager
	void Start () {
        curesAvailable = 0;
	}
	
	// Adds the new cures to the total cures available
    public void addCures(int newCures) {
        curesAvailable = curesAvailable + newCures;
    }

    public bool hasCureAvailable() {
        if (curesAvailable > 0) {
            curesAvailable = curesAvailable - 1;
            return true;
        }
        else {
            return false;
        }
    }
}
