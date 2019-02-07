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

    void Start()
    {
        StartCoroutine(SpawnWaves());
        theCamera = Camera.main.transform;
    }

    void Update()
    {
        theCamera.position = new Vector3(theCamera.position.x, theCamera.position.y + theScrollSpeed, theCamera.position.z);
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-7, 7), spawnValues.position.y-2);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
