using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery_Spawner : MonoBehaviour {

    public GameObject Cure;
    public Transform spawnPoint;
    public Global_Time gameTime;
    bool thisHour;

	// Use this for initialization
	void Start () {
        thisHour = false;
        InvokeRepeating("Spawn", gameTime.oneHour * 2, gameTime.oneHour / 2);
	}
	
	void Spawn() {
        if (gameTime.currentHour % 4 == 0 && !thisHour) {
            Instantiate(Cure, spawnPoint.position, spawnPoint.rotation);
            thisHour = true;
        }
        else if (gameTime.currentHour % 4 != 0){
            thisHour = false;
        }
    }
}
