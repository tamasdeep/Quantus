using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Text>().text.Contains("Score"))
        {
            GetComponent<Text>().text = "Score: " + player.GetComponent<PlayerController>().myscore;
        }
    }
}
