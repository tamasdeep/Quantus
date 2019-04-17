using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winner : MonoBehaviour
{
    public GameObject winnerpanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponentsInChildren<DestroyLargeShip>().Length == 0)
        {
            winnerpanel.SetActive(true);
        }
    }
}
