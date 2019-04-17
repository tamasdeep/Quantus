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
    public float health;
    public float myscore;
    public GameObject shot1;
    public GameObject shot2;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    bool weaponSwitch = false;
    public AudioClip bullet1;
    public AudioClip bullet2;
    private AudioSource audioSource;
    void Start()
    {
        Cursor.visible = false;
        myscore = 0;
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            weaponSwitch = !weaponSwitch;
        }
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (!weaponSwitch)
            {
                Instantiate(shot1, shotSpawn.position, shotSpawn.rotation);
                audioSource.PlayOneShot(bullet1);
            }
            else
            {
                Instantiate(shot2, shotSpawn.position, shotSpawn.rotation);
                audioSource.PlayOneShot(bullet2);
            }
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
