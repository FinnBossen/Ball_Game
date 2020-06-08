using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {
    public GameObject Player;
    private PlayerController playerController;
    private bool playerinside = false;
    // Use this for initialization
    private Vector3 Destination;
	void Start () {
       if(Player != null)
        {
            playerController = Player.GetComponent<PlayerController>();
        }
        GameObject DestinationObject = new GameObject();
        DestinationObject.transform.position = gameObject.transform.position;
        DestinationObject.transform.rotation = gameObject.transform.rotation;
        DestinationObject.transform.Translate(new Vector3(0, 0, -gameObject.transform.localScale.z/2));
        Destination = DestinationObject.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        // Bewegt Spieler von Eintrittstelle bis zum Ende des Seils
        if (playerinside) {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, Destination + new Vector3(0, -Player.transform.localScale.y/2, 0), Time.deltaTime * 10);
            if(Player.transform.position == Destination + new Vector3(0, -Player.transform.localScale.y / 2, 0))
            {
                playerinside = false;
                playerController.unFreeze();
            }
        }
    }

    // Freezed Player wenn er Seil betritt
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.Freeze();
            playerinside = true;
        }
    }


  
}
