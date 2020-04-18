﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller;


    public float moveSpeed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    float x;
    float z;

    Vector3 move;
    Vector3 velocity;
    bool isGrounded;



    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);



        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //input
       x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //movement
        move = new Vector3(x, 0f, z);

        controller.Move(move *moveSpeed*Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
