using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    [SerializeField] float JumpSpeed;
    [SerializeField] TextMeshProUGUI NoOfBarsText;
    
    bool OnGround = false;

    CapsuleCollider2D MyCapsuleCollider;
    Rigidbody2D MyRigidBody;
    Animator MyAnimator;
    Vector2 RespawnPos;

    HealthManager MyHealthManager;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        MyCapsuleCollider = GetComponent<CapsuleCollider2D>();
        MyRigidBody = GetComponent<Rigidbody2D>();
        RespawnPos = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
        MyAnimator = GetComponent<Animator>();
        MyHealthManager = GetComponent<HealthManager>();
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        NoOfBarsText.text = "X " + MyHealthManager.NoOfBars.ToString();
        CheckGround();
        Movement();
        FlipSprite();
        if(GetComponent<HealthManager>().TotalHealth <= 0)
        {
            Respawn();
        }
    }

    private void Movement()
    {
        float ControlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
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
    public void Jump()
    {
        if (!OnGround)
        { return; }
        Vector2 JumpVelocity = new Vector2(0f, JumpSpeed);
        MyRigidBody.velocity += JumpVelocity;
    }

    public void Respawn()
    {
        MyHealthManager.NoOfBars -- ;
        if(MyHealthManager.NoOfBars <= 0)
        {
            FindObjectOfType<WinFailManager>().PlayerLost();
        }
        MyHealthManager.TotalHealth = MyHealthManager.StartingHealth;
        MyHealthManager.MySlider.value = MyHealthManager.TotalHealth;
        MyHealthManager.Fill.color = MyHealthManager.MyGradient.Evaluate(MyHealthManager.MySlider.normalizedValue);
        transform.position = RespawnPos;
    }
}
