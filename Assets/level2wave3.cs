using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2wave3 : MonoBehaviour
{
    public Transform[] sp;
    public GameObject hazard;
    private List<GameObject> hazards;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        hazards = new List<GameObject>();
        // Keep a note of the time the movement started.
        startTime = Time.time;

        

        hazard = Instantiate(hazard, sp[0].transform.position, sp[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;


        int i = 0;
        while (i < sp.Length)
        {
            if (i == sp.Length - 1)
            {
                if (hazard.transform.position == sp[0].transform.position)
                {
                    i++;
                }
                // Calculate the journey length.
                journeyLength = Vector3.Distance(hazard.transform.position, sp[0].transform.position);
                // Fraction of journey completed = current distance divided by total distance.
                float fracJourney = distCovered / journeyLength;
                hazard.transform.position = Vector2.MoveTowards(hazard.transform.position, sp[0].transform.position, speed * Time.deltaTime);
            }
            else
            {
                Debug.Log(sp[i + 1].transform.position+ "updatin" + hazard.transform.position);
                // Calculate the journey length.
                journeyLength = Vector3.Distance(hazard.transform.position, sp[i+1].transform.position);
                // Fraction of journey completed = current distance divided by total distance.
                float fracJourney = distCovered / journeyLength;
                hazard.transform.position = Vector2.MoveTowards(hazard.transform.position, sp[i+1].transform.position, speed * Time.deltaTime);
                if (hazard.transform.position == sp[i + 1].transform.position)
                {
                    i++;
                }
            }

        }
    }

}
