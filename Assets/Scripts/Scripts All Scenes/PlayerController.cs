using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Material Iron;
    public static bool ironed = false;
    public GameObject Glasses;
    public float horizontalSpeed = 1.0f;
    public float verticalSpeed = 10.0f;
    private Rigidbody rb;
    private bool jump;
    public float jumpStrenght;
    private Vector3 direction;
    private bool isOnGround;
    private Vector3 jumpDirection;
    public bool jumpActivated = true;
    private Transform cameraTransform;
    public bool moveswithCamera = false;
    public GameObject camera;
    private CameraMovement cameraMovement;
    public GameObject Torch;
    public GameObject enemyinvasion;
    public GameObject sword;
    private bool swordplay = false;
    private Animation swordswing;
    public bool isonLadder = false ;
    public float torchlifetime = 15f;
    private bool torchactive = false;
    public float torchleft;

    void Start () {
        if (ironed)
        {
            gameObject.GetComponent<Renderer>().material = Iron;
        }
        cameraMovement = camera.GetComponent<CameraMovement>();
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }
	
	void Update () {

        if (torchactive) {
            torchleft -= Time.deltaTime;
            Debug.Log("torchleft" + torchleft);
        if (torchleft < 0)
        {
                Torch.SetActive(false);
                torchactive = false;
            }
        }

        if (!moveswithCamera) {
        float hValue = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        float vValue = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
        direction = new Vector3(hValue, 0, vValue);
        }
        else
        {
            direction = Input.GetAxis("Vertical") * verticalSpeed * cameraTransform.transform.forward * Time.deltaTime; ;
            direction += Input.GetAxis("Horizontal") * horizontalSpeed * cameraTransform.transform.right * Time.deltaTime; ;
        }
        jump = Input.GetButton("Jump");
    
        rb.AddForce(direction);
        Jump();

        if (swordplay) { 
        if (Input.GetMouseButtonDown(0)){
                swordswing.Play();
            }
        }
    }
    //FremdCode1: Jump Methode leicht verändert aus Quelle Space Zomby https://www.youtube.com/watch?v=xMvdUnjb2HM 01.07.2018
    void Jump()
    {
        LayerMask layer = 1 << gameObject.layer;
        layer = ~layer;  //~ to reverse something jeder Layer außer der eigene
        isOnGround = Physics.CheckSphere(transform.position, 0.6f, layer, QueryTriggerInteraction.Ignore);
        if(jump & isOnGround & jumpActivated & !isonLadder )
        {
            rb.AddForce(jumpDirection* jumpStrenght, ForceMode.Impulse);
        }
        else if(jump & isonLadder)
        {
            rb.AddForce(Vector3.up * 0.5f , ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
      
        jumpDirection = Vector3.zero;
        foreach(ContactPoint c in collision.contacts)
        {
            jumpDirection += c.normal;
        }
        
    }
    //FremdCode1 Ende
    public void Freeze()
    {
       
        rb.isKinematic = true;
  
    }
    public void Throw(Vector3 throwVector)
    {
        rb.AddForce(-throwVector);
    }
    public void unFreeze()
    {
        rb.detectCollisions = true;
        rb.isKinematic = false;
     
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CameraThird")
        {
            cameraMovement.freeCamera = true;
            if(enemyinvasion != null)
            {
                GameObject[] freeEnemys;
                freeEnemys = new GameObject[enemyinvasion.transform.childCount + 1];
                for (int i = 0; i < enemyinvasion.transform.childCount; i++)
                {

                    freeEnemys[i]= enemyinvasion.transform.GetChild(i).gameObject;
                    freeEnemys[i].transform.DetachChildren();
                    freeEnemys[i].SetActive(true);
                }
            }
     
            if (sword != null)
            {
                swordplay = true;
                sword.SetActive(true);
                swordswing = sword.GetComponent<Animation>();

        
            }
        }
        if (other.tag == "CameraStatic")
        {
            cameraMovement.freeCamera = false;
            sword.SetActive(false);
        }
        if (other.tag == "torch")
        {
            Torch.SetActive(true);
            torchactive = true;
            torchleft = torchlifetime;
        }

        if (other.tag == "YouWon")
        {
            cameraMovement.freeCamera = true;
            Freeze();
            cameraMovement.FreezeCamera();
            Glasses.SetActive(true);
            gameObject.transform.position = other.transform.position;
            gameObject.GetComponent<Renderer>().material = Iron;
            ironed = true;
        }

    }



}
