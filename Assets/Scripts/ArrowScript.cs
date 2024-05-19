using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float arrowSpeed = 5f;

    void FixedUpdate()
    {
        transform.position += Vector3.left * arrowSpeed * Time.deltaTime;
    }
}
