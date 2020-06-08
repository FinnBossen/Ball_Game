using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupRigid : MonoBehaviour {
    Rigidbody[] rigidarray;
	
	void Start () {

        rigidarray = new Rigidbody[gameObject.transform.childCount+1];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            rigidarray[i] = gameObject.transform.GetChild(i).GetComponent<Rigidbody>();
            rigidarray[i].isKinematic = true;
        }
    }
	
    void OnTriggerEnter(Collider colliderComp)
    {
        if(colliderComp.tag == "Player" )
        {
            StartCoroutine(WaitandStartRigid());
         
        }
    }

    IEnumerator WaitandDestroy()
    {
        
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }

    IEnumerator WaitandStartRigid()
    {

        // geht nach Timer einen Array durch und Schaltet isKinematic auf allen Rigidbodys der Children auf false
        yield return new WaitForSeconds(3);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {

            rigidarray[i].isKinematic = false;

         
        }
        StartCoroutine(WaitandDestroy());

    }

}
