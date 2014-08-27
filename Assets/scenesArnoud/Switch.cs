using UnityEngine;
using System.Collections;

public class Switch: MonoBehaviour {

	public bool switchstatus;
	public SwitchObject[] hallo;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if(switchstatus){
			switchstatus = false;
		}
		else{
			switchstatus = true;
		}


	}
}
