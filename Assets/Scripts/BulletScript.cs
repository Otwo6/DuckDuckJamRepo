using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float arrowSpeed = 5f;
    public float selfDestructDelay = 5f;

    void Start()
    {
        Destroy(gameObject, selfDestructDelay);
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * arrowSpeed * Time.deltaTime;
    }
}
