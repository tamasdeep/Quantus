using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3wave2 : MonoBehaviour
{
    public GameObject[] enemy;
    // Start is called before the first frame update
    void Start()
    {
       foreach(GameObject e in enemy)
        {
            e.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
