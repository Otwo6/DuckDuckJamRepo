using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTile : MonoBehaviour
{
    public float delayTimeMax = 20f;
    float delayTime = 0f;
    bool tripped = false;

    [SerializeField] FireWallScript fireWall;

    private void Update()
    {
        if(tripped)
        {
            delayTime += Time.deltaTime;
            if(delayTime >= delayTimeMax)
            {
                print("You just got FIRED L");
                tripped = false;
                delayTime = 0f;
                fireWall.ShootFlames();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("click");
        tripped = true;
    }
}
