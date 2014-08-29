using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {
	
	public GameObject door;

	public bool onShadowContact;
	public bool doorOpen;
	public GUISkin skin;
	
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D player){
		if (player.gameObject.name == "Shadow") {
			onShadowContact = true;
		}
	
	}

	void OnGUI()
	{	
		GUI.skin = skin;
		if (onShadowContact) 
		 {
			GUI.TextArea(new Rect(-1.718464f,-0.9359665f,4500,50),"Press S to open the door for your body.");
		} 

	} 
	
	void OnTriggerExit2D(){
		onShadowContact = false;
	}
	
	// Update is called once per frame
	void Update(){
		if (onShadowContact == true && Input.GetKeyDown("s")){
			if(door.activeSelf){
				door.SetActive(false);
				doorOpen = true;
				//play.animation("doorOpen");
			}
		}
	}

}