using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public GameObject heathcurve;
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        
        //gameObject.SetActive(false);
    }
    void Start()
    {
        //heathcurve.gameObject.GetComponent<SplineWalker>().walker.SetActive(false);
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("less than 19 update");
        if (player.gameObject.GetComponent<PlayerController>().health <= 19)
        {
            Debug.Log("less than 19");
            heathcurve.gameObject.GetComponent<SplineWalker>().walker.SetActive(true);
        }
        else
        {
            heathcurve.gameObject.GetComponent<SplineWalker>().walker.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        //Debug.Log(hit.transform.gameObject.name);
        if (hit.transform.gameObject.name.Equals("Player"))
        {
            heathcurve.gameObject.GetComponent<SplineWalker>().walker.SetActive(false);
            if(hit.gameObject.GetComponent<PlayerController>().health >= 100 - 35)
            {
                hit.gameObject.GetComponent<PlayerController>().health = 100;
            }
            else
            {
                hit.gameObject.GetComponent<PlayerController>().health = hit.gameObject.GetComponent<PlayerController>().health + 35;
            }
                
        }
    }
}
