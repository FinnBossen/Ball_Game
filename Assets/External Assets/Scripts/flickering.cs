using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Quelle: Alexander Zotov  https://www.youtube.com/watch?v=9n6RulIcRMc&list=PLTw9tqO9xuO_h7XLZ_aiBib-fYYnJ6spN&index=50&t=0s 01.07.2018

public class flickering : MonoBehaviour {

    Light fire;
    float lightIntensity;
    public float minIntensity = 3f;
    public float maxIntensity = 5f;

	void Start () {
        fire = gameObject.GetComponent<Light>();
	}


    private void Update()
    {
 
        lightIntensity = Random.Range(minIntensity, maxIntensity);
        fire.intensity = lightIntensity;
    }

}
