using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionWinScript : MonoBehaviour
{
    public GameObject winScreen;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerMovement playerScript = col.gameObject.GetComponent<PlayerMovement>();
            playerScript.dead = true;
            playerScript.takingInput = false;
            winScreen.SetActive(true);
        }
    }
}
