using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float theScrollSpeed = 0.025f;
    public GameObject hazard;
    public Transform spawnValues;
    Transform theCamera;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int wave_count;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (wave_count != 0)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-7, 7), spawnValues.position.y-2);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            wave_count--;
        }
    }
}
