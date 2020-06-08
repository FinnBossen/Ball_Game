using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Quelle: Brackeys https://www.youtube.com/watch?v=cuQao3hEKfs&t=191s 01.07.2018
public class PortalCamera : MonoBehaviour {

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
	// Update is called once per frame
	void Update () {
        Vector3 playerOffsetFromPortal = playerCamera.position - portal.position;
        transform.position = otherPortal.position + playerOffsetFromPortal;
	}
}
