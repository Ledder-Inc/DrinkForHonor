using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public Text cubeButtonText;

    public GameObject gameMaster;
    private GameObject playerOnTurn;

    public int rollNumber;

    public void Roll()
    {
        rollNumber = UnityEngine.Random.Range(1, 6);
        cubeButtonText.text = rollNumber.ToString();
        playerOnTurn = gameMaster.GetComponent<GameMaster>().playerOnTurn;
        Player player = playerOnTurn.GetComponent<Player>();
        player.Move(rollNumber);
        //SetInaktiv();

    }

    public void SetInaktiv()
    {
        //gameObject.SetActive(false);
        this.enabled = false;
    }

    public void SetAktiv()
    {
        //gameObject.SetActive(true);
        this.enabled = true;
    }

    
}
