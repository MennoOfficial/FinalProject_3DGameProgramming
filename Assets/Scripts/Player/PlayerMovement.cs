using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float normalSpeed = 12f;
    public float sprintSpeed = 20f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float normalFOV = 60f;
    public float sprintFOV = 70f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private Camera activeCamera;

    private bool isDeathUIActive = false;

    void Start()
    {
        activeCamera = Camera.main;
    }

    void Update()
    {
        // Check if the Death UI is active
        isDeathUIActive = UIManager.Instance.DeathUI.activeSelf;

        // If Death UI is active, restrict movement and cursor
        if (isDeathUIActive)
        {

            // Allow falling under gravity even when Death UI is active
            controller.Move(Vector3.up * velocity.y * Time.deltaTime);


            // Disable movement controls
            controller.Move(Vector3.zero);

            // Lock the cursor to prevent free movement
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            // Check if there is any movement input before allowing sprinting
            bool isMoving = (x != 0 || z != 0);

            float currentSpeed = isMoving && Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : normalSpeed;
            controller.Move((move * currentSpeed + velocity) * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            // Adjust FOV based on sprinting
            if (activeCamera != null)
            {
                activeCamera.fieldOfView = Input.GetKey(KeyCode.LeftShift) && isMoving ? sprintFOV : normalFOV;
            }
        }


       
    }


    public void SetActiveCamera(Camera newActiveCamera)
    {
        activeCamera = newActiveCamera;
    }
}
