using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionScript : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
	EnemyMovementScript enemMov;
	BoxCollider2D sightArea;

	public Vector2 seeOffset = new Vector2(3.25f, 0.0f);
	public Vector2 seeSize = new Vector2(7.5f, 2.0f);
	
	public Vector2 noSeeOffset = new Vector2(0.75f, 0.0f);
	public Vector2 noSeeSize = new Vector2(2.5f, 2.0f);

	void Start()
	{
		enemMov = GetComponentInParent<EnemyMovementScript>();
		sightArea = GetComponent<BoxCollider2D>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			enemMov.chasingPlayer = true;
			sightArea.offset = seeOffset;
			sightArea.size = seeSize;
			print("Sees you");
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			enemMov.chasingPlayer = false;
			sightArea.offset = noSeeOffset;
			sightArea.size = noSeeSize;
			print("Misses you");
		}
	}
}
