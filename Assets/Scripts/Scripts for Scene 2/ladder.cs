using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour {

    public GameObject Player;
    private PlayerController playerController;
    public void Start()
    {
        if (Player != null)
        {
            playerController = Player.GetComponent<PlayerController>();
        }
    }
    // sagt dem PlayerController das er Grad auf einer Leiter ist
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerController.isonLadder = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.isonLadder = false;
        }
    }
}
