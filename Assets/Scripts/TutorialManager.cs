using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    [SerializeField]private int popUpIndex;
    [SerializeField] private SlimeTarget slimeTutorial;

    private void Start()
    {
        slimeTutorial = slimeTutorial.GetComponent<SlimeTarget>();
    }


    private void Update()
    {
        for (int i = 0; i <  popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }

        if(popUpIndex == 0)
        {
            popUps[popUpIndex].SetActive(true);
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 1)
        {
            popUps[popUpIndex].SetActive(true);
            popUps[popUpIndex - 1].SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 2)
        {
            popUps[popUpIndex - 1].SetActive(false);
            if (slimeTutorial.charmed)
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;
            }
        }
    }

    /*

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        { }
    }

    */
}
