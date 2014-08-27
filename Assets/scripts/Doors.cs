using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {
	
	public GameObject doors;
	

	public bool onShadowContact;
	
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D player){
		if (player.gameObject.name == "shadow") {
			onShadowContact = true;
		}
	}
	
	void OnTriggerExit2D(){
		onShadowContact = false;
	}
	
	// Update is called once per frame
	void Update(){
		if (onShadowContact == true && Input.GetKeyDown("h")){
			if(doors.activeSelf){
			}
		}
	}
}
