using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public GameObject[] magicImage = new GameObject[8];

    void Start()
    {
        for (int i = 0; i < magicImage.Length; i++)
        {
            magicImage[i].GetComponent<Image>().color = new Color32(121, 126, 243, 255);
        }
        magicImage[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void setMagicImage(int e)
    {
        for (int i = 0; i < magicImage.Length; i++)
        {
            magicImage[i].GetComponent<Image>().color = new Color32(121, 126, 243, 255);
        }
        for (int i = 0; i < magicImage.Length; i++)
        {
            if(i == e)
            {
                magicImage[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }
}
