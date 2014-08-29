using UnityEngine;
using System.Collections;

public class FireplaceInfo2: MonoBehaviour {
	

	public bool onPlayerContact;
	
	

	void OnTriggerEnter2D(Collider2D player){
		if (player.gameObject.name == "Player" && !Game.shadowActive) {
			onPlayerContact = true;
			
		}
	}
	
	
	void OnGUI()
	{
		
		if (onPlayerContact) 
		{
			GUI.TextField(new Rect(-1.718464f,-0.9359665f,4500,50),"Shawn's shadow cannot interact with objects in the physical world if the light is too dim.");
		}
	} 
	
	
	void OnTriggerExit2D(){
		onPlayerContact = false;
		
	}
	
}
