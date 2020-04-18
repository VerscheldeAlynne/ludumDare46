using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 12f;
    public CharacterController controller;

    float x;
    float z;

    Vector3 move;
    // Update is called once per frame
    void Update()
    {
        //input
       x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //movement
        move = new Vector3(x, 0f, z);

        controller.Move(move *moveSpeed*Time.deltaTime);
    }
}
