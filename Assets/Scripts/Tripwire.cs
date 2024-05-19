using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripwire : MonoBehaviour
{
    public ArrowShooter shooter;

    void OnTriggerEnter2D(Collider2D col)
    {
        shooter.shootArrows();
    }
}
