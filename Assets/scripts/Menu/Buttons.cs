using UnityEngine;  
using System.Collections;  

public class Buttons : MonoBehaviour   
{  
	public GUISkin testGUIskin;  
	
	private bool startButton = false;   
	private bool tutotrial = false;  
	private bool Quit = false; 
	[SerializeField]
	private bool toggleStart = false;
	
	void Start ()   
	{  
		if(this.testGUIskin == null)  
		{  
			Debug.LogError("Please assign a GUIskin on the editor!"); 
			this.enabled = false;  
			return;  
		}  
	}  
	
	void OnGUI ()   
	{  
		this.startButton = GUI.Toggle(new Rect(Screen.width/20,270,80,20), this.startButton, "startButton", this.testGUIskin.customStyles[0]);
		this.tutotrial = GUI.Toggle(new Rect(Screen.width/20,310,80,20), this.tutotrial, "tutotrial", this.testGUIskin.customStyles[1]);
		this.Quit = GUI.Toggle(new Rect(Screen.width/20,350,80,20), this.Quit, "Quit", this.testGUIskin.customStyles[2]);
	}  

	void Update()
	{
		if(startButton)
		{
			Application.LoadLevel("LevelFinal");
		}
	}
}  
