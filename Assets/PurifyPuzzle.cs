using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurifyPuzzle : MonoBehaviour
{
    [SerializeField] private int count = 0;
    [SerializeField] GameObject purifyReward;
    [SerializeField] private GameObject luz;
    public bool purifyPuzzleDone = false;

    void Update()
    {
        if (count >= 2)
        {
            purifyReward.GetComponent<MagicSwitching>().mPurification = true;
            luz.SetActive(true);
            purifyPuzzleDone = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Gordo"))
        {
            count++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Gordo"))
        {
            count--;
        }
    }
}
