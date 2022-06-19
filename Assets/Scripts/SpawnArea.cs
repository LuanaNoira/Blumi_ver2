using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public GameObject slimeSpawned;

    public DayNightCycle horario;
    [SerializeField] private bool sliFoca = false;
    [SerializeField] private bool sliPesadelo = false;
    [SerializeField] private bool sliSpawnedAnyTime = false;

    private int xPos;
    [SerializeField] private int xPosMin;
    [SerializeField] private int xPosMax;

    private int zPos;
    [SerializeField] private int zPosMin;
    [SerializeField] private int zPosMax;

    [SerializeField] private int yPos;

    public int slimeCount;
    [SerializeField] private int slimeNumberArea;

    public void Start()
    {
        horario = horario.GetComponent<DayNightCycle>();
        CheckSlime();
        //StartCoroutine(SlimeSpawner());
    }

    public void Update()
    {
        StartCoroutine(SlimeSpawner());
    }

    private void CheckSlime()
    {
        if (slimeSpawned.CompareTag("SliPesadelo"))
        {
            sliPesadelo = true;
        }
        if(slimeSpawned.CompareTag("SliFoca"))
        {
            sliFoca = true;
        }
        if(sliFoca == false && sliPesadelo == false)
        {
            sliSpawnedAnyTime = true;
        }
    }

    IEnumerator SlimeSpawner()
    {
        //SLIME PESADELO
        if(sliPesadelo && (horario.dayTime == false))
        {
            while (slimeCount < slimeNumberArea)
            {
                xPos = Random.Range(xPosMin, xPosMax);
                zPos = Random.Range(zPosMin, zPosMax);
                Instantiate(slimeSpawned, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                slimeCount += 1;
            }
        }
        /*
        else if(sliPesadelo && horario.dayTime)
        {
            Destroy(slimeSpawned);
        } */

        //SLIME FOCA
        if(sliFoca && horario.dayTime)
        {
            while (slimeCount < slimeNumberArea)
            {
                xPos = Random.Range(xPosMin, xPosMax);
                zPos = Random.Range(zPosMin, zPosMax);
                Instantiate(slimeSpawned, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                slimeCount += 1;
            }
        }

        //SLIME QUE APARECEM SEMPRE
        if(sliSpawnedAnyTime)
        {
            while (slimeCount < slimeNumberArea)
            {
                xPos = Random.Range(xPosMin, xPosMax);
                zPos = Random.Range(zPosMin, zPosMax);
                Instantiate(slimeSpawned, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                slimeCount += 1;
            }
        } 
    }
}
