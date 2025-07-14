using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

    [Header("Player Stats")]
    public Vector2 friction = new Vector2(-0.1f,0);
    public float speed;
    public float speedRun;
    public float jumpForce = 2f;

    private float _currentSpeed;

    void Update()
    {
        HandleJump();
        HandleMovemnt();
    }

    private void HandleMovemnt()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
        }

        if (myRigidBody.velocity.x > 0f)
        {
            myRigidBody.velocity += friction;
        }
        if (myRigidBody.velocity.x < 0f)
        {
            myRigidBody.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = Vector2.up * jumpForce;
        }
    }
}
