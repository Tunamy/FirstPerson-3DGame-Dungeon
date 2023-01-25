using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CharacterController characterController;

    public float speed = 5;
    public float gravity = -9.8f;
    public float jumpForce = 300;
    
    private Vector3 velocity;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundLayer;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime); //*spreenspeed si quiero meterle sprin

        //gravedad

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        //salto

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity * Time.deltaTime);
        }

        
    }
}
