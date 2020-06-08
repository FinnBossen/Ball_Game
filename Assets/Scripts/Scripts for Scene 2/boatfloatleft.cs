using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatfloatleft : MonoBehaviour {
    GameObject Parent;
    public float moveSpeed = 2f;
    BoatPath boatPath;

    void Awake()
    {

        Parent = transform.parent.gameObject;
        boatPath = Parent.GetComponent<BoatPath>();

    }
    private void OnTriggerStay(Collider other)
    {
        // bewegt Boot nach Links wenn Spieler in Trigger
        if (other.tag == "Player")
        {
            if (!boatPath.wall)
            {
               
                Parent.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
    }
    // Sorgt dafür das Rotation die durch den Boatpath verursacht wird ausgeschaltet wird 
    private void OnTriggerEnter(Collider other)
    {
        boatPath.rotates = false;
    }
    private void OnTriggerExit(Collider other)
    {
        boatPath.rotates = true;
    }
}
