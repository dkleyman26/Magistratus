using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

    public Image background;
    public Text title;
    public Text end;
    public bool done;
    public Global_Time gameTime;
    public Button startButton;
    public Professor_Spawner profManager;
    public bool notStarted;

	// Use this for initialization
	void Start () {
        notStarted = true;
        done = false;
        background.enabled = true;
        title.enabled = true;
        end.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (notStarted) {
            gameTime.zeroTime = Time.time;
        }
        else if (done) {
            background.enabled = true;
            end.enabled = true;
        }
        else {
            background.enabled = false;
            title.enabled = false;
            startButton.gameObject.SetActive(false);
            if (!profManager.Magotra.alive && profManager.Magotra.spawned) {
                done = true;
            }
        }
	}

    // To be called when the start button is clicked
    public void buttonClicked() {
        notStarted = false;
    }
}
