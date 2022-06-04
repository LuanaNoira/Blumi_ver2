using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clue : MonoBehaviour
{
    public GameObject dialogueKey;
    public KeyCode DialogueInput = KeyCode.E;
    [SerializeField] private bool isInRange = false;
    private int countKey = 0;
    public string popUp;

    private void Update()
    {
        //if((isInRange == true) && Input.GetKeyDown(DialogueInput))
        if(Input.GetKeyDown(DialogueInput))
        {
            countKey++;
            if(isInRange)
            {
                ShowPopUp();
            }
            else if(countKey >= 1)
            {
                DontShowPopUp();
                countKey = 0;
            }
        }
    }

    public void ShowPopUp()
    {
        dialogueKey.SetActive(false);
        ClueMenu pop = GameObject.FindGameObjectWithTag("PopUp").GetComponent<ClueMenu>();
        pop.PopUp(popUp);
    }

    public void DontShowPopUp()
    {
        dialogueKey.SetActive(false);
        isInRange = false;
        ClueMenu pop = GameObject.FindGameObjectWithTag("PopUp").GetComponent<ClueMenu>();
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
        DontShowPopUp();
    }
}
