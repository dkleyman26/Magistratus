using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student_Spawner : MonoBehaviour {

    public GameObject student;                // The student gameobject to be spawned.
    public GameObject infectedStudent;        // The infected student gameobject to be spawned.
    public Professor_Spawner profesorManager; // The spawner manager for the professors.
    public Transform spawnPoint;              // The spawn point this student can spawn from.
    public bool canSpawnInfected = false;     // Bool indicating whether or not the spawn point can spawn an infected student.
    public int spawnIndex;                    // The index of the spawn point.
    public int professorNumber;               // If the building has a professor this number represents which number professor it is.
    float spawnTime = 6f;                     // How long between each spawn.
    Pathing.Paths studentPaths = new Pathing.Paths(); // Instance of the Paths class.

    // Determines the index of the spawn point
    void getSpawnPoint() {
        int i;
        Vector3 temp, spawn = spawnPoint.position;
        for (i = 0; i < studentPaths.buildingCoordinates.Length; i++) {
            temp = spawn - studentPaths.buildingCoordinates[i];
            if (temp.sqrMagnitude < 5 && temp.sqrMagnitude > -5) { // Finds the building that is closest labels that the spawn index
                spawnIndex = i;
            }
        }
    }

    // Determines if the spawn point can spawn infected students
    void checkSpawnPoint() {
        int i;
        for (i = 0; i < studentPaths.professorBuildings.Length; i++) {
            if (spawnIndex == studentPaths.professorBuildings[i]) { // If the spawn index matches a building a professor can spawn from, set canSpawnInfected to true and mark which professor is present
                canSpawnInfected = true;
                professorNumber = i + 1;
            }
        }
    }

    // Spawns and infected or non-infected student based on the strength of the professor
    void infectedChanceSpawn (int percentage) {
        int infected = UnityEngine.Random.Range(1, 101); // Generate a random number from 1 to 100
        if (infected <= percentage) { // If the random number is less than the infected percentage, spawn an infected student
            Instantiate(infectedStudent, spawnPoint.position, spawnPoint.rotation);
        }
        else { // Spawn a non-infected student
            Instantiate(student, spawnPoint.position, spawnPoint.rotation);
        }
    }

    // Initializes the student spawner
    void Start() {
        getSpawnPoint(); // Find the spawn point's index
        checkSpawnPoint(); // Check if a professor can exist at the building.
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Spawns a student or non-infected student
    void Spawn() {
        if (canSpawnInfected) { // If the student can spawn infected spawn it based the active professor
            switch(professorNumber) {
                case 1: // Qouneh infection chance
                    if (profesorManager.Qouneh.alive) {
                        infectedChanceSpawn(40);
                    }
                    else {
                        Instantiate(student, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;
                case 2: // Moriarty infection chance
                    if (profesorManager.Moriarty.alive) {
                        infectedChanceSpawn(45);
                    }
                    else {
                        Instantiate(student, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;
                case 3: // Northrup infection chance
                    if (profesorManager.Northrup.alive) {
                        infectedChanceSpawn(55);
                    }
                    else {
                        Instantiate(student, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;
                case 4: // Adamshick infection chance
                    if (profesorManager.Adamshick.alive) {
                        infectedChanceSpawn(60);
                    }
                    else {
                        Instantiate(student, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;
                case 5: // Musiak infection chance
                    if (profesorManager.Musiak.alive) {
                        infectedChanceSpawn(70);
                    }
                    else {
                        Instantiate(student, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;
                case 6: // Burke infection chance
                    if (profesorManager.Burke.alive) {
                        infectedChanceSpawn(75);
                    }
                    else {
                        Instantiate(student, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;
                case 7: // Magotra infection chance
                    if (profesorManager.Magotra.alive) {
                        infectedChanceSpawn(90);
                    }
                    else {
                        Instantiate(student, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;
                default: // default infection chance
                    infectedChanceSpawn(50);
                    break;
            }
        }
        else {
            // Default to spawning a non-infected student.
            Instantiate(student, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
