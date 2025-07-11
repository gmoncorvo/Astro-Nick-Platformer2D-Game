using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

    [Header("Player Stats")]
    //public Vector2 velocity;
    public float speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(-speed, myRigidBody.velocity.y);
        }

    }
}
