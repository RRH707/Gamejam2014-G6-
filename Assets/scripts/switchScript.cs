using UnityEngine;
using System.Collections;

public class switchScript : MonoBehaviour {

	public GameObject light;
	public bool onPlayerContact;


	// Use this for initialization
	void OnTriggerEnter2D(Collider2D player){
		if (player.gameObject.name == "Player") {
			onPlayerContact = true;
		}
	}

	void OnTriggerExit2D(){
			onPlayerContact = false;
		}
	
	// Update is called once per frame
	void Update(){
		if (onPlayerContact == true && Input.GetKeyDown("j")){
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
