using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level2wave2 : MonoBehaviour
{
    public GameObject[] levels;
    private List<WavesControl[]> WavesControllevels;
    private List<SplineWalker[]> SplineWalkerlevels;
    public Text LevelHeading;
    private float nexttime;
    private int WavesControllevelsIndex = 0;
    private int SplineWalkerlevelsIndex = 0;
    public GameObject next;
    
    void Start()
    {
       
        StartCoroutine(ShowMessage(LevelHeading, "Level 2: Probabilitas", 5));
        WavesControllevels = new List<WavesControl[]>();
        SplineWalkerlevels = new List<SplineWalker[]>();
        foreach (GameObject l in levels)
        {
            WavesControllevels.Add(l.GetComponentsInChildren<WavesControl>(true));
            if(l.GetComponentsInChildren<SplineWalker>(true).Length != 0)
            {
                SplineWalkerlevels.Add(l.GetComponentsInChildren<SplineWalker>(true));
            }
            
        }
        nexttime = Time.time;
        Debug.Log("sarr " + SplineWalkerlevels.Count);

        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("wave spline index " + SplineWalkerlevelsIndex);
        Debug.Log(" nexttime is  " + nexttime + " check " + (Time.time == nexttime));
        Debug.Log(" time is  " + (int)Time.time + " check " + (Time.time == nexttime));
        if ((int)Time.time == (int)nexttime)
        {
            Debug.Log(" time is  " + nexttime + " check " + (Time.time == nexttime));
            if (WavesControllevelsIndex == WavesControllevels.Count-1)
            {
                foreach (WavesControl w in WavesControllevels[WavesControllevelsIndex - 1])
                {
                    w.enabled = false;
                    destroyprobes();
                }
                if (SplineWalkerlevelsIndex == SplineWalkerlevels.Count)
                {
                    foreach (SplineWalker s in SplineWalkerlevels[SplineWalkerlevelsIndex - 1])
                    {
                        destroyprobes();
                        s.enabled = false;
                        this.enabled = false;
                        if ((int)Time.time == (int)nexttime) { 
                            next.SetActive(true);
                        }
                    }
                }
                else
                {
                    if (SplineWalkerlevelsIndex == 0)
                    {
                        Debug.Log("wave enabling at 0 " + SplineWalkerlevelsIndex);
                        foreach (SplineWalker s in SplineWalkerlevels[SplineWalkerlevelsIndex])
                        {
                            s.enabled = true;
                        }
                        SplineWalkerlevelsIndex++;
                    }
                    else
                    {
                        Debug.Log("wave enabling not at 0 " + SplineWalkerlevelsIndex);
                        foreach (SplineWalker s in SplineWalkerlevels[SplineWalkerlevelsIndex - 1])
                        {
                            s.enabled = false;
                            destroyprobes();
                        }
                        foreach (SplineWalker s in SplineWalkerlevels[SplineWalkerlevelsIndex])
                        {
                            s.enabled = true;
                        }
                        SplineWalkerlevelsIndex++;
                    }

                }
            }
            else
            {
                if (WavesControllevelsIndex == 0)
                {

                    foreach (WavesControl w in WavesControllevels[WavesControllevelsIndex])
                    {
                        w.enabled = true;
                    }
                }
                else
                {
                    Debug.Log("wave name next " + WavesControllevelsIndex);
                    foreach (WavesControl w in WavesControllevels[WavesControllevelsIndex - 1])
                    {
                        w.enabled = false;
                        destroyprobes();
                    }
                    foreach (WavesControl w in WavesControllevels[WavesControllevelsIndex])
                    {
                        w.enabled = true;
                    }
                }
                WavesControllevelsIndex++;
            }
            nexttime = Time.time + 10;

        }


    }
    
    void destroyprobes()
    {
        GameObject[] foundObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject gameObject in foundObjects)
        {
            if (gameObject.tag == "probe")
            {
                Destroy(gameObject);
            }
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
