using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PAUSEMENU : MonoBehaviour
{
    public bool GameisPaused = false;
    public GameObject pauseMenu;

    public static bool slimeLogOn = false;

    [SerializeField] private GameObject magicSwitch;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject abilityUI;
    [SerializeField] private GameObject slimeLog;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameisPaused)
            {
                Resume();
            }
            else if(slimeLogOn)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (slimeLogOn)
        {
            SlimeLog();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f;
        GameisPaused = false;
        Cursor.visible = false;
        magicSwitch.SetActive(true);
        abilityUI.SetActive(true);
        crosshair.SetActive(true);
        slimeLogOn = false;
        slimeLog.SetActive(false);
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        Cursor.visible = true;
        magicSwitch.SetActive(false);
        abilityUI.SetActive(false);
        crosshair.SetActive(false);
    }

    public void SlimeLog()
    {
        slimeLogOn = true;
        slimeLog.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void QuitSlimeLog()
    {
        slimeLogOn = false;
        slimeLog.SetActive(false);
        Pause();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("ta a clicar");
    }
}

