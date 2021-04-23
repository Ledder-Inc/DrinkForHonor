using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int position;
    public int number;
    public int type; //später für Gruppen
    public float speed;
    public int shots = 0;

    private Renderer colorRenderer;
    private Node node;
    public GameObject actionDrinkPrefab;
    public GameObject playerInfoTextPrefab;
    public GameObject actionDesideSimplePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.GetType() + " : " + this.name + " -> " + this.node.GetType() + " : " + this.node.name);
        speed = 300f; // keine wird irgendwie sonst nicht gezogen...
        CreatePlayerInfoText();
    }

    void Update()
    {
        if (node != null)
        {
            Vector3 dir = node.transform.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, node.transform.position) >= 0.4f)
            {
                //Debug.Log("distance : " + Vector3.Distance(transform.position, node.transform.position) + "f => speed : " + speed + "f");
                dir = node.transform.position - transform.position;
                distanceThisFrame = speed * Time.deltaTime;
                transform.Translate(dir.normalized * distanceThisFrame, Space.World);
                transform.LookAt(node.transform);
            }

        }
    }

    private void CreatePlayerInfoText()
    {
        GameObject playerInfoTextGO = (GameObject)Instantiate(playerInfoTextPrefab,  new Vector3(-80,-15,0), playerInfoTextPrefab.transform.rotation);
        playerInfoTextGO.transform.parent = GameObject.FindGameObjectWithTag("OverlayCanvas").transform;
        playerInfoTextGO.name = "Text_" + name;
        PlayerInfoText playerInfoText = playerInfoTextGO.GetComponent<PlayerInfoText>();
        playerInfoText.SetPlayer(this);

        // Provide Text position and size using RectTransform.
        RectTransform rectTransform;
        rectTransform = playerInfoTextGO.GetComponent<RectTransform>();

        int x = -385;
        int y = -385;
        int z = -0;
        int width = 200;
        int height = 20;

        //reicht für Alpha ;)
        if (number != 0) y -= height * number;

        rectTransform.anchoredPosition = new Vector3(x, y, z);
        rectTransform.sizeDelta = new Vector2(width, height);

    }

    public void Move(int rollNumber)
    {
        Transform temp = Nodes.nodes[position + rollNumber];
        SetNode(GameObject.Find(temp.name).GetComponent<Node>());
        position += rollNumber;
        CreateAction();

    }
    public void CreateAction()
    {
        if(node.type == 3)
        {
            GameObject actionDrinkGO = (GameObject)Instantiate(actionDrinkPrefab, transform.position, transform.rotation);
            actionDrinkGO.transform.parent = GameObject.FindGameObjectWithTag("Actions").transform;
            ActionDrink actionDrink = actionDrinkGO.GetComponent<ActionDrink>();
            actionDrink.SetPlayerStartValues(this, node, node.type);
        }
        else if (node.type == 4)
        {
            GameObject actionDesideSimpleGO = (GameObject)Instantiate(actionDesideSimplePrefab, transform.position, transform.rotation);
            actionDesideSimpleGO.transform.parent = GameObject.FindGameObjectWithTag("Actions").transform;
            ActionDesideSimple actionDesideSimple = actionDesideSimpleGO.GetComponent<ActionDesideSimple>();
            actionDesideSimple.SetPlayerStartValues(this, node, node.type);
        }
        else if (node.type == 5)
        {
            GameObject actionDesideSimpleGO = (GameObject)Instantiate(actionDesideSimplePrefab, transform.position, transform.rotation);
            actionDesideSimpleGO.transform.parent = GameObject.FindGameObjectWithTag("Actions").transform;
            ActionDesideSimple actionDesideSimple = actionDesideSimpleGO.GetComponent<ActionDesideSimple>();
            actionDesideSimple.SetPlayerStartValues(this, node, node.type);
        }
    }
    public void SetPlayerStartValues(string name, int position, int type, Node node, int number)
    {
        this.position = position;
        this.type = type;
        this.name = name;
        this.number = number;

        this.node = node;

        colorRenderer = this.GetComponent<Renderer>();
        if (type == 1)
        {
            colorRenderer.material.SetColor("_Color", Color.red);
        }
        else if (type == 2)
        {
            colorRenderer.material.SetColor("_Color", Color.green);
        }
        else if (type == 3)
        {
            colorRenderer.material.SetColor("_Color", Color.blue);
        }
    }
    public void SetColor(Color color)
    {
        colorRenderer.material.SetColor("_Color", color);
    }
    public void SetNode(Node node)
    {
        this.node = node;
    }
}
