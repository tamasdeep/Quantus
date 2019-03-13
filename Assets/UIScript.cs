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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            player.GetComponent<PlayerController>().myscore = 0;
            gameover.SetActive(true);
        }
        if (GetComponent<Text>().text.Contains("Health") && player)
        {
            GetComponent<Text>().text = "Health: " + player.GetComponent<PlayerController>().health;
        }

        if (GetComponent<Text>().text.Contains("Score"))
        {
            GetComponent<Text>().text = "Score: " + player.GetComponent<PlayerController>().myscore;
        }
    }
}
