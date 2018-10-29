using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Player : MonoBehaviour {

    public GameObject player; // The gameobject of the player

    Vector3 offset; // Vector indicating the camera offset from the player

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position; // Initialize the offset
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset; // Move the camera to the offset position from the player
        transform.rotation = player.transform.rotation; // Rotate the camera to match the players rotation
	}
}
