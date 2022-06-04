using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSwitching : MonoBehaviour
{
    public int selectedMagic = 0;

    void Start()
    {
        SelectMagic();
    }

    
    void Update()
    {
        int previousSelectedMagic = selectedMagic;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedMagic >= transform.childCount - 1)
                selectedMagic = 0;
            else
                selectedMagic++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedMagic <= 0)
                selectedMagic = transform.childCount - 1;
            else
                selectedMagic--;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedMagic = 0;
        } 

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedMagic = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedMagic = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedMagic = 3;
        }

        if (previousSelectedMagic != selectedMagic)
        {
            SelectMagic();
        }
    }

    void SelectMagic()
    {
        int i = 0;
        foreach (Transform magic in transform)
        {
            if (i == selectedMagic)
                magic.gameObject.SetActive(true);
            else
                magic.gameObject.SetActive(false);
            i++;
        }
    }
}
