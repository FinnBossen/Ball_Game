using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiceNpc : MonoBehaviour {

    [SerializeField]

    public GameObject player;


    NavMeshAgent navMeshAgent;


	void Start () {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

	}

    private void LateUpdate()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        //Sucht Spieler als Destination
        if(player != null)
        {
            Vector3 targetVector = player.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }
    }

    // stirbt bei Berührung mit Schwert
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "sword")
        {
            Destroy(gameObject);
        }
    }

}
