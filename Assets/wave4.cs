using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave4 : MonoBehaviour
{
    public GameObject hazard;
    public Transform spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int wave_count;
    public GameObject next;

    void Start()
    {
        hazard.AddComponent<Rigidbody2D>();
        hazard.GetComponent<Rigidbody2D>().isKinematic = false;
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (wave_count == 0 && next != null)
        {
            next.gameObject.GetComponent<Wave2>().enabled = true;
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (wave_count != 0)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-7, 7), spawnValues.position.y - 2);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            wave_count--;
        }
    }
}
