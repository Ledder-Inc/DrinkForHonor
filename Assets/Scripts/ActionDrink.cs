using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionDrink : MonoBehaviour
{
    private Player player;
    private GameMaster gameMaster;
    private Cube cube;
    private Node node;
    private int type;
    private string text;
    public Text textDialog;
    private int shots;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        cube = GameObject.Find("Cube").GetComponent<Cube>();
        SetAction();
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, 150, 10);
            transform.rotation = Quaternion.identity;
        }
    }
    public void SetPlayerStartValues(Player player, Node node, int type)
    {
        this.player = player;
        this.node = node;
        this.type = type;
        this.name = "Action_" + player.name + "_" + node.name;
    }
    public void SetAction() //Methode für Action dieser Klasse
    {
        shots = UnityEngine.Random.Range(1, 6);
        shots = shots * gameMaster.roundMultiplicator;
        text = " trinkt ";
        text = player.name + text + shots.ToString() + " Schlücke.";
        textDialog.text = text;
    }
    public void GetActionAnwser(Button button)
    {
        if (button.name == "Drink")
        {
            player.shots += shots;
            gameMaster.SetNextPlayer();
            cube.SetAktiv();
            Destroy(gameObject);
        }
    }
}
