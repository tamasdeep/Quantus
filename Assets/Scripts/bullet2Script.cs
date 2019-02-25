using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2Script : MonoBehaviour
{
    public float speed = 100;
    private float timer = 0;
    public GameObject gunlocation;
    
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(gunlocation.transform.position.x, gunlocation.transform.position.y, gunlocation.transform.position.z);
        //transform.rotation = gunlocation.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(gunlocation.transform.position.x, gunlocation.transform.position.y, gunlocation.transform.position.z);
        //transform.rotation = gunlocation.transform.rotation;
        timer = timer + Time.deltaTime * speed;
        if (transform.localScale.z < 2.5)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + timer);
        }

        Debug.Log("transform:"+ transform.position + "time"+ Time.deltaTime);
    }
}
