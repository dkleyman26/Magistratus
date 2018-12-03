using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Professor_Spawner : MonoBehaviour {
    public Professor_Class Qouneh = new Professor_Class(1);
    public Professor_Class Moriarty = new Professor_Class(2);
    public Professor_Class Northrup = new Professor_Class(3);
    public Professor_Class Adamshick = new Professor_Class(4);
    public Professor_Class Musiak = new Professor_Class(5);
    public Professor_Class Burke = new Professor_Class(6);
    public Professor_Class Magotra = new Professor_Class(7);

    public Global_Time gameTime;
    public Transform[] spawnPoints;
    public GameObject oQouneh;
    public GameObject oMoriarty;
    public GameObject oNorthrup;
    public GameObject oAdamshick;
    public GameObject oMusiak;
    public GameObject oBurke;
    public GameObject oMagotra;

    public Text spawnNotification;
    public Image background;
    public Text profText;
    int notificationCounter = 101;
    int profActive = 0;
    string profName;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", gameTime.oneHour, gameTime.oneHour);
    }

    private void Update() {
        notificationCounter++;
        if (notificationCounter > 100) {
            spawnNotification.text = "";
            background.enabled = false;
        }
        else {
            spawnNotification.text = "Professor " + profName + " Has Spawned";
            background.enabled = true;
        }
        profText.text = "Professors Active: " + profActive.ToString();
    }

    void Spawn () {
        // Spawn Qouneh if it is his time and he hasn't been spawned yet.
		if (gameTime.currentTime >= Qouneh.spawnTime && !Qouneh.spawned) {
            Instantiate(oQouneh, spawnPoints[Qouneh.id].position, spawnPoints[Qouneh.id].rotation);
            Qouneh.spawned = true;
            Qouneh.alive = true;
            profName = "Qouneh";
            notificationCounter = 0;
            profActive++;
        }
        // Spawn Moriarty if it is his time and he hasn't been spawned yet.
        if (gameTime.currentTime >= Moriarty.spawnTime && !Moriarty.spawned) {
            Instantiate(oMoriarty, spawnPoints[Moriarty.id].position, spawnPoints[Moriarty.id].rotation);
            Moriarty.spawned = true;
            Moriarty.alive = true;
            profName = "Moriarty";
            notificationCounter = 0;
            profActive++;
        }
        // Spawn Northrup if it is his time and he hasn't been spawned yet.
        if (gameTime.currentTime >= Northrup.spawnTime && !Northrup.spawned) {
            Instantiate(oNorthrup, spawnPoints[Northrup.id].position, spawnPoints[Northrup.id].rotation);
            Northrup.spawned = true;
            Northrup.alive = true;
            profName = "Northrup";
            notificationCounter = 0;
            profActive++;
        }
        // Spawn Adamshick if it is his time and he hasn't been spawned yet.
        if (gameTime.currentTime >= Adamshick.spawnTime && !Adamshick.spawned) {
            Instantiate(oAdamshick, spawnPoints[Adamshick.id].position, spawnPoints[Adamshick.id].rotation);
            Adamshick.spawned = true;
            Adamshick.alive = true;
            profName = "Adamshick";
            notificationCounter = 0;
            profActive++;
        }
        // Spawn Musiak if it is his time and he hasn't been spawned yet.
        if (gameTime.currentTime >= Musiak.spawnTime && !Musiak.spawned) {
            Instantiate(oMusiak, spawnPoints[Musiak.id].position, spawnPoints[Musiak.id].rotation);
            Musiak.spawned = true;
            Musiak.alive = true;
            profName = "Musiak";
            notificationCounter = 0;
            profActive++;
        }
        // Spawn Burke if it is his time and he hasn't been spawned yet.
        if (gameTime.currentTime >= Burke.spawnTime && !Burke.spawned) {
            Instantiate(oBurke, spawnPoints[Burke.id].position, spawnPoints[Burke.id].rotation);
            Burke.spawned = true;
            Burke.alive = true;
            profName = "Burke";
            notificationCounter = 0;
            profActive++;
        }
        // Spawn Magotra if it is his time and he hasn't been spawned yet.
        if (gameTime.currentTime >= Magotra.spawnTime && !Magotra.spawned) {
            Instantiate(oMagotra, spawnPoints[Magotra.id].position, spawnPoints[Magotra.id].rotation);
            Magotra.spawned = true;
            Magotra.alive = true;
            profName = "Magotra";
            notificationCounter = 0;
            profActive++;
        }
	}

    public bool isProfessorAlive(int num) {
        switch (num) {
            case 1:
                return Qouneh.alive;
                break;
            case 2:
                return Moriarty.alive;
                break;
            case 3:
                return Northrup.alive;
                break;
            case 4:
                return Adamshick.alive;
                break;
            case 5:
                return Musiak.alive;
                break;
            case 6:
                return Burke.alive;
                break;
            case 7:
                return Magotra.alive;
                break;
            default:
                return false;
                break;
        }
    }

    public void killProfessor(int num) {
        switch (num) {
            case 1:
                Qouneh.alive = false;
                profActive--;
                break;
            case 2:
                Moriarty.alive = false;
                profActive--;
                break;
            case 3:
                Northrup.alive = false;
                profActive--;
                break;
            case 4:
                Adamshick.alive = false;
                profActive--;
                break;
            case 5:
                Musiak.alive = false;
                profActive--;
                break;
            case 6:
                Burke.alive = false;
                profActive--;
                break;
            case 7:
                Magotra.alive = false;
                profActive--;
                break;
            default:
                break;
        }
    }
}
