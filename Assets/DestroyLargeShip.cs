using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLargeShip : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponentsInChildren<enemyshipscript>().Length == 0)
        {
            explosion.transform.localScale = new Vector3(2f, 2f, 2f);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
