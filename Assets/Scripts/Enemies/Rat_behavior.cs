using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_behavior : MonoBehaviour
{
    #region  Public Variables
    [SerializeField] Transform RayCast;
    [SerializeField] LayerMask RayCastMask;
    [SerializeField] float RayCastLength;
    [SerializeField] float AttackDistance;
    [SerializeField] float MoveSpeed;
    [SerializeField] float Timer;
    #endregion

    #region Private Region
    private RaycastHit2D hit;
    private GameObject Target;
    private Animator Anim;
    private float Distance;
    private bool AttackMode;
    private bool InRange;
    private bool Cooling;
    private float intTimer;
    #endregion

    // Update is called once per frame

    private void Awake() 
    {
        intTimer = Timer;
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(InRange)
        {
            hit = Physics2D.Raycast( RayCast.position , Vector2.right , RayCastLength , RayCastMask);
            RayCastDebugger();
        }
        if(hit.collider != null)
        {
            EnemyLogic();
        }

        else if(hit.collider == null)
        {
            InRange = false;
        }

        if(InRange == false)
        {
            Anim.SetBool("IsWalking",false);
            StopAttacking();
        }
    }

    private void EnemyLogic()
    {
        Distance = Vector2.Distance(transform.position , Target.transform.position);
        if(Distance > AttackDistance)
        {
            Move();
            StopAttacking();
        }
        else if (AttackDistance >= Distance && Cooling == false)
        {
            Attack();
        }

        if(Cooling)
        {
            Anim.SetBool("IsAttacking", false);
        }
    }

    private void Move()
    {
        Anim.SetBool("IsWalking", true);
        if(!Anim.GetCurrentAnimatorStateInfo(0).IsName("Rat Attack"))
        {
            Vector2 TargetPos = new Vector2(Target.transform.position.x ,transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position , TargetPos , MoveSpeed * Time.deltaTime);
        }
    }

    private void Attack()
    {
        Timer = intTimer;
        AttackMode = true;
        Anim.SetBool("IsWalking",false);
        Anim.SetBool("IsAttacking", true);
    }

    private void StopAttacking()
    {
        Cooling = false;
        AttackMode = false;
        Anim.SetBool("IsAttacking", false);
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            Target = collision.gameObject;
            InRange = true;
        }
    }

    private void RayCastDebugger()
    {
        if(Distance > AttackDistance)
        {
            Debug.DrawRay(RayCast.position , Vector2.left * RayCastLength , Color.red);
        }
        else if(Distance < AttackDistance)
        {
            Debug.DrawRay(RayCast.position , Vector2.left * RayCastLength , Color.green);
        }
    }
}
