using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radarscript : MonoBehaviour
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



    void OnTriggerStay2D(Collider2D hit)
    {
        Debug.Log(hit.gameObject.name +" entered");
        if (hit.gameObject.name.Equals("Player"))
        {
            Debug.Log("Player entered triggered");
            hit.gameObject.GetComponent<PlayerController>().health = hit.gameObject.GetComponent<PlayerController>().health - 0.1f;
            if (hit.gameObject.GetComponent<PlayerController>().health <= 0)
            {
                Destroy(hit.gameObject);
                explosion.transform.localScale = new Vector3(2, 2, 2);
                Instantiate(explosion, hit.transform.position, hit.transform.rotation);
            }
        }
    }
}
