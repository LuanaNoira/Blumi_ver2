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

    PAUSEMENU pMenu;
    [SerializeField] private GameObject abilityUI;

    [TextArea(3,15)]
    public string popUp;

    public void Start()
    {
        pMenu = GameObject.Find("PauseMenu").GetComponent<PAUSEMENU>();
        this.gameObject.GetComponent<Clue>().enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(DialogueInput))
        {
            if (isInRange && (isShowing == false))
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

        //no caso de apertar ESCAPE
        if (pMenu.GameisPaused)
        {
            if(isInRange && isShowing)
            {
                DontShowPopUp();
                abilityUI.SetActive(false);
            }
            else if(isInRange && isShowing == false)
            {
                dialogueKey.SetActive(false);
            }
        }
        else
        {
            if(isInRange && isShowing == false)
            {
                dialogueKey.SetActive(true);
            }
        }
    }

    public void ShowPopUp()
    {
        dialogueKey.SetActive(false);
        ClueMenu pop = GameObject.FindGameObjectWithTag("PopUp").GetComponent<ClueMenu>();
        pop.PopUp(popUp);
        abilityUI.SetActive(false);
    }

    public void DontShowPopUp()
    {
        isShowing = false;
        ClueMenu pop = GameObject.FindGameObjectWithTag("PopUp").GetComponent<ClueMenu>();
        pop.ExitPopUp(popUp);
        abilityUI.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
            dialogueKey.SetActive(true);
            this.gameObject.GetComponent<Clue>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DontShowPopUp();
            dialogueKey.SetActive(false);
            isInRange = false;
            this.gameObject.GetComponent<Clue>().enabled = false;
        }
    }
}
