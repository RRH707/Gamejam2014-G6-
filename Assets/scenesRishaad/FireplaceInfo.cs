using UnityEngine;
using System.Collections;

public class FireplaceInfo : MonoBehaviour {
	

	
	public bool onShadowContact;

	
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D player){
		if (player.gameObject.name == "Shadow") {
			onShadowContact = true;
		}
		
	}
	
	void OnGUI()
	{
		if (onShadowContact) 
		{
			GUI.TextArea(new Rect(-1.718464f,-0.9359665f,2000,2000),"Shawn's shadow cannot interact with objects in the physical world if the light is too dim.");
		} 
		
	} 
	
	void OnTriggerExit2D(){
		onShadowContact = false;
	}
	

}