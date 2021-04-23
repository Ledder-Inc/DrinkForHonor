using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int position;
    public int type;

    private Renderer colorRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNodeStartValuse(string name, int position, int type)
    {
        this.position = position;
        this.type = type;
        this.name = name;

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
        else if (type == 4)
        {
            colorRenderer.material.SetColor("_Color", Color.yellow);
        }
        else if (type == 5)
        {
            colorRenderer.material.SetColor("_Color", Color.black);
        }
    }

    public void SetColor(Color color)
    {
        colorRenderer.material.SetColor("_Color", color);
    }
}
