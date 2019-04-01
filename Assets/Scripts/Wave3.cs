using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3 : MonoBehaviour
{
    public GameObject hazard;
    private List<GameObject> hazards;
    public Transform[] spawnValues;
    public Transform target;
    Transform theCamera;
    private int hazardCount;
    public float startWait;
    public float waveWait;
    public int wave_count;
    public GameObject[] next;

    void Start()
    {
        hazards = new List<GameObject>();
        hazard.GetComponent<Rigidbody2D>().isKinematic = true;
        hazardCount = spawnValues.Length;
        StartCoroutine(SpawnWaves1());
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        foreach (GameObject h in hazards)
        {
            Vector2 velocity = new Vector2(1.75f, 1.1f);
            if (h != null && target != null) h.GetComponent<Rigidbody2D>().MovePosition(h.transform.position + (target.position - h.transform.position).normalized * Time.fixedDeltaTime * 5);
            if(target == null && h!=null) {
                h.transform.position = new Vector3(h.transform.position.x, h.transform.position.y, -2.0f);
                h.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
    IEnumerator SpawnWaves1()
    {
        while (wave_count != 0)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValues[i].position.x, spawnValues[i].position.y);
                Quaternion spawnRotation = Quaternion.identity;
                hazards.Add(Instantiate(hazard, spawnPosition, spawnRotation));
            }
            yield return new WaitForSeconds(waveWait);
            wave_count--;
        }
        foreach (GameObject n in next)
        {
            n.gameObject.GetComponent<level2wave2>().enabled = true;
            yield return new WaitForSeconds(10);
        }
    }
}
