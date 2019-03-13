using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadCredits(GameObject panel)
    {
        mainmenu.SetActive(false);
        panel.SetActive(true);
    }

    public void UnLoadCredits(GameObject panel)
    {
        mainmenu.SetActive(true);
        panel.SetActive(false);
    }

    public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit ();
    #endif
    }
}
