using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {


	public GUIStyle style;
	public Texture texture;

	void OnGui(){
		GUI.skin.button = style;

		if(GUI.Button (new Rect (0,0,550,320),texture)){
			Application.LoadLevel("Scene");
		}
	}
}
