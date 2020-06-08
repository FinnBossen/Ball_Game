using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEndScene : MonoBehaviour {

    public GameObject DestinationNotEnough;
    public GameObject DestinationWin;
    private Vector3 DestinationNotEnoughPosition;
    private Vector3 DestinationWinPosition;
    public GameObject Game;
    private GameController gameController;
    private bool Youwon;
    

    private void Start()
    {
        gameController = Game.GetComponent<GameController>();
     
        DestinationNotEnoughPosition = DestinationNotEnough.transform.position;
        DestinationWinPosition = DestinationWin.transform.position;
    }

    private void Update()
    {
        // schaut im GameController ob gewonnen. Wenn Ja fährt er ganz nach oben.
        Youwon = gameController.WinScore;
        
        if (Youwon) { 
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, DestinationWinPosition, Time.deltaTime * 2);
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, DestinationNotEnoughPosition, Time.deltaTime * 2);
        }


    }

}
