using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public GameObject slimeSpawned;

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
        StartCoroutine(SlimeSpawner());
    }

    IEnumerator SlimeSpawner()
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
