using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
    public float delayTime;
    private Animation animation;
    private BoxCollider boxCollider;
    public bool staticTrap ;
    public GameObject Game;
    GameController gameController;

    void Start () {
        animation = GetComponent<Animation>();
        boxCollider = GetComponent<BoxCollider>();
        gameController = Game.GetComponent<GameController>();
        // schaut ob es eine statische Trap ist, dann wird der Collider verändert und die Animation nur beim Eintreten im Collider gestartet
        if (staticTrap)
        {
            boxCollider.center = boxCollider.center + new Vector3(0, 0.5f, 0);
        }
        else StartCoroutine(Go());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (staticTrap) {
            animation.Play();
            }
            StartCoroutine(waitTillDie());
     
        }
    }

    // Spielt animation nach bestimmter zeit ab
    IEnumerator Go()
    {
        while (true)
        {
            animation.Play();
            yield return new WaitForSeconds(delayTime);
        }
    }

    IEnumerator waitTillDie()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            gameController.youLose();
        }
    }

}
