using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Time : MonoBehaviour {

    public float zeroTime; // Time at the start of the game
    public float currentTime; // The current time in the game
    public int currentDay = 0; // The current day in the game
    public int currentHour = 0; // The current hour in the game
    public float oneDay = 240; // The number of seconds in one game day
    public float oneHour = 10; // The number of seconds in one game hour
    public int hoursInOneDay = 24; // The number of game hours in one day
    
	// Use this for initialization
	void Start () {
        zeroTime = Time.time; // Initialize the zero time
        currentTime = Time.time - zeroTime; 
	}
	
	// Update is called once per frame
	void Update () {
        currentTime = Time.time - zeroTime; // Update the current time
        currentDay = (int)(currentTime / oneDay); // Update the current day
        currentHour = (int)(currentTime / oneHour) - (currentDay * hoursInOneDay); // Update the current hour
	}
}
