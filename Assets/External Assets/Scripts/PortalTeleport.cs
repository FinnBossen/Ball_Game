using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Quelle: Brackeys https://www.youtube.com/watch?v=cuQao3hEKfs&t=191s 01.07.2018

public class PortalTeleport : MonoBehaviour {

    public Transform player;
    public Transform reciever;
    private bool playerIsOverlapping = false;
    public int Portalusages;


    // Update is called once per frame
    void Update () {

      
            if (playerIsOverlapping & Portalusages >0)
            {

                Vector3 portalToPlayer = player.position - transform.position;
                float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
                if (dotProduct < 0f)
                {
                    float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                    rotationDiff += 180;
                    player.Rotate(Vector3.up, rotationDiff);

                    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                    player.position = reciever.position + positionOffset;

                    playerIsOverlapping = false;
                    Portalusages--;

                }
            }
        
		
	}

    private void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
         
        }
    }

   
}
