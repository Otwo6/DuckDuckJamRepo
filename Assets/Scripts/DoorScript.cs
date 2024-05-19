using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool trap = false;

    public GameObject closedDoor;
    public GameObject openDoor;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(trap)
            {
                PlayerMovement playerScript = col.gameObject.GetComponent<PlayerMovement>();
                playerScript.die();
            }
            else
            {
                print("Carry on");
                closedDoor.SetActive(false);
                openDoor.SetActive(true);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            closedDoor.SetActive(true);
            openDoor.SetActive(false);
        }
    }
}
