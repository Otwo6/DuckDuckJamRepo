using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceScript : MonoBehaviour
{
    public GameObject collision;

    // Start is called before the first frame update
    void Start()
    {
        if (collision != null)
        {
            collision.SetActive(false); // Ensure collision is initially inactive
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            StartCoroutine(ActivateCollisionForHalfSecond());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemies")
        {
            print("HITHITHITHITHTSLICE");
            Destroy(col.gameObject);
        }
        else
        {
            print("nah");
        }
    }

    IEnumerator ActivateCollisionForHalfSecond()
    {
        collision.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        collision.SetActive(false);
    }
}
