using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
	public bool chasingPlayer = false;
	GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if(chasingPlayer)
		{
			transform.position += Vector3.right * Time.deltaTime * 5.0f;
		}
	}
}
