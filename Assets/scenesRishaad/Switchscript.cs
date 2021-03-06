﻿using UnityEngine;
using System.Collections;

public class SwitchScript: MonoBehaviour {
	
	public GameObject light;
	public bool onPlayerContact;
	public GUISkin skin;
	
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D player){
		if (player.gameObject.name == "Player" && !Game.shadowActive) {
			onPlayerContact = true;

		}
	}

	
	void OnGUI()
	{
		GUI.skin = skin;
		if (onPlayerContact) 
		{
			GUI.TextField(new Rect(-1.718464f,-0.9359665f,3000,50),"Press S to turn on the light for your shadow");
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
