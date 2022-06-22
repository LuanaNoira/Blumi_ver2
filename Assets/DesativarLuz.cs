using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativarLuz : MonoBehaviour
{
    public DayNightCycle horario;
    [SerializeField] private GameObject luz;
    [SerializeField] private Material[] material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

        horario = horario.GetComponent<DayNightCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        if(horario.dayTime)
        {
            luz.SetActive(false);
            rend.sharedMaterial = material[0];
        }
        else
        {
            luz.SetActive(true);
            rend.sharedMaterial = material[1];
        }
    }
}
