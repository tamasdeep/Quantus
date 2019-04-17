using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);
            hit.gameObject.GetComponent<PlayerController>().health = hit.gameObject.GetComponent<PlayerController>().health - 3;
            explosion.transform.localScale = new Vector3(.1f, .1f, .1f);
            Instantiate(explosion, hit.transform.position, hit.transform.rotation);
            if (hit.gameObject.GetComponent<PlayerController>().health <= 0)
            {
                Destroy(hit.gameObject);
                explosion.transform.localScale = new Vector3(2, 2, 2);
                Instantiate(explosion, hit.transform.position, hit.transform.rotation);
            }
        }
    }
}
