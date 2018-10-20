using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathing {

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

        public Vector3[] buildingCoordinates = { new Vector3(-130, 13, -31), // Sleith
                                                 new Vector3(-64, 12, 17), // Dining
                                                 new Vector3(-152, 13, -127), // Rivers
                                                 new Vector3(-25, 15, -140), // Commonwealth
                                                 new Vector3(59, 17, -116), // LaRiv
                                                 new Vector3(52, 15, -60), // Windham
                                                 new Vector3(147, 16, 59), // Berkshire
                                                 new Vector3(129, 16, 0), // Hampden
                                                 new Vector3(95, 16, 24), // Franklin
                                                 new Vector3(159, 13, 110), // Donut1
                                                 new Vector3(69, 12, 124), // CSP
                                                 new Vector3(1, 16, 132), // Emerson
                                                 new Vector3(19, 12, 52), // DAmour
                                                 new Vector3(-9, 12, 26), // Churchill
                                                 new Vector3(-35, 12, 52), // DeLiso
                                                 new Vector3(-112, 7, 83), // Herman
                                                 new Vector3(-162, 4, 97), // Welcome
                                                 new Vector3(205, 16, 16) }; // PublicSafety

    }
}