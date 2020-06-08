using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {


    private GameObject target;
    private bool targetLocked;
    public GameObject TurretTop;
    public float AimTime = 5.0f;
    private LineRenderer laserLine;
    public GameObject Originray;
    public float weaponRange;
    float AimRemaining;
    public GameObject GameManager;
   private GameController gameController;
    private float LineRemaining;
    private float endWidth;
   
    void Start () {
     
        laserLine = TurretTop.GetComponent<LineRenderer>();
        laserLine.enabled = false;
        AimRemaining = AimTime;
        gameController = GameManager.GetComponent<GameController>();
        endWidth = laserLine.endWidth;
        LineRemaining = endWidth;
    }
	
	void Update () {
      

        // wenn Spieler im Trigger und Target is locked bewegt er sich mit einem Delay auf den Spieler zu
        if (targetLocked)
        {
     
            LayerMask layer = ~0;
            RaycastHit hit;
            if (Physics.Raycast(Originray.transform.position, Originray.transform.forward, out hit, weaponRange, layer, QueryTriggerInteraction.Ignore))
            {
                laserLine.SetPosition(0, TurretTop.transform.position);
                laserLine.SetPosition(1, hit.point);

                // wenn der Raycast den Spieler trifft wird die Aimtime runtergezählt
                if (hit.transform.tag == "Player")
                {
                    AimRemaining = AimRemaining - Time.deltaTime;
                    Debug.Log("Aim Time Left:" + AimRemaining);
                    LineRemaining = LineRemaining - AimRemaining/100*LineRemaining; 
                    laserLine.endWidth = LineRemaining;


                    if (AimRemaining <= 0)
                    {
                        gameController.youLose();
                    }
                }
                else
                {
                    LineRemaining = endWidth;
                    AimRemaining = AimTime;
                    Debug.Log("Aim Time Reset:" + AimRemaining);
                }
            }
            Quaternion targetRotation = Quaternion.LookRotation(DirectionXZ());
            TurretTop.transform.rotation = Quaternion.RotateTowards(TurretTop.transform.rotation,
            targetRotation, 45 * Time.deltaTime);
          
     
            
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            target = other.gameObject;
            targetLocked = true;
            laserLine.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        targetLocked = false;
        laserLine.enabled = false;
    }

    Vector3 DirectionXZ()
    {
        Vector3 direction = target.transform.position - TurretTop.transform.position;
    
        return direction;
    }
}
