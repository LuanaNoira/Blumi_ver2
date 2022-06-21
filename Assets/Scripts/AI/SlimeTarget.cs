using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeTarget : MonoBehaviour
{
    public bool charmed = false;
    public bool levitate = false;
    public bool bait = false;
    public bool sound = false;
    public bool invisibility = false;
    public bool water = false;
    public bool stun = false;
    public bool teleport = false;
    public bool purify = false;

    private void Start()
    {
        
    }

    public void Charmed()
    {
        charmed = true;
    }

    public void Levitate()
    {

    }

    public void Bait()
    {

    }

    public void Sound()
    {
        sound = true;
    }

    public void Invisibility()
    {

    }

    public void Water()
    {
        water = true;
    }

    public void Stun()
    {
        stun = true;
    }

    public void Teleport()
    {

    }

    public void Purify()
    {
        purify = true;
    }
}
