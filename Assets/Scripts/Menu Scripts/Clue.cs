using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clue : MonoBehaviour
{
    public GameObject dialogueKey;
    public KeyCode DialogueInput = KeyCode.E;
    [SerializeField] private bool isInRange = false;
    [SerializeField] private bool isShowing = false;
    
    [TextArea(3,15)]
    public string popUp;

    private void Update()
    {
        if(Input.GetKeyDown(DialogueInput))
        {
            if(isInRange && (isShowing == false))
            {
                ShowPopUp();
                isShowing = true;
            }
            else if(isInRange && isShowing)
            {
                DontShowPopUp();
                dialogueKey.SetActive(true);
            }
            else if(isInRange == false)
            {
                DontShowPopUp();
                isInRange = false;
            }
        }
    }

    public void ShowPopUp()
    {
        dialogueKey.SetActive(false);
        ClueMenu pop = GameObject.Find("TextBox").GetComponent<ClueMenu>();
        pop.PopUp(popUp);
    }

    public void DontShowPopUp()
    {
        isShowing = false;
        ClueMenu pop = GameObject.Find("TextBox").GetComponent<ClueMenu>();
        pop.ExitPopUp(popUp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
            dialogueKey.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DontShowPopUp();
            dialogueKey.SetActive(false);
            isInRange = false;
        }
    }
}
