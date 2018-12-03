using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Professor_Class {

    public bool spawned; // Bool indicating whether or not the professor has been spawned
    public bool alive; // Bool indicating whether or not the professor is alive
    public int id; // Id of the professor
    public float spawnTime; // Time that the professor will spawn at

    public Professor_Class(int newId) {
        // Initialize a new instance of the professor class
        spawned = false;
        alive = false;
        id = newId;
        spawnTime = (id - 1) * 120 + 3 * 5;
    }

}
