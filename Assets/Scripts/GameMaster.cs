using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private int numberOfNodes = 400;
    public int roundMultiplicator = 1;

    public GameObject nodePrefab;
    public Transform nodeParent;
    private Node nodeStart;

    private GameObject[] playerList;
    public GameObject playerPrefab;
    public Transform playerParent;
    public GameObject playerOnTurn;

    public Transform spawnPoint;

    public Vector3 nodePosition;

    public enum FieldTyp
    {
        Start = 1,
        End = 2,
        Drink = 3,
        Topic = 4,
        Deside = 5
    }

    // Start is called before the first frame update
    void Start()
    {
        nodePosition = spawnPoint.position;
        SpawnNode();
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        string name;
        int type;
        int position = 0; //später vielleicht mit Effekten
        int number = 0;

        foreach (var playerFromList in playerList)
        {

            GameObject playerGO = (GameObject)Instantiate(playerPrefab, nodeStart.transform.position, spawnPoint.rotation);
            playerGO.transform.parent = playerParent;
            Player player = playerGO.GetComponent<Player>();
            type = 1; // später soll ggf. Gruppen folgen
            name = playerFromList.name;

            if (number == 0)
            {
                playerOnTurn = playerGO;
            }

            if (player != null)
            {
                player.SetPlayerStartValues(name, position, type, nodeStart, number);
            }
            number++;
        }
    }

    internal void SetNextPlayer()
    {
        int countPlayers = Players.players.Length;
        int numberPlayerOnTurn = playerOnTurn.GetComponent<Player>().number;
        if (numberPlayerOnTurn >= countPlayers-1)
        {
            numberPlayerOnTurn = -1;
        }
        Transform temp = Players.players[numberPlayerOnTurn + 1];
        playerOnTurn = GameObject.Find(temp.name);
    }

    private void SpawnNode()
    {
        string name;
        int type;

        for (int i = 0; i < numberOfNodes; i++)
        {
            GameObject nodeGO = (GameObject)Instantiate(nodePrefab, nodePosition, spawnPoint.rotation);
            nodeGO.transform.parent = nodeParent;

            Node node = nodeGO.GetComponent<Node>();

            type = UnityEngine.Random.Range(3, 6);

            if (i == 0)
            {
                type = 1; //für Start Node
                nodeStart = node;
            }
            else if (i == numberOfNodes - 1)
            {
                type = 2; //für End Node
            }

            name = "Field_" + (FieldTyp)type + "_" + i;

            if (node != null)
            {
                node.SetNodeStartValuse(name, i, type);
            }

            nodePosition.x += 150;
        }

    }
}
