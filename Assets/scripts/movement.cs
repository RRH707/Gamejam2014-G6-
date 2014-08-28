using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
    [SerializeField]
	private GameObject shadow;
    [SerializeField]
    private float speed = 4f;

    private Animator animator;
    private shadowMovement shadowScript;
    private LightSource lightSourceScript;
    private string animTrigWalk = "walk";
    private string animTrigWalkStop = "stopWalk";
    private float walkStartTime = 0.0f;
    private const float walkStartActivateTime = 1.333f;
    private bool walking = true;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        shadowScript = shadow.GetComponent<shadowMovement>();
        lightSourceScript = shadow.GetComponent<LightSource>();
    }

	void Update() 
	{
        if (!Game.shadowActive)
        {
            if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
            {
                WalkAnimation(false);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                WalkAnimation(true);
            }
            else if(walking)
            {
                walking = false;
                animator.SetTrigger(animTrigWalkStop);
            }
        }
		if (Input.GetKeyDown(KeyCode.K)) 
		{
            if (Game.shadowActive)
            {
                Game.shadowActive = false;
                //shadow.SetActive(false);
            }
            else
            {
                Game.shadowActive = true;
                //shadow.SetActive(true);
            }
		}
	}

    void WalkAnimation(bool right)
    {
        walking = true;
        animator.SetTrigger(animTrigWalk);
        if (right)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
