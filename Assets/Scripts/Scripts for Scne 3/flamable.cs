using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamable : MonoBehaviour {

    openFireDoor Door;
    private void Start()
    {
        Door = gameObject.GetComponentInParent<openFireDoor>();
    }

    // wenn Object eine ackel berührt Feuer wird angezündet und bei der Tür wird einer der benötigten Fackeln runtergestellt
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "torch")
        {
            
            if (!gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                Door.neededfire = Door.neededfire - 1;
                Debug.Log("Flame on");
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
