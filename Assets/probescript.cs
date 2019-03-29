using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class probescript : MonoBehaviour
{
    public GameObject proberader;
    public GameObject green;
    private float timehit = 0.0f;
    private float repeattime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("updateprobe", 1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timehit+repeattime < Time.fixedTime)
        {
            if (!proberader.activeSelf)
            {
                proberader.SetActive(true);
                green.SetActive(false);
            }
        }
    }

    //void updateprobe()
    //{

    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Bullet2"))
        {
            Destroy(col.gameObject);
            proberader.SetActive(false);
            green.SetActive(true);
            timehit = Time.fixedTime;
        }
    }
}
