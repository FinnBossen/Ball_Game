using UnityEngine;
using System.Collections;

//Quelle: quill18creates https://www.youtube.com/watch?v=b7DZo4jA3Jo 01.07.2018

public class Enemy : MonoBehaviour {

	GameObject pathGO;

	Transform targetPathNode;
	int pathNodeIndex = 0;

	float speed = 15f;
    CanonPlayerCtrl killed;
    GameController Lives;
    EnemySpawner Enemyübrig;

    // Use this for initialization
    void Start () {
		pathGO = GameObject.Find("Path");
        killed = GameObject.Find("CanonPlayer").GetComponent<CanonPlayerCtrl>();
        Lives = GameObject.Find("Game").GetComponent<GameController>();
        Enemyübrig = GameObject.Find("EnemySpawn").GetComponent<EnemySpawner>();
    }

	void GetNextPathNode() {
		if(pathNodeIndex < pathGO.transform.childCount) {
			targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
			pathNodeIndex++;
		}
		else {
			targetPathNode = null;
           
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(targetPathNode == null) {
			GetNextPathNode();
			if(targetPathNode == null) {
				// We've run out of path!
				ReachedGoal();
				return;
			}
		}

		Vector3 dir = targetPathNode.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distThisFrame) {
			// We reached the node
			targetPathNode = null;
		}
		else {
			// TODO: Consider ways to smooth this motion.

			// Move towards node
			transform.Translate( dir.normalized * distThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation( dir );
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}

	}

	void ReachedGoal() {
        Debug.Log("one hit");
        Lives.UpdateCastle();
        int b = Enemyübrig.enemytoKill;
        b--;
        Enemyübrig.enemytoKill= b;
        Debug.Log(Enemyübrig.enemytoKill +" vs "+ killed.enemykilled);
        Destroy(gameObject);  
    }


	public void Die() {
		// TODO: Do this more safely!
		
		Destroy(gameObject);
	}

    void OnTriggerEnter(Collider colliderComp)
    {
        if (colliderComp.tag == "CanonBall")
        {
            Die();
            int a = killed.enemykilled;
            a++;
            killed.enemykilled = a;
            Debug.Log(killed.enemykilled +" vs "+ Enemyübrig.enemytoKill);
            Destroy(colliderComp.gameObject);
        }
    }
}
