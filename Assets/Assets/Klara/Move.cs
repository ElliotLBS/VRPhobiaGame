using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -18.81f;
    LookAtPlayer Lookat;

    //public Transform GroundCheck;
    //public float groundDistance = 0.4f;
    //public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    private void Start()
    {
        Lookat = FindObjectOfType<LookAtPlayer>();
    }

    private void Update()
    {
        //isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "gamestart")
        {
            LookAtPlayer.gamestarted = true;
        }
    }

}