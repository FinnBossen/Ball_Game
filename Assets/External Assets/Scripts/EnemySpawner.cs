using UnityEngine;
using System.Collections;
//Quelle: quill18creates https://www.youtube.com/watch?v=b7DZo4jA3Jo 01.07.2018

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public int enemytoSpawned;
    public float spawnTime = 1f;
    private float curSpawnTime;
    private int enemyspawned = 0;
    public int enemytoKill;


    // Use this for initialization
    void Start () {
        curSpawnTime = spawnTime;
        enemytoKill = enemytoSpawned;
    }
	
	// Update is called once per frame

	void Update () {

    
        curSpawnTime -= 1 * Time.deltaTime;
        if (curSpawnTime <= 0 & enemyspawned < enemytoSpawned)
        {
            Instantiate(enemyPrefab, this.transform.position, this.transform.rotation);
            curSpawnTime = spawnTime;
            enemyspawned++;
        }


    }

}
