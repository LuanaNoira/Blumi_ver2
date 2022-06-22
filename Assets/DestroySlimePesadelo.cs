using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySlimePesadelo : MonoBehaviour
{
    [SerializeField] GameObject sPesadelo;

    public void DestroyPesadelo()
    {
        Destroy(sPesadelo);
    }
}
