using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Quelle: Brackeys https://www.youtube.com/watch?v=cuQao3hEKfs&t=191s 01.07.2018

public class PortalTextureSetUp : MonoBehaviour {

    public Camera PortalCam;
    public Material PortalTexture; 
	// Use this for initialization
	void Start () {
		if(PortalCam.targetTexture != null)
        {
            PortalCam.targetTexture.Release();
        }
        PortalCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        PortalTexture.mainTexture = PortalCam.targetTexture;
	}
	
}
