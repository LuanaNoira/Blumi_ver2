using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLog : MonoBehaviour
{
    [SerializeField] private GameObject slimeLog;

    public bool sAzul = false;
    [SerializeField] private GameObject sAzulB;

    public bool sGalinha = false;
    [SerializeField] private GameObject sGalinhaB;

    public bool sFlor = false;
    [SerializeField] private GameObject sFlorB;

    public bool sBorboleta = false;
    [SerializeField] private GameObject sBorboletaB;

    public bool sFoca = false;
    [SerializeField] private GameObject sFocaB;

    public bool sPirata = false;
    [SerializeField] private GameObject sPirataB;

    public bool sPesadelo = false;
    [SerializeField] private GameObject sPesadeloB;

    // Update is called once per frame
    void Update()
    {
        if (sAzul)
            sAzulB.SetActive(false);

        if (sGalinha)
            sGalinhaB.SetActive(false);

        if (sFlor)
            sFlorB.SetActive(false);

        if (sBorboleta)
            sBorboletaB.SetActive(false);

        if (sFoca)
            sFocaB.SetActive(false);

        if (sPirata)
            sPirataB.SetActive(false);

        if (sPesadelo)
            sPesadeloB.SetActive(false);
    }
}
