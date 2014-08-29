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


	void Update () 
	{
        if (Game.shadowActive)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }

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

