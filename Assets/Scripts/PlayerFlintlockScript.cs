using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlintlockScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    PlayerMovement playerMove;
    // Update is called once per frame
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerMove = player.GetComponent<PlayerMovement>();
        }
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(playerMove.facingLeft)
            {
                Vector3 playerPos = transform.position;
                Vector3 bulletOffset = new Vector3(-1f, 0f, 0f); // Adjust as needed
                GameObject bullet = Instantiate(bulletPrefab, playerPos + bulletOffset, Quaternion.Euler(0, 0, 0));
                bullet.GetComponent<BulletScript>().arrowSpeed *= -1;
                print("firerere");

            }
            else
            {
                Vector3 playerPos = transform.position;
                Vector3 bulletOffset = new Vector3(1f, 0f, 0f); // Adjust as needed
                GameObject bullet = Instantiate(bulletPrefab, playerPos + bulletOffset, Quaternion.Euler(0, 0, 0));
                print("firerere");
            }
        }
    }
}
