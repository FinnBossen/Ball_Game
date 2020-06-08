using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectorShip : MonoBehaviour {


 
    public GameObject Player;
    CoinCollector coinCollector;

    private void Awake()
    {
        coinCollector = Player.GetComponent<CoinCollector>();
    }

    void OnTriggerEnter(Collider colliderComp)
    {
        //ruft Coincollector vom Player auf und zählt dort die Coins des Schiffs mit
        if (colliderComp.tag == "Coin")
        {
            colliderComp.enabled = false;
            Destroy(colliderComp.gameObject);
            coinCollector.shipCoins();
        }
    }
}
