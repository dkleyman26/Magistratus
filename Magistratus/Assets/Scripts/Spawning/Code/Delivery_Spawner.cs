using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delivery_Spawner : MonoBehaviour {

    public GameObject Cure;
    public Transform spawnPoint;
    public Global_Time gameTime;
    public Text deliveryNotification;
    public Image background;
    bool thisHour;
    int notification_Counter = 101;

	// Use this for initialization
	void Start () {
        thisHour = false;
        InvokeRepeating("Spawn", gameTime.oneHour * 2, gameTime.oneHour / 2);
	}

    private void Update() {
        notification_Counter++;
        if (notification_Counter > 100) {
            deliveryNotification.text = "";
            background.enabled = false;
        }
        else {
            deliveryNotification.text = "A Delivery Has Spawned";
            background.enabled = true;
        }
    }

    void Spawn() {
        if (gameTime.currentHour % 4 == 0 && !thisHour) {
            Instantiate(Cure, spawnPoint.position, spawnPoint.rotation);
            thisHour = true;
            notification_Counter = 0;
        }
        else if (gameTime.currentHour % 4 != 0){
            thisHour = false;
        }
    }
}
