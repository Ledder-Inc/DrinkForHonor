using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDesideList : MonoBehaviour
{
    public static string[,] desideList;
    // Start is called before the first frame update
    void Start()
    {
        desideList = new string[,]
        {
            { "Auto", "Motorrad"},
            { "Arsch", "Titten"},
            { "Skoda", "Ford"}
        };
    }
}
