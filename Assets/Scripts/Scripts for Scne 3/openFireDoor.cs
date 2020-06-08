using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openFireDoor : MonoBehaviour {
    public int neededfire = 2;
    public float moveSpeed = 0.5f;
    public GameObject Tor;

    

    // öffnet nachdem genug Feuer aktiviert wurden
	public void LateUpdate () {
       
        if (neededfire == 0)
        {
            Debug.Log("Simsalabim");
            if(Tor.transform.position.y >= -0.7f) { 
            Tor.transform.position += Vector3.down * 0.05f;
            }
        }
    }


}
