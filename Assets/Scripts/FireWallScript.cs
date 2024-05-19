using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallScript : MonoBehaviour
{
    [SerializeField] PlayerMovement playerScript;

    private bool inWall;
    private bool lit;

    [SerializeField] GameObject flames;

    float maxTimeLive = 2f;
    float timeLive = 0f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(lit)
            {
                playerScript.die();
            }
            inWall = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        inWall = false;
    }

    public void ShootFlames()
    {
        //Play fire script

        flames.SetActive(true);

        if(inWall)
        {
            playerScript.die();
        }
    }

    private void Update()
    {
        if(lit)
        {
            if(timeLive >= maxTimeLive)
            {
                lit = false;
                timeLive = 0f;
                flames.SetActive(false);
            }
            else
            {
                timeLive += Time.deltaTime;
            }
        }
        
    }
}
