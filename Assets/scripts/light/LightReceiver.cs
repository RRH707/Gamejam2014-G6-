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
        lightsInContact = 0;
        totalLightPower = 0;
    }
}
