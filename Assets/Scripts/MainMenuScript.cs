using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Play(int sceneID)
    {
        SceneManager.LoadScene("Planicie");
    }

    public void Quit(int sceneID)
    {
        Application.Quit();
    }

}
