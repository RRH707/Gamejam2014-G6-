using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour 
{
    [SerializeField]
	private GameObject shadow;
    [SerializeField]
    private float speed = 4f;

    private shadowMovement shadowScript;
    private LightSource lightSourceScript;

    void Start()
    {
        shadowScript = shadow.GetComponent<shadowMovement>();
        lightSourceScript = shadow.GetComponent<LightSource>();
    }

	void Update() 
	{
        if (!Game.shadowActive)
        {
            if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
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
}
