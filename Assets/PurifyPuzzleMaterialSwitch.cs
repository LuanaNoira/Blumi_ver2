using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurifyPuzzleMaterialSwitch : MonoBehaviour
{
    [SerializeField] GameObject masterPurifyPuzzle;

    [SerializeField] private Material[] material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(masterPurifyPuzzle.GetComponent<PurifyPuzzle>().purifyPuzzleDone)
            rend.sharedMaterial = material[1];
    }
}
