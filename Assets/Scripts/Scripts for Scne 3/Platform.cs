using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    private GameObject Player;
    public GameObject Destination;
    private Vector3 positionBefore;
    private bool goesToDestination = true;
    public float Speed = 5;
    private void Start()
    {
        positionBefore = gameObject.transform.position;
    }
    private void Update()
    {

        // bewegt sich zum gesetzten Ziel und bewegt sich dann wieder zur ursprünglichen zurück und das im endlosen Loop
        if (goesToDestination) {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Destination.transform.position, Time.deltaTime * Speed);
        }
        if (gameObject.transform.position == Destination.transform.position || !goesToDestination)
        {
            goesToDestination = false;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, positionBefore, Time.deltaTime * Speed);
            if (gameObject.transform.position == positionBefore)
            {
                goesToDestination = true;
            }
        }
       

    }
    // Sorgt dafür das keine Deformationen beim Spieler entstehen und das er sich auf  der Platform bewegen kann
    private void OnTriggerEnter(Collider colliderComp)
    {
        if (colliderComp.tag == "Player")
        {
            Player = colliderComp.gameObject;
            var emptyObject = new GameObject();
            emptyObject.transform.parent = gameObject.transform;
            emptyObject.transform.localPosition = Vector3.zero;
            Player.transform.parent = emptyObject.transform;
           Player.transform.localScale = Vector3.one;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
