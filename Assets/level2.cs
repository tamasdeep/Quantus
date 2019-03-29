using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2 : MonoBehaviour
{
    public GameObject hazard;
    public Transform[] wspawnValues;
    private List<GameObject> hazards;
    private int hazardCount;
    public float startWait;
    public float waveWait;
    private int wave_count;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        hazards = new List<GameObject>();
        Wave1Init();
    }

    // Update is called once per frame
    void Update()
    {
        Wave1();
    }

    void Wave1Init()
    {
        foreach (Transform spawnpoint in wspawnValues)
        {
            Debug.Log(spawnpoint.position.ToString());
            hazards.Add(Instantiate(hazard, spawnpoint.position, spawnpoint.rotation));
        }
    }

    void Wave1()
    {
        float step = speed * Time.deltaTime;

        for (int i = 0; i < wspawnValues.Length; i++)
        {
            Vector3 changeposition = new Vector3(wspawnValues[i].transform.position.x, wspawnValues[i].transform.position.y - 0.1f, wspawnValues[i].transform.position.z);
            wspawnValues[i].transform.position = Vector2.MoveTowards(wspawnValues[i].transform.position, changeposition, step/10);
        }

        for (int i = 0; i < wspawnValues.Length; i++)
        {
            if (i == wspawnValues.Length - 1)
            {
                hazards[i].transform.position = Vector2.MoveTowards(hazards[i].transform.position, wspawnValues[0].position, speed * Time.deltaTime);
            }
            else
            {
                hazards[i].transform.position = Vector2.MoveTowards(hazards[i].transform.position, wspawnValues[i + 1].position, speed * Time.deltaTime);
            }
        }
    }
}
