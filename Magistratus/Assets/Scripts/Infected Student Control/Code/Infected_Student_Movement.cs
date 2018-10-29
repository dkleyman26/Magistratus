using Pathing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Infected_Student_Movement : MonoBehaviour {

    int start; // Start building index
    int changeDistance = 10; // Distance from the targeted wander location to generate a new random location
    int change = 15; // Range that the new target location can spawn within
    int randomX; // Random X coordinate
    int randomZ; // Random Y coordinate
    NavMeshAgent nav; // Student NavMeshAgent
    public Vector3 targetWander; // Target vecotr to wander to
    Paths studentPaths = new Paths();

    // Determines the index of the spawn point
    void getSpawnPoint() {
        int i;
        Vector3 temp, spawn = transform.position;
        for (i = 0; i < studentPaths.buildingCoordinates.Length; i++) {
            temp = spawn - studentPaths.buildingCoordinates[i];
            if (temp.sqrMagnitude < 5 && temp.sqrMagnitude > -5) { // Finds the building that is closest labels that the spawn index
                start = i;
            }
        }
    }

    // Generates a random value within a range of the current value
    int randomPlusMinusCurrent(int currentValue, int changeAmount) {
        int minus, plus, val;
        plus = currentValue + changeAmount; // The upper end of the range
        minus = currentValue - changeAmount; // The lower end of the range
        val = Random.Range(minus, plus + 1); // New random number within the range
        return val;
    }

    // Initializes the script
    void Start () {
        getSpawnPoint(); // Find the Student's spawn point index
        nav = GetComponent<NavMeshAgent>(); // Gets the Student's NavMeshAgent
        randomX = randomPlusMinusCurrent((int)transform.position.x, changeDistance + change); // Get a new random X coordinate
        randomZ = randomPlusMinusCurrent((int)transform.position.z, changeDistance + change); // Get a new random Z coordinate
        targetWander = new Vector3(randomX, transform.position.y, randomZ); // Set the target wander vector
        nav.SetDestination(targetWander); // Use the NavMeshAgent to path to the target wander vector
	}
	
	// Update is called once per frame
	void Update () {
    Vector3 currentPosition; // Vector of the Student's current position
    Vector3 temp; // Temporary vector
    currentPosition = transform.position; // Get the Student's current location
        temp = transform.position - studentPaths.buildingCoordinates[start]; // Calculates a vector with the distance between the Student and its starting building
        if (nav.remainingDistance < changeDistance) { // If the Student is within the change distance 
            randomX = randomPlusMinusCurrent((int)transform.position.x, change); // Get a new random X coordinate
            randomZ = randomPlusMinusCurrent((int)transform.position.z, change); // Get a new random Z coordinate
            targetWander.x = randomX; // Set the target wander vector X coordinate to the new random X coordinate
            targetWander.z = randomZ; // Set the target wander vector Z coordinate to the new random Z coordinate
            nav.SetDestination(targetWander); // Use the NavMeshAgent to path to the target wander vector
        }
        else if (!(temp.magnitude < 1000 && temp.magnitude > -1000)) { // If the Student wanders too far from its spawn building
            targetWander = studentPaths.buildingCoordinates[start]; // Set the target wander location to the start building coordinates
            nav.SetDestination(targetWander); // Use the NavMeshAgent to path to the target wander vector
        }
	}
}
