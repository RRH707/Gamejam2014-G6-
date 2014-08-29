using UnityEngine;
using System.Collections;

public class shadowMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 4f;
	public int gravity = 6;
	public int jumpForce = 475;
	public float jumpSpeed = 3f;
	private bool onGround = true;
	private bool facingRight = true;
	private Animator anim;

    private Animator animator;
    private string animTrigWalk = "walk";
    private string animTrigWalkStop = "stopWalk";

    private int keyDownCount = 0;
    private bool startWalking = false;
    private bool stopWalking = false;
    private bool walking = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

	void Update () 
	{
        startWalking = false;
        stopWalking = false;
        if (Input.GetKeyDown(KeyCode.RightArrow) && Game.shadowActive)
        {
            startWalking = true;
            keyDownCount += 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && Game.shadowActive)
        {
            startWalking = true;
            keyDownCount += 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && Game.shadowActive)
        {
            keyDownCount -= 1;
            stopWalking = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && Game.shadowActive)
        {
            keyDownCount -= 1;
            stopWalking = true;
        }
        if (!Game.shadowActive)
        {
            keyDownCount = 0;
            if (walking)
            {
                stopWalking = true;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && Game.shadowActive)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Game.shadowActive)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
        if (keyDownCount == 0 && stopWalking)
        {
            animator.SetTrigger(animTrigWalkStop);
            walking = false;
        }
        else if (startWalking && !walking)
        {
            walking = true;
            animator.SetTrigger(animTrigWalk);
        }
        if (Game.shadowActive)
        {
			if(onGround == true)
			{

				if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
				{
					Jump();
					//anim.SetBool("Jump", true);
				}	
			}
        }
	}
		void Jump()
		{
			this.transform.rigidbody2D.AddForce(Vector3.up * jumpSpeed * jumpForce);
			onGround = false;
		}
		

		void OnCollisionEnter2D (Collision2D hit)
		{
		   
			if(hit.transform.tag == "Platform")
			{
				onGround = true;
				//anim.SetBool("Jump", false);
			}
		}
		

	}

