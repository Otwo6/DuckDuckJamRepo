using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private new Camera camera;
    private new Rigidbody2D rigidbody;
    private CapsuleCollider2D capsuleCollider;

    public bool takingInput;

    public bool dead;

    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 8f;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;
    
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

    public bool grounded { get; private set; }
    public bool jumping { get; private set; }
    public bool running => Mathf.Abs(velocity.x) > 0.25f || Mathf.Abs(inputAxis) > 0.25f;
    public bool sliding => (inputAxis > 0f && velocity.x < 0f) || (inputAxis < 0f && velocity.x > 0f);
	public bool doubleJump = true;

    public int lives;

    public GameObject interactWidget;
    public bool inWidget;

    public GameObject deathScreen;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        takingInput = true;
        lives = 3;
    }

    private void Update()
    {
        HorizontalMovement();

        if(!dead)
        {
            grounded = rigidbody.Raycast(Vector2.down);
        }
        else
        {
            grounded = false;
        }

        if(grounded)
        {
            GroundedMovement();
        }
		else if(Input.GetButtonDown("Jump") && takingInput && doubleJump)
        {
            velocity.y = jumpForce;
            jumping = true;
			doubleJump = false;
        }

        ApplyGravity();

        if(Input.GetKeyDown("e"))
        {
            if(interactWidget != null && !inWidget)
            {
                print("Interact");
                interactWidget.SetActive(true);
                inWidget = true;
                takingInput = false;
                velocity.x = 0f;
            }
            else if(inWidget)
            {
                takingInput = true;
                inWidget = false;
                interactWidget.SetActive(false);
            }
        }

        if(dead)
        {
            if(Input.GetButtonDown("Jump"))
            {
                print("Restart here");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
    }

    private void HorizontalMovement()
    {
        if(takingInput)
        {
            inputAxis = Input.GetAxis("Horizontal");
            velocity.x = inputAxis * moveSpeed;
            //Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);

            if(rigidbody.Raycast(Vector2.right * velocity.x))
            {
                velocity.x = 0f;
            }

            if(velocity.x > 0f)
            {
                transform.eulerAngles = Vector3.zero;
            }
            else if(velocity.x < 0f)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else
        {
            print("Not Taking Input RN");
        }
    }

    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;
		doubleJump = true;

        if(Input.GetButtonDown("Jump") && takingInput)
        {
            velocity.y = jumpForce;
            jumping = true;
        }
    }

    private void ApplyGravity()
    {
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;
/**
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);
*/
        rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("Trap"))
        {
            if(!transform.DotTest(collision.transform, Vector2.up))
            {
                //if should be not ! ?
                print("Work pls");
                velocity.y = 0f;
            }
        }
    }

    public void die()
    {
        velocity.y = jumpForce;
        velocity.x = 0f;
        capsuleCollider.enabled = false;
        takingInput = false;
        lives -= 1;
        dead = true;
        deathScreen.SetActive(true);

        if(lives <= 0)
        {
            print("You suck bruh restart ong ong");
        }
    }
}
