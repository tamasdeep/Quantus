using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2 : MonoBehaviour
{
    public GameObject hazard;
    //public GameObject bighazard;
    public Transform[] spawnValues;
    public Transform[] bigspawnValues;
    Transform theCamera;
    private int hazardCount;
    public float startWait;
    public float waveWait;
    private int wave_count;
    public GameObject[] next;

    void Start()
    {
        hazardCount = spawnValues.Length;
        hazard.GetComponent<Rigidbody2D>().isKinematic = false;
        StartCoroutine(SpawnWaves1());
    }

    void Update()
    {

            
        
    }
    IEnumerator SpawnWaves1()
    {
        wave_count = 2 * spawnValues.Length;
        yield return new WaitForSeconds(startWait);
        while (wave_count != 0)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValues[i].position.x - wave_count, spawnValues[i].position.y);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
            }
            yield return new WaitForSeconds(waveWait);
            wave_count--;
        }
        StartCoroutine(SpawnWaves2());
    }
    IEnumerator SpawnWaves2()
    {

        wave_count = 0;
        yield return new WaitForSeconds(startWait);
        while (wave_count != 2 * spawnValues.Length)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValues[i].position.x - wave_count, spawnValues[i].position.y);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
            }
            yield return new WaitForSeconds(waveWait);
            wave_count++;
        }
        yield return new WaitForSeconds(5);
        foreach (GameObject n in next)
        {
            n.gameObject.GetComponent<Wave3>().enabled = true;
            yield return new WaitForSeconds(2);
        }
        
    }

}
