using UnityEngine;
using System.Collections;

public class LightReceiver : MonoBehaviour {

    private int lightsInContact;
    private float totalLightPower;

    public void LightHit(float lightPower)
    {
        lightsInContact += 1;
        totalLightPower += lightPower;
    }

    private void Update(){
        //Debug.Log("lightsInContact:" + lightsInContact + " totalLightPower:" + totalLightPower+"\n");
        if (lightsInContact == 0)
        {
            if (Game.shadowActive)
            {
                Game.shadowActive = false;
                Game.ShadowSpawnd = false;
                gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
        }
        lightsInContact = 0;
        totalLightPower = 0;
    }
}
