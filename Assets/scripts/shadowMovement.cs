using UnityEngine;
using System.Collections;

public class shadowMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 4f;

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
        }
	}
}
