using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PAUSEMENU : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameisPaused)
            {
                Resume();

            }else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f;
        GameisPaused = false;
        Cursor.visible = false;
        Debug.Log("Ta a clicar!");
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("ta a clicar");
    }
}

