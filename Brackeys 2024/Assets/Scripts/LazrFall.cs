using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazrFall : StationaryObstacle
{
    public float speedMax;
    public float speedMin;
    private void Start()
    {
        fallSpeed = Random.Range(speedMin, speedMax);
    }
}
