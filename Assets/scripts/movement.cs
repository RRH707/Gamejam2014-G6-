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
    private int keyDownCount = 0;
    private bool startWalking = false;
    private bool stopWalking = false;
    private bool walking = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        shadowScript = shadow.GetComponent<shadowMovement>();
        lightSourceScript = shadow.GetComponent<LightSource>();
    }

	void Update() 
	{
        startWalking = false;
        stopWalking = false;
        if (Input.GetKeyDown(KeyCode.RightArrow) && !Game.shadowActive)
        {
            startWalking = true;
            keyDownCount += 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !Game.shadowActive)
        {
            startWalking = true;
            keyDownCount += 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && !Game.shadowActive)
        {
            keyDownCount -= 1;
            stopWalking = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && !Game.shadowActive)
        {
            keyDownCount -= 1;
            stopWalking = true;
        }
        if (Game.shadowActive)
        {
            keyDownCount = 0;
            if (walking)
            {
                stopWalking = true;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && !Game.shadowActive)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Game.shadowActive)
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
}
