using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    //private float scrollSpeed = 5f;
    //private float minY = 10f;
    //private float maxY = 100f;

    public GameMaster gameMaster;
    private Transform playerOnTurn;
    // Start is called before the first frame update
    void Start()
    {
        playerOnTurn = gameMaster.playerOnTurn.transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerOnTurn = gameMaster.playerOnTurn.transform;
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.position = new Vector3(playerOnTurn.position.x, 200, -350);
    }
}
