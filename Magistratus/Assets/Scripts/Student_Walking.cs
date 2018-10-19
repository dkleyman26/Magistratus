using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Pathing {
    public class Student_Walking : MonoBehaviour {

        NavMeshAgent nav;
        public int start;
        public int end = 25;
        public Vector3 targetLocation;
        Paths studentPaths = new Paths();

        void getSpawnPoint() {
            int i;
            Vector3 temp, spawn = transform.position;
            for (i = 0; i < studentPaths.buildingCoordinates.Length; i++) {
                temp = spawn - studentPaths.buildingCoordinates[i];
                if (temp.sqrMagnitude < 5 && temp.sqrMagnitude > -5) {
                    start = i;
                }
            }
        }

        // Use this for initialization
        void Start() {
            getSpawnPoint();
            nav = GetComponent<NavMeshAgent>();
            while ((end == start) || (end == 25)) {
                end = UnityEngine.Random.Range(0, studentPaths.buildingCoordinates.Length - 1);
            }
            targetLocation = studentPaths.buildingCoordinates[end];
        }

        // Update is called once per frame
        void Update() {
            Vector3 temp;
            nav.SetDestination(targetLocation);
            temp = transform.position - studentPaths.buildingCoordinates[end];
            if (temp.sqrMagnitude < 7 && temp.sqrMagnitude > -7) {
                Destroy(gameObject);
            }
        }
    }
}