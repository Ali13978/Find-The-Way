using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    [SerializeField] float JumpSpeed;
    
    bool OnGround = false;

    CapsuleCollider2D MyCapsuleCollider;
    Rigidbody2D MyRigidBody;
    Animator MyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        MyCapsuleCollider = GetComponent<CapsuleCollider2D>();
        MyRigidBody = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        Jump();
        Movement();
        FlipSprite();
    }

    private void Movement()
    {
        float ControlThrow = Input.GetAxis("Horizontal");
        Vector2 PlayerVelocity = new Vector2(ControlThrow*MovementSpeed, MyRigidBody.velocity.y);
        MyRigidBody.velocity = PlayerVelocity;
        bool IfPlayerHasHorizontalSpeed = Mathf.Abs(MyRigidBody.velocity.x) > Mathf.Epsilon;
        MyAnimator.SetBool("IsRunning", IfPlayerHasHorizontalSpeed);
    }
    
    private void FlipSprite()
    {
        bool IfPlayerHasHorizontalSpeed = Mathf.Abs(MyRigidBody.velocity.x) > Mathf.Epsilon;

        if (IfPlayerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(MyRigidBody.velocity.x), 1f);
        }
    }

    private void CheckGround()
    {
        if(MyCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            OnGround = true;
        }
        else
        {
            OnGround = false;
        }
    }
    private void Jump()
    {
        if (!OnGround)
        { return; }
        else if (Input.GetButtonDown("Jump"))
        {
            Vector2 JumpVelocity = new Vector2(0f, JumpSpeed);
            MyRigidBody.velocity += JumpVelocity;
        }
    }
}
