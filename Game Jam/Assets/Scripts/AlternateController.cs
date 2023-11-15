using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateController : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 10;
    float horizontal = 0;
    float vertical = 0;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    Vector3 velocity;
    public float gravity = -9.8f;
    public float jumpHeight = 3;

    private float threshold = 0.01f;
    public float _force, _maxSpeed;

    [SerializeField]
    private float _currentSpeed, z, x;

    private Vector3 _direction;
    private Rigidbody _rBody;

    //Audio
    public bool isMoving = false;


    void Start()
    {
        _direction = Vector3.zero;
        _rBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }

        velocity.y += gravity * Time.deltaTime;

 
    }
    void FixedUpdate()
    {
        //For Debugging
        _currentSpeed = _rBody.velocity.magnitude;
        if (_currentSpeed < 0)
        {
            _currentSpeed = 0;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            _direction = transform.right * x + transform.forward * z;
            _direction.Normalize();

            _rBody.AddForce(_direction * _force, ForceMode.Acceleration);

            if (_rBody.velocity.magnitude > _maxSpeed)
            {
                _rBody.velocity = _rBody.velocity.normalized * _maxSpeed;
            }

            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
    }
   
    
}
