using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float mouseSensitivity;
    CharacterController characterController;
    GameObject planetCore;
    private Camera currentCamera, cam1, cam2;
    private CameraBehavior cameraBehavior;
    private Vector3 upDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        planetCore = GameObject.FindGameObjectWithTag("Core");
        GameObject[] cameraArray = new GameObject[GameObject.FindGameObjectsWithTag("MainCamera").Length];
        cameraArray = GameObject.FindGameObjectsWithTag("MainCamera");
        // cameras = new CameraBehavior[cameraArray.Length];
        // for (int i = 0; i < cameraArray.Length; i++)
        // {   
        //     cameras[i] = cameraArray[i].GetComponent<CameraBehavior>();
        //     Debug.Log(cameras[i].name);
        // }
        currentCamera = Camera.main;
        cameraBehavior = currentCamera.GetComponent<CameraBehavior>();
        cam1.enabled = true;
        cam2.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        // Create a vector that is the character's orientation
    }

    // Update is called once per frame
    void Update()
    {
        upDirection = planetCore.transform.position - transform.position;

        // Raycast down to find the ground

        // RaycastHit hit;
        // Physics.Raycast(transform.position, -upDirection, out hit, 100);
        // Debug.DrawRay(transform.position, upDirection);

        transform.LookAt(planetCore.transform.position);
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // Rotate the character so transform.up is facing the planetCore.transform.position
        // Grab the object named Main Camera and rotate it by the mouse's x and y values
        // for(int i = 0; i < cameras.Length; i++)
        // {
        //     cameras[i].rotateHelper(new Vector3(mouseY * mouseSensitivity, mouseX * mouseSensitivity, 0f), Space.Self);
        // }
        cameraBehavior.rotateHelper(new Vector3(mouseY * mouseSensitivity, mouseX * mouseSensitivity, 0f), Space.Self);
        // transform.Rotate(Quaternion.LookRotation(currentCamera.transform.forward, transform.forward));
        Debug.DrawRay(transform.position, transform.forward);

        // WASD movement using characterController
        if (Input.GetKey(KeyCode.W)){
            characterController.Move(transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)){
            characterController.Move(transform.up * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)){
            characterController.Move(transform.right * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            characterController.Move(transform.right * speed * Time.deltaTime);
        }
        // Add jumping based off of jumpForce
        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded){
            characterController.Move(upDirection.normalized * jumpForce * Time.deltaTime);
        }
        // Toggle camera POVs
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }

    }
}
