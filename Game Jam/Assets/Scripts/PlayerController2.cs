using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public CharacterController controller;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speed = 12;
    public float gravity = -9.8f;
    public float jumpHeight = 3;

    Vector3 velocity;
    bool isGrounded;
    public bool changeGravity;
    private void Start()
    {
        changeGravity = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += 50;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= 50;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetKeyDown(KeyCode.V) && changeGravity)
        {
            changeGravity = false;
            controller.enabled = true;           
        }
        else if (Input.GetKeyDown(KeyCode.V) && !changeGravity)
        {
            changeGravity = true;
            controller.enabled = false;
        }
        if (changeGravity)
        {
            Physics.gravity = new Vector3(-9, 0, 0);
            Turn();
        }
        else if (!changeGravity)
        {
            Physics.gravity = new Vector3(0, -9, 0);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    private void Turn()
    {
        Vector3 angles = transform.eulerAngles;
        float x = angles.z -= 90;
        transform.rotation = Quaternion.AngleAxis(x, Vector3.forward);
    }

}
