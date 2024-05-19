using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public float delayTimeMax = 1f;
    float delayTime = 0f;
    bool tripped = false;

    [SerializeField] PlayerMovement playerScript;

    bool insideTrap = false;

    public float startY;
    public float endY;
    public bool dropping;
    public float dropTime;

    private void Update()
    {
        if(tripped)
        {
            delayTime += Time.deltaTime;
            if(delayTime >= delayTimeMax)
            {
                if(insideTrap)
                print("You just got SPIKED");
                tripped = false;
                delayTime = 0f;
                playerScript.die();
                dropping = true;
            }
        }
        if(dropping)
        {
            dropTime += 4 * Time.deltaTime;
            drop();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            tripped = true;
            insideTrap = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        insideTrap = false;
    }

    void drop()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(startY, endY, dropTime), transform.position.y);
    }
}
