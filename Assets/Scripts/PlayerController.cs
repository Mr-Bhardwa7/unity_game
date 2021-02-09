using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed = 5f;
	public float jumpSpeed = 8f;
	private float movement = 0f;
	private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Animator playerAnimation;
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;

    // Start is called before the first frame update
    void Start()
    {
     	rigidBody = GetComponent<Rigidbody2D> ();
        playerAnimation = GetComponent<Animator> ();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    	movement = Input.GetAxis("Horizontal");

        // Player Movement
    	if(movement > 0)
        {
    		rigidBody.velocity = new Vector2(movement*speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(0.4494997f, 0.3080974f);
    	}
        else if(movement < 0)
        {
    		rigidBody.velocity = new Vector2(movement*speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-0.4494997f, 0.3080974f);
        }
        else
        {
    		rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
    	}

        //Player Jump
		if (Input.GetButtonDown("Jump") && isTouchingGround)
		{
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);

        }

        //Player Animation Change 
        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
        playerAnimation.SetBool("IsEnemyAtacked", false);
        //transform.localScale = new Vector3(0.3910647f, 0.2680447f, 0.8299181f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "FullDetector")
        {
            gameLevelManager.Respawn();
        }
        if(other.tag == "Enemies")
        {
            gameLevelManager.Respawn();
        }
        if(other.tag == "Checkpoint")
        {
            respawnPoint = new Vector3(other.transform.position.x, other.transform.position.y, 0);
        }
    }
}
