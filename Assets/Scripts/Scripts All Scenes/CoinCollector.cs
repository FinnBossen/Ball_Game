using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour {

    static Vector3 CheckpointPosition = new Vector3(0, 0.5f, 0f);
    private int coinCollected;
    private static int coinsBeforeCheckpoint;
    GameController gameController;
    GameObject Gate;


    private void Start()
    {
   
        gameObject.transform.position = CheckpointPosition;
        coinCollected = coinsBeforeCheckpoint;
        gameController = GameObject.Find("Game").GetComponent<GameController>();
        gameController.UpdateCoin(coinCollected);
    
    }

    void OnTriggerEnter(Collider colliderComp)
    {

        if (colliderComp.tag == "Coin")
        {
            coinCollected++;
            Destroy(colliderComp.gameObject);
            Debug.Log("coins collected: "+ coinCollected);
            gameController.UpdateCoin(coinCollected);
            if(coinCollected == 30)
            {
                Gate = GameObject.Find("Gate");
                Destroy(Gate);
            }
        }

        //regelt die Checkpoints
        if (colliderComp.tag == "Checkpoint")
        {
            coinsBeforeCheckpoint = coinCollected;
            CheckpointPosition = colliderComp.gameObject.transform.position;
            colliderComp.enabled = false;
        }
        if (colliderComp.tag == "Finish")
        {
            coinsBeforeCheckpoint = 0;
            CheckpointPosition = new Vector3(0, 0.5f, 0f);

        }
    

    }
       //Methode aufrufen um die Statische position wieder zurückzusetzen zum Start
    public void SetPositionBack()
    {
        coinsBeforeCheckpoint = 0;
        CheckpointPosition = new Vector3(0, 0.5f, 0f);
    }
        // Berechnet die eingesamelten Coins des Schiffes mit ein
    public void shipCoins()
    {

        coinCollected = coinCollected+1;
        Debug.Log("Coins:"+ coinCollected);
        gameController.UpdateCoin(coinCollected);
    }
}
