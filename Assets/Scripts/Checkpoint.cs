using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	PlayerMovement playerMove;
	private void Start()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player != null)
		{
			playerMove = player.GetComponent<PlayerMovement>();
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			playerMove.respawnPoint = transform.position;
		}
	}
}
