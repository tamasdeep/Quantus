using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howtoplay : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowHowToPlay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void howtopl()
    {
        StartCoroutine(ShowHowToPlay());
    }

     IEnumerator ShowHowToPlay()
    {

        obj.SetActive(true);
        yield return new WaitForSeconds(5);
        obj.SetActive(false);
        Debug.Log("help trurned off");
    }
}
