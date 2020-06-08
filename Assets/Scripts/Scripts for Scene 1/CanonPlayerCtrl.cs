using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonPlayerCtrl : MonoBehaviour {

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    CanonShoot PlayerCanonSpawner;
    GameObject Player;
    PlayerController playerController;
    GameObject playerSeat;
    CanonTrigger CameraCtrl;
    EnemySpawner enemySpawner;
    int shoots = 0;
    public int enemykilled = 0;

    private bool notlastshoot = true;

    private void Awake()
    {
        PlayerCanonSpawner = GameObject.Find("PlayerCanonSpawner").GetComponent<CanonShoot>();
        Player = GameObject.Find("Player");
        playerController = Player.GetComponent<PlayerController>();
        playerSeat = GameObject.Find("PlayerSeat");
        CameraCtrl = GameObject.Find("CanonTrigger").GetComponent<CanonTrigger>();
        enemySpawner = GameObject.Find("EnemySpawn").GetComponent<EnemySpawner>();
    }
    void Update()
    {
     // Bewegt Kanone nach Bewegung der Maus und Schießt bei der Rechten Maustaste  
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        float h = horizontalSpeed * Input.GetAxis("Mouse X");

        if (System.Math.Abs(v) > System.Math.Abs(h) )
        {
            transform.Rotate(v, 0, 0);
        }
        if (System.Math.Abs(h) > System.Math.Abs(v) )
        {
            transform.Rotate(0, h, 0, Space.World);
        }

        if (Input.GetMouseButtonDown(0)& notlastshoot)
        {
            PlayerCanonSpawner.playerShoot();
            shoots++;
        }

        if (Input.GetMouseButtonDown(0) & notlastshoot == false)
        {
            shootPlayer();
            shoots++;
        }
        if (enemySpawner.enemytoKill == enemykilled)
        {
            PlayerinCanon();
            notlastshoot = false;
            enemykilled++;
        }




    }
    
    // sorgt dafür das beim Einsteigen in die Kanone keine deformationen beim Player Stattfinden
    public void playerEntered()
    {
        var emptyObject = new GameObject();
        emptyObject.transform.parent = playerSeat.transform;
        emptyObject.transform.localRotation = Quaternion.identity;
        emptyObject.transform.localPosition = Vector3.zero;
        Player.transform.parent = emptyObject.transform;
        Player.transform.localRotation = Quaternion.identity;
        Player.transform.localPosition = Vector3.zero;
        Player.transform.localScale = Vector3.one;


        playerController.Freeze();
    }

    public void shootPlayer()
    {
        CameraCtrl.OldCamera();
        playerController.unFreeze();
        PlayerCanonSpawner.shootThePlayer();
        Player.transform.parent = null;
        Destroy(gameObject.GetComponent<CanonPlayerCtrl>());
    }

    public void PlayerinCanon()
    {
       

        Player.transform.parent = PlayerCanonSpawner.transform;
        Player.transform.localPosition = Vector3.zero;
        Player.transform.localRotation = Quaternion.identity;
      
    }
}
