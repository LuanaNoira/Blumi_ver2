using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;

    private void Start()
    {
        audiosource = FindObjectOfType<AudioSource>().GetComponent<AudioSource>();
    }

    public void Play(int sceneID)
    {
        SceneManager.LoadScene("Planicie");

        audiosource.PlayOneShot(audiosource.clip);
    }

    public void Quit(int sceneID)
    {
        audiosource.PlayOneShot(audiosource.clip);

        Application.Quit();
    }

}
