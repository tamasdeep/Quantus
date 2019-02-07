using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    public float speed = 10.0f;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

      
        rigidbody2D.velocity = new Vector2(horiz*speed, verti*speed);

        Mathf.Clamp(rigidbody2D.transform.position.x, boundary.xMin, boundary.xMax);
        

        //transform.Rotate(0.0f, 0.0f, -mouseY*speed);

        //GetComponent<Rigidbody>().velocity = new Vector2(horiz, verti);
    }
}
