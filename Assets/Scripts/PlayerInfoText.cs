using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoText : MonoBehaviour
{
    private Player player;
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = player.name + " : " + player.shots.ToString();
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

}
