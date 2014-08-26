using UnityEngine;
using System.Collections;

public class shadowMovement : MonoBehaviour {


	void Update () 
	{
		if (Input.GetKey(KeyCode.RightArrow)) 
		{
			transform.Translate (Vector2.right * 4f * Time.deltaTime);
			
		}
		
		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			transform.Translate (-Vector2.right * 4f * Time.deltaTime);
			
		}

		if (Input.GetKey(KeyCode.Z)) 
		{
			gameObject.SetActive(false);
			
		}


	}
}
