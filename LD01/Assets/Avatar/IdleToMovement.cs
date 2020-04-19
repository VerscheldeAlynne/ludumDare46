using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleToMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController characterController;
    public Transform parentTransform;
    public playerMovement playerMovement;
    public float Speed = 0f;

    float angle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementPerFrame = playerMovement.GetMove() * playerMovement.moveSpeed * Time.deltaTime;
        Speed = (movementPerFrame.magnitude / Time.deltaTime) / 5; // Bodgy fix as max speed seems to be ~5;

        angle = Mathf.Atan2(playerMovement.GetX(), playerMovement.GetZ()) * 180/ Mathf.PI;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("InputSpeed", Speed);
        //Vector3 newAngle = new Vector3(0f, Vector3.Angle(PreviousFramePosition, parentTransform.position) * 360, 0f);
        Vector3 newAngle = new Vector3(0f, angle, 0f);
        gameObject.transform.rotation = Quaternion.Euler(newAngle);
    }




}
