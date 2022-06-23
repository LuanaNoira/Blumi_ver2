using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PAUSEMENU : MonoBehaviour
{
    public bool GameisPaused = false;
    public GameObject pauseMenu;
    [SerializeField] GameObject levitate;

    public static bool slimeLogOn = false;

    [SerializeField] private GameObject magicSwitch;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject abilityUI;
    [SerializeField] private GameObject slimeLog;

    [SerializeField] private AudioSource audiosource;

    private int count = 0;

    private void Start()
    {
        audiosource = FindObjectOfType<AudioSource>().GetComponent<AudioSource>();
    }

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
            if (count == 0)
                audiosource.PlayOneShot(audiosource.clip);
            count++;
        }
        else if (slimeLogOn == false)
            count = 0;
    }

    public void Resume()
    {
        audiosource.PlayOneShot(audiosource.clip);
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f;
        GameisPaused = false;
        Cursor.visible = false;
        magicSwitch.SetActive(true);
        abilityUI.SetActive(true);
        crosshair.SetActive(true);
        slimeLogOn = false;
        slimeLog.SetActive(false);
        levitate.GetComponent<Levitate>().enabled = true;
    }

    void Pause()
    {
        audiosource.PlayOneShot(audiosource.clip);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        Cursor.visible = true;
        magicSwitch.SetActive(false);
        abilityUI.SetActive(false);
        crosshair.SetActive(false);
        levitate.GetComponent<Levitate>().enabled = false;
    }

    public void SlimeLog()
    {
        slimeLogOn = true;
        slimeLog.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void QuitSlimeLog()
    {
        audiosource.PlayOneShot(audiosource.clip);
        slimeLogOn = false;
        slimeLog.SetActive(false);
        Pause();
    }

    public void QuitGame()
    {
        audiosource.PlayOneShot(audiosource.clip);
        Application.Quit();
        Debug.Log("ta a clicar");
    }
}

