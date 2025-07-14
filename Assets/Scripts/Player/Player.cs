using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

    [Header("Player Stats")]
    public Vector2 friction = new Vector2(-0.1f,0);
    public float speed;
    public float speedRun;
    public float jumpForce = 2f;
        
    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public Animator animator;
    public float playerSwapDuration = .1f;

    private bool _isRunning = false;
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
            animator.speed = 1.5f;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, playerSwapDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, playerSwapDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
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
            myRigidBody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidBody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
