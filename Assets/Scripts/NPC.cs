using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour
{

    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private Dialogue dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        //FindObjectOfType<Dialogue>().OutOfRange();
        //this.gameObject.GetComponent<NPC>().enabled = false;
        dialogueSystem = FindObjectOfType<Dialogue>();
    }

    void Update()
    {
        //Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        //ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        if (other.gameObject.tag == "Interact")
        {
            FindObjectOfType<Dialogue>().EnterRangeOfNPC();
            if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                FindObjectOfType<Dialogue>().NPCName();
            }
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<Dialogue>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}

