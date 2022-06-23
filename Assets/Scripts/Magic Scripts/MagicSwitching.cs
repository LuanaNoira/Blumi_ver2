using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSwitching : MonoBehaviour
{
    public int selectedMagic = 0;

    public AbilityUI ui;

    public bool mInvisibility = false;
    public bool mWater = false;
    public bool mPurification = false;
    public bool mTeleport = false;
    public bool mStun = false;
    public bool mSound = false;

    public bool levitateCheck = false;

    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("AbilityUI").GetComponent<AbilityUI>();

        SelectMagic();
        ui.setMagicImage(0);
    }

    
    void Update()
    {
        int previousSelectedMagic = selectedMagic;
        /*
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
        */

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedMagic = 0;
            levitateCheck = false;
        } 

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedMagic = 1;
            levitateCheck = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedMagic = 2;
            levitateCheck = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && (transform.childCount >= 4) && mSound)
        {
            selectedMagic = 3;
            levitateCheck = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && (transform.childCount >= 5) && mStun)
        {
            selectedMagic = 4;
            levitateCheck = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && (transform.childCount >= 6) && mInvisibility)
        {
            selectedMagic = 5;
            levitateCheck = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7) && (transform.childCount >= 7) && mWater)
        {
            selectedMagic = 6;
            levitateCheck = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8) && (transform.childCount >= 8) && mPurification)
        {
            selectedMagic = 7;
            levitateCheck = false;
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
            {
                magic.gameObject.SetActive(true);
                ui.setMagicImage(i);
            }
            else
                magic.gameObject.SetActive(false);
            i++;
        }
    }
}
