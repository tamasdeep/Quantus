using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid : MonoBehaviour
{
    public GameObject explosion;
    public GameObject player;
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
            hit.gameObject.GetComponent<PlayerController>().health = hit.gameObject.GetComponent<PlayerController>().health - 25;
            explosion.transform.localScale = new Vector3(.2f, .2f, .2f);
            Instantiate(explosion, hit.transform.position, hit.transform.rotation);
            if (hit.gameObject.GetComponent<PlayerController>().health <= 0)
            {
                Destroy(hit.gameObject);
                explosion.transform.localScale = new Vector3(2, 2, 2);
                Instantiate(explosion, hit.transform.position, hit.transform.rotation);
            }

        }
        if (hit.transform.gameObject.tag.Equals("Bullet"))
        {
            player.gameObject.GetComponent<PlayerController>().myscore = player.gameObject.GetComponent<PlayerController>().myscore + 10;
            explosion.transform.localScale = new Vector3(.1f, .1f, .1f);
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
