using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerexplosion;

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
            Destroy(hit.gameObject);
            playerexplosion.transform.localScale = new Vector3(2, 2, 2);
            Instantiate(playerexplosion, hit.transform.position, hit.transform.rotation);
        }
        if (hit.transform.gameObject.tag.Equals("Bullet"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(hit.gameObject);
        }
        if (hit.transform.gameObject.tag.Equals("bulletCatcher"))
        {
            Debug.Log("hit catcher");
            return;
        }
    }
}
