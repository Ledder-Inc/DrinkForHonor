using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public static Transform[] players;

    // Start is called before the first frame update
    void Start()
    {
        players = new Transform[transform.childCount];
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = transform.GetChild(i);
        }
    }
}
