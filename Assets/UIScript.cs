using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject player;
    public GameObject gameover;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerController>().myscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            
            gameover.SetActive(true);
            Cursor.visible = true;
        }
        if (GetComponent<Text>().text.Contains("Health") && player)
        {
            GetComponent<Text>().text = "Health: " + (int) player.GetComponent<PlayerController>().health;
        }

        if (GetComponent<Text>().text.Contains("Score"))
        {
            GetComponent<Text>().text = "Score: " + player.GetComponent<PlayerController>().myscore;
        }
    }
}
