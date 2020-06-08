using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Delete : MonoBehaviour {




    private bool missionActivated;

    private GameController gameController;
    


    private void Start()
    {
        gameController = GameObject.Find("Game").GetComponent<GameController>();


    }
    void Update()
    {
     

        if (gameObject.transform.position.y < -20.0f)
        {
            gameController.youLose();
         
            
        }

    }
    
    void OnTriggerEnter(Collider colliderComp)
    {
        if (colliderComp.tag == "Finish" )
        {
            Debug.Log("Ziel erreicht");
            gameController.youWon();
           
        }
        if (colliderComp.tag == "Enemy")
        {
           gameController.youLose();
            
        }
        // Ausgabe für die Textpasagen in den Szenen
        if (colliderComp.tag == "NightMission" && !missionActivated)
        {
            missionActivated = true;
            gameController.nightmission();
        }
        if (colliderComp.tag == "CastleMessage")
        {
       
            gameController.CastleMessage();
        }
    }

  
   

}
