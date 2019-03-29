using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2wave2 : MonoBehaviour
{
    public Transform spstart;
    public Transform spend;
    public GameObject hazard;
    private List<GameObject> hazards;
    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        hazards = new List<GameObject>();
        InvokeRepeating("wave2", .1f, 1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 changeposition = new Vector3(spend.transform.position.x, spend.transform.position.y - 10.0f, spend.transform.position.z);
        spend.transform.position = Vector2.MoveTowards(spend.transform.position, changeposition, speed * Time.deltaTime / 5);
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;
        foreach(GameObject h in hazards)
        {
            h.transform.position = Vector2.Lerp(spstart.transform.position, spend.transform.position, fracJourney);
        }
        
    }

    void wave2()
    {
        if (hazards.Count == 3) return;
            // Keep a note of the time the movement started.
            startTime = Time.time;

            // Calculate the journey length.
            journeyLength = Vector3.Distance(spstart.position, spend.position);

            hazards.Add(Instantiate(hazard, spstart.position, spstart.rotation));
    }
    
}
