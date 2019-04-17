using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level3 : MonoBehaviour
{
    public GameObject[] waves;
    public Text LevelHeading;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowMessage(LevelHeading, "Level 3", 5));
        StartCoroutine("startwaves");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startwaves()
    {
        foreach (GameObject w in waves)
        {
            w.SetActive(true);
            yield return new WaitForSeconds(20f);
        }
    }

    IEnumerator ShowMessage(Text guiText, string message, float delay)
    {
        guiText.text = message;
        guiText.enabled = true;
        yield return new WaitForSeconds(delay);
        guiText.enabled = false;
    }
}
 