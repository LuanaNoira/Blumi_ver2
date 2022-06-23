using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClueMenu : MonoBehaviour
{
    public GameObject popUpBox;
    [SerializeField] private TMP_Text popUpText;

    [SerializeField] private AudioSource audiosource;

    private void Start()
    {
        popUpBox.SetActive(false);
        popUpText.text = null;

        audiosource = FindObjectOfType<AudioSource>().GetComponent<AudioSource>();
    }
    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;

        audiosource.PlayOneShot(audiosource.clip);
    }

    public void ExitPopUp(string text)
    {
        popUpBox.SetActive(false);
        popUpText.text = null;
    }
}
