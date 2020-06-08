using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour {
    GameObject thePlayer;
    PlayerController playerScript;

    private void Start()
    {
       thePlayer = GameObject.Find("Player");
       playerScript = thePlayer.GetComponent<PlayerController>();
    }
    void OnTriggerEnter(Collider colliderComp)
    {
        if (colliderComp.tag == "JumpPowerUp")
        {
            playerScript.jumpActivated = true;
            Destroy(colliderComp.gameObject);
        }
    }
}
