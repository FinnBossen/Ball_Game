using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTrigger : MonoBehaviour {
    public Camera Camera;
    GameObject Canon;
    CanonPlayerCtrl CanonCtrl;
    EnemySpawner EnemySpawn;
    public GameObject CastleLive;

    // Use this for initialization
    void Start () {
        Camera.enabled = false;
        Canon = GameObject.Find("CanonPlayer");
        EnemySpawn = GameObject.Find("EnemySpawn").GetComponent<EnemySpawner>();
        CastleLive.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider colliderComp)
    {
        if(colliderComp.tag == "Player")
        {
            Canon.AddComponent<CanonPlayerCtrl>();
            CanonCtrl = Canon.GetComponent<CanonPlayerCtrl>();
            Camera.enabled = true;
            CanonCtrl.playerEntered();
            EnemySpawn.enabled = true;
            CastleLive.SetActive(true);

        }
    }
    public void OldCamera()
    {
        Camera.enabled = false;
        CastleLive.SetActive(false);
        Destroy(gameObject);
    }
}
