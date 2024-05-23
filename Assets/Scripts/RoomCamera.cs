using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour
{
    public enum enTime {Ruins, Medieval, Pirates};
    public GameObject virtualCam;
    PlayerMovement playerMove;
    
    public GameObject[] enemies;
    public Vector3[] enemyLocation;
    public Vector3[] enemyRot;
    public enTime[] time;

    public GameObject ruinsParent;
    public GameObject medievalParent;
    public GameObject pirateParent;

	private void Start()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player != null)
		{
			playerMove = player.GetComponent<PlayerMovement>();
		}
	}
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(true);
            playerMove.respawnPoint = other.gameObject.transform.position;
            SpawnRoom();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }

    private void SpawnRoom()
    {
        GameObject[] spawned;
        spawned = GameObject.FindGameObjectsWithTag("Enemies");
        for(int i = 0; i < spawned.Length; i++)
        {
            if(spawned[i] != null)
            {
                Destroy(spawned[i]);
            }
        }

        for(int i = 0; i < enemies.Length; i++)
        {
            GameObject enemy = Instantiate(enemies[i], enemyLocation[i], Quaternion.Euler(enemyRot[i].x, enemyRot[i].y, enemyRot[i].z));
            switch (time[i])
            {
                case enTime.Ruins:
                {
                    enemy.transform.parent = ruinsParent.gameObject.transform;
                    break;
                }
                case enTime.Medieval:
                {
                    enemy.transform.parent = medievalParent.gameObject.transform;
                    break;
                }
                case enTime.Pirates:
                {
                    enemy.transform.parent = pirateParent.transform;
                    break;
                }
            }
        }
    }
}
