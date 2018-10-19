using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student_Spawner : MonoBehaviour {

    public GameObject student;                // The student gameobject to be spawned.
    public float spawnTime = 5f;            // How long between each spawn.
    public Transform spawnPoint;         // The spawn point this student can spawn from.


    void Start() {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn() {

        // Create an instance of the student prefab at the spawn point.
        Instantiate(student, spawnPoint.position, spawnPoint.rotation);
    }
}
