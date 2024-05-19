using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public Vector3 spawnLoc;

    public void shootArrows()
    {
        Instantiate(ArrowPrefab, spawnLoc, Quaternion.Euler(0,0,90));
    }
}
