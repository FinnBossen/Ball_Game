using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool freeCamera = false;
    //für statische Camera
    public GameObject Camera;
    private Transform Cameratransform;
    public GameObject player;
    private Transform camerafocus;
    public GameObject StaticCamera;
    private Transform StaticCameraTransform;
    private PlayerController playerController;
    //für frei bewegbare Camera
    public GameObject ThirdPersonPosition;
    private Transform ThirdPersonTransform;

    // FremdCode2: ThirPersonCamera Methode FilmStorm https://www.youtube.com/watch?v=LbDQHv9z-F0 01.07.2018
    public float CameraMoveSpeed = 1f;
    public float clampAngle = 90.0f;
    public float inputSensitivity = 150.0f;
   private float mouseX;
    private float mouseY;
    private float finalInputX;
    private float finalInputZ;
    private float rotY = 0.0f;
    private float rotX = 0.0f;
    private bool Freeze = false;
    // FremdCode2 ende  

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        Camera = gameObject.transform.GetChild(0).gameObject;
        Cameratransform = gameObject.transform.GetChild(0);
        StaticCameraTransform = StaticCamera.transform;
        ThirdPersonTransform = ThirdPersonPosition.transform;


        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
 
    }

    void Update()
    {
        if (!Freeze) { 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            freeCamera = !freeCamera;
        }
        if (freeCamera)
        {
            movableCamera();
        }
        else
        {
            staticCamera();
        }
        }
    }

   void LateUpdate()
    {
        if (freeCamera)
        {
           CameraUpdaterThird();
        }
        else
        {
            CameraUpdaterStatic();
        }
    }


    public void staticCamera()
    {
     
            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;
       
    }
    // FremdCode2: ThirPersonCamera Methode FilmStorm https://www.youtube.com/watch?v=LbDQHv9z-F0 01.07.2018
    public void movableCamera()
    {

        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;


     

    }
    // FremdCode2 ende

    void CameraUpdaterThird()
    {

        playerController.moveswithCamera = true;
        Transform target = player.transform;


        Cameratransform.position = ThirdPersonTransform.position;
        transform.position = target.position;

    }
    void CameraUpdaterStatic()
    {

        playerController.moveswithCamera = false;
        Transform target = player.transform;


        Cameratransform.position = StaticCameraTransform.position;
        transform.position = target.position;
        transform.rotation = Quaternion.identity;

    }

    public void FreezeCamera()
    {

        gameObject.transform.Rotate(new Vector3(-34.4f, -12.146f, 0f));
        Freeze = true;
    }
}
