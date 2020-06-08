using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShoot : MonoBehaviour {
    public float delay = 5.0f;
    public GameObject CanonBall;
    public float throwForce = 1000;
    public bool isnotPlayer = true;
  
    void Start () {
		
	}
	

	void Update () {
        delay -= Time.deltaTime;

        if (delay <= 0 & isnotPlayer)
        {
            GameObject go = Instantiate(CanonBall, transform.position, Quaternion.identity);
            CanonBallCtrl canonballCtrl = go.GetComponent<CanonBallCtrl>();
            canonballCtrl.Throw(transform.forward * throwForce);
            delay = 5.0f;
        }

    }
    
    public void playerShoot()
    {
        GameObject go = Instantiate(CanonBall, transform.position, Quaternion.identity);
        CanonBallCtrl canonballCtrl = go.GetComponent<CanonBallCtrl>();
        canonballCtrl.Throw(transform.forward * throwForce);
    }

    public void shootThePlayer()
    {
        PlayerController PlayerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
        PlayerCtrl.Throw(transform.forward * 2000);

    }
}
