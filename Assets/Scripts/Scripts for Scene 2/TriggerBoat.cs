using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoat : MonoBehaviour {

    GameObject Player;
    GameObject Parent;
    public bool oneTime = true;


	void Awake () {
        Parent = transform.parent.gameObject;
        
    }
	

    // sorgt dafür das keine Deformationen beim Player entstehen und das er sich auf dem Boot bewegen kann
    void OnTriggerEnter(Collider colliderComp)
    {
        if(colliderComp.tag == "obstacle")
        {

            Player.transform.parent = null;
            Destroy(Parent);
        }
        if (colliderComp.tag == "Player")
        {
            Player = colliderComp.gameObject;
            var emptyObject = new GameObject();
            emptyObject.transform.parent = gameObject.transform;
            emptyObject.transform.localPosition = Vector3.zero;
            colliderComp.transform.parent = emptyObject.transform;
            colliderComp.transform.localScale = Vector3.one;
            if (oneTime)
            {
              
                Parent.GetComponent<BoatPath>().enabled = true;
                oneTime = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
