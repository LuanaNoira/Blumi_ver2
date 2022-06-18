using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClueMenu : MonoBehaviour
{
    public GameObject popUpBox;
    [SerializeField] private TMP_Text popUpText;

    private void Start()
    {
        popUpBox.SetActive(false);
        popUpText.text = null;
    }
    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
    }

    public void ExitPopUp(string text)
    {
        popUpBox.SetActive(false);
        popUpText.text = null;
    }
}
