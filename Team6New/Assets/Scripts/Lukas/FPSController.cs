using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    public static List<GameObject> SeenHidingSpots = new List<GameObject>();

    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 70.0f;
    bool isRunning;
    float curSpeedX;
    float curSpeedY;
    float movementDirectionY;
    public Health health;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public static bool canMove = true;

    public bool canJump = true;

    [HideInInspector]
    public bool isGrounded;

    public bool heatMap;
    public GameObject heatMapPrefabW;
    public GameObject heatMapParent;
    public Transform spawnPoint;
    private float timer = 2.5f;
    public float timerMax = 2.5f;

    void Start()
    {
        health = GetComponent<Health>();
        canMove = true;
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        isRunning = Input.GetKey(KeyCode.LeftShift);
        curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded && canJump)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        
        if (heatMap)
        {
            timer -= Time.deltaTime;
            if(timer < 0 && heatMap)
            {
                timer = timerMax;
                GameObject movementMark = Instantiate(heatMapPrefabW, spawnPoint.position, spawnPoint.rotation);
                movementMark.transform.parent = heatMapParent.transform;
            }
        }
    }
}