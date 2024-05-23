using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionKillScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" && col.gameObject.tag != "Swipe")
        {
            PlayerMovement playerScript = col.gameObject.GetComponent<PlayerMovement>();
            playerScript.die();
        }
    }
}
