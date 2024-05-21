using UnityEngine;

public class ItemOverlapScript : MonoBehaviour
{
    PlayerMovement playerMove;
    TimeManager playerTimeManager;

    public bool doubleJump;
    public bool pirateTime;
    // This method is called when the script instance is being loaded
    private void Start()
    {
        // Find the GameObject with the tag "Player" and get its PlayerMovement component
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerMove = player.GetComponent<PlayerMovement>();
            playerTimeManager = player.GetComponent<TimeManager>();
        }
    }
    
    // This method is called when the Collider2D other enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Perform actions when the player enters the trigger
            if(doubleJump)
            {
                playerMove.hasDoubleJump = true;
                playerTimeManager.hasMedieval = true;
                Destroy(gameObject);
            }
			if(pirateTime)
			{
				playerTimeManager.hasPirate = true;
                Destroy(gameObject);
			}
        }
    }
}
