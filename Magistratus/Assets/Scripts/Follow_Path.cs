using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pathing {
    [RequireComponent(typeof(CharacterController))]
    public class Follow_Path : MonoBehaviour {

        public float speed = 10;
        static int maxTargets = 10;
        public Vector3[] targetLocation = new Vector3[maxTargets];
        public int currentTarget = 0;
        int start = (int)Buildings.Commonwealth;
        public int end = 25;

        CharacterController controller;
        Vector3 stopped = new Vector3(0, 0, 0);

        // Use this for initialization
        void Start() {
            controller = GetComponent<CharacterController>();
            //transform.eulerAngles = targetLocation;
            Paths pathsArray = new Paths();
            while ((end == start) || (end == 25)) {
                end = UnityEngine.Random.Range(0, 6);
            }
            Vector3[] tempTarget = new Vector3[1];// = pathsArray.pathSelect(start, end);
            Array.Resize(ref targetLocation, tempTarget.Length);
            targetLocation = tempTarget;
            targetLocation[currentTarget].y = transform.position.y;
            transform.forward = targetLocation[currentTarget] - transform.position;
            maxTargets = targetLocation.Length;
        }

        // Update is called once per frame
        void Update() {
            if (currentTarget < maxTargets)
            {
                targetLocation[currentTarget].y = transform.position.y;
                transform.forward = targetLocation[currentTarget] - transform.position;
                if (!((transform.position.z >= targetLocation[currentTarget].z - .5) && (transform.position.z <= targetLocation[currentTarget].z + .5) && (transform.position.x >= targetLocation[currentTarget].x - .5) && (transform.position.x <= targetLocation[currentTarget].x + .5)))
                {
                    var forward = transform.TransformDirection(Vector3.forward);
                    controller.SimpleMove(forward * speed);
                    Debug.Log("Moving.");
                }
                else
                {
                    currentTarget++;
                    Debug.Log("Changed Target.");
                }
            }
            else
            {
                controller.SimpleMove(stopped);
                Debug.Log("Stopped");
            }
        }
    }
}
