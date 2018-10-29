using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathing {

    // Enumeration of the buildings
    public enum Buildings {
        Sleith = 0,
        Dining = 1,
        Rivers = 2,
        Commonwealth = 3,
        LaRiv = 4,
        Windham = 5,
        Berkshire = 6,
        Hampden = 7,
        Franklin = 8,
        Donut1 = 9,
        CSP = 10,
        Emerson = 11,
        DAmour = 12,
        Churchill = 13,
        DeLiso = 14,
        Herman = 15,
        Welcome = 16,
        PublicSafety = 17
    }

    public class Paths {

        // Arrary of building coordinates
        public Vector3[] buildingCoordinates = { new Vector3(-130, 5, -31), // Sleith
                                                 new Vector3(-64, 5, 17), // Dining
                                                 new Vector3(-152, 5, -127), // Rivers
                                                 new Vector3(-25, 5, -140), // Commonwealth
                                                 new Vector3(59, 5, -116), // LaRiv
                                                 new Vector3(52, 5, -60), // Windham
                                                 new Vector3(147, 5, 59), // Berkshire
                                                 new Vector3(129, 5, 0), // Hampden
                                                 new Vector3(95, 5, 24), // Franklin
                                                 new Vector3(159, 5, 110), // Donut1
                                                 new Vector3(69, 5, 124), // CSP
                                                 new Vector3(1, 5, 132), // Emerson
                                                 new Vector3(19, 5, 52), // DAmour
                                                 new Vector3(-9, 5, 26), // Churchill
                                                 new Vector3(-35, 5, 52), // DeLiso
                                                 new Vector3(-112, 5, 83), // Herman
                                                 new Vector3(-162, 5, 97), // Welcome
                                                 new Vector3(205, 5, 16) }; // PublicSafety

        // Array of buildings that professors can spawn from
        public int[] professorBuildings = { (int)Buildings.Emerson, // Qouneh Spawn
                                            (int)Buildings.DeLiso, // Moriarty Spawn
                                            (int)Buildings.DAmour, // Northrup Spawn
                                            (int)Buildings.Churchill, // Adamshick Spawn
                                            (int)Buildings.Rivers, // Musiak Spawn
                                            (int)Buildings.CSP, // Burke Spawn
                                            (int)Buildings.Sleith }; // Magotra spawn

    }
}