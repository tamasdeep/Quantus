using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2Script : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        //Debug.Log(hit.transform.gameObject.name);
        if (hit.transform.gameObject.name.Equals("Player"))
        {
            //Debug.Log("player hit");
        }
    }
}
