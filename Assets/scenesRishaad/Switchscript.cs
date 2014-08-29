using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {
	
	public GameObject light;
	public bool onPlayerContact;
	
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D player){
		if (player.gameObject.name == "Player" && !Game.shadowActive) {
			onPlayerContact = true;
			Debug.Log ("hit");
		}
	}


	void OnGUI()
	{
		if (onPlayerContact) 
		{
			GUI.TextArea (new Rect(-6.720293f,-0.9188955f,2000,2000),"Press S to turn on the light");
		}
	}


	void OnTriggerExit2D(){
		onPlayerContact = false;
	}


	
	// Update is called once per frame
	void Update(){
		if (onPlayerContact == true && Input.GetKeyDown("s")){
			/*if(light.activeSelf){
				light.SetActive(false);
			}
			else{
				light.SetActive(true);

			}*/
			light.SetActive(!light.activeSelf);
		}
	}
}
