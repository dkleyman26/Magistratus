using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Pathing {
    public class Student_Walking : MonoBehaviour {

        NavMeshAgent nav; // Student NavMeshAgent
        public int start; // Starting building index
        public int end = 25; // Ending building index
        public Vector3 targetLocation; // Vector of the target location
        Paths studentPaths = new Paths(); // Instance of the Paths class

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

        // Initializes the script
        void Start() {
            getSpawnPoint(); // Finds the Student's spawn point
            nav = GetComponent<NavMeshAgent>(); // Get's the Student's NavMeshAgent
            while ((end == start) || (end == 25)) {
                end = Random.Range(0, studentPaths.buildingCoordinates.Length - 1); // Selects a random end building to walk to
            }
            targetLocation = studentPaths.buildingCoordinates[end]; // Gets the vector of the end building
        }

        // Update is called once per frame
        void Update() {
            Vector3 temp;
            nav.SetDestination(targetLocation); // Uses the NAvMeshAgent to path to the end building
            temp = transform.position - studentPaths.buildingCoordinates[end]; // Calculates the distance between the Student and the end building
            if (temp.magnitude < 11 && temp.magnitude > -11) { // If the Student is within range of the end building, kill the Student
                Destroy(gameObject);
            }
        }
    }
}