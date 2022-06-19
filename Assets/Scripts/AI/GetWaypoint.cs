using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetWaypoint : MonoBehaviour
{
    [SerializeField] private GetPoint wPoint;

    public void Start()
    {
        wPoint = GetPoint.Instance;
        CheckWaypoint();
    }

    public void Update()
    {
        //CheckWaypoint();
    }

    public void CheckWaypoint()
    {
        if(wPoint.waypoint != wPoint)
        {
            wPoint.waypoint = wPoint;
        }
    }


}
