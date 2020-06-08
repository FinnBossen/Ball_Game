using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CanonBallCtrl : MonoBehaviour {
    Rigidbody rigidbodyComp;
    GameController gameController;
    public float LifeTime = 10f;

  
    void Awake() {
        rigidbodyComp = GetComponent<Rigidbody>();
        gameController = GameObject.Find("Game").GetComponent<GameController>();
    }
    private void Update()
    {
        LifeTime -= Time.deltaTime;
        if (gameObject.transform.position.y < -7.0f || LifeTime < 0)
        {
            Destroy(gameObject);
          
        }
    }
    public void Throw(Vector3 throwVector)
    {
       
        rigidbodyComp.AddForce(-throwVector);
    }

    void OnTriggerEnter(Collider colliderComp)
    {
        if (colliderComp.tag == "Player")
        {
            Destroy(gameObject);
            gameController.youLose();
        }
    }
}
