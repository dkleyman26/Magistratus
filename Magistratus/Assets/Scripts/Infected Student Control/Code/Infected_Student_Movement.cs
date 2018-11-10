using Pathing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Infected_Student_Movement : MonoBehaviour {
    public GameObject player; // Reference to the player
    int start; // Start building index
    int changeDistance = 10; // Distance from the targeted wander location to generate a new random location
    int chaseRange = 25; // Range the player has to enter to be chased
    int change = 15; // Range that the new target location can spawn within
    int randomX; // Random X coordinate
    int randomZ; // Random Z coordinate
    NavMeshAgent nav; // Infected Student NavMeshAgent
    public Vector3 targetWander; // Target vector to wander to
    Paths studentPaths = new Paths(); // Reference to the student path class
    int professorNumber; // If the building has a professor this number represents which number professor it is.
    int wanderDistance; // Distance the infected student can wander from the starting building

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

    // Determines which professor spawned the infected student
    void checkProfessor() {
        int i;
        for (i = 0; i < studentPaths.professorBuildings.Length; i++) {
            if (start == studentPaths.professorBuildings[i]) { // Mark which professor building the infected student spawned from
                professorNumber = i + 1;
            }
        }
    }

    // Sets the distance the infected student can wander around their spawn building
    void setWanderDistance() {
        if (professorNumber == 1 || professorNumber == 2) {
            wanderDistance = 500;
        }
        else if (professorNumber == 3 || professorNumber == 4) {
            wanderDistance = 750;
        }
        else if (professorNumber == 5 || professorNumber == 6) {
            wanderDistance = 1000;
        }
        else {
            wanderDistance = 1500;
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
        player = GameObject.Find("Player");
        getSpawnPoint(); // Find the Student's spawn point index
        checkProfessor(); // Check which professor spawned the infected student
        setWanderDistance(); // Set the distance the infected student can wander
        nav = GetComponent<NavMeshAgent>(); // Gets the Student's NavMeshAgent
        randomX = randomPlusMinusCurrent((int)transform.position.x, changeDistance + change); // Get a new random X coordinate
        randomZ = randomPlusMinusCurrent((int)transform.position.z, changeDistance + change); // Get a new random Z coordinate
        targetWander = new Vector3(randomX, transform.position.y, randomZ); // Set the target wander vector
        nav.SetDestination(targetWander); // Use the NavMeshAgent to path to the target wander vector
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 toPlayer = transform.position - player.transform.position; // Vector to the player's current position
        Vector3 toSpawn = transform.position - studentPaths.buildingCoordinates[start]; ; // Vector from current position to the spawn point
        if (toPlayer.magnitude < chaseRange && toPlayer.magnitude > -chaseRange) { // If the player is within the infected student's range
            nav.SetDestination(player.transform.position); // Use the NavMeshAgent to path to the player
        }
        else if (nav.remainingDistance < changeDistance) { // If the Student is within the change distance 
            randomX = randomPlusMinusCurrent((int)transform.position.x, change); // Get a new random X coordinate
            randomZ = randomPlusMinusCurrent((int)transform.position.z, change); // Get a new random Z coordinate
            targetWander.x = randomX; // Set the target wander vector X coordinate to the new random X coordinate
            targetWander.z = randomZ; // Set the target wander vector Z coordinate to the new random Z coordinate
            nav.SetDestination(targetWander); // Use the NavMeshAgent to path to the target wander vector
        }
        else if (!(toSpawn.magnitude < wanderDistance && toSpawn.magnitude > -wanderDistance)) { // If the Student wanders too far from its spawn building
            targetWander = studentPaths.buildingCoordinates[start]; // Set the target wander location to the start building coordinates
            nav.SetDestination(targetWander); // Use the NavMeshAgent to path to the target wander vector
        }
	}
}
