using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_behavior : MonoBehaviour
{
    #region  Public Variables
    [SerializeField] int DamageMin;
    [SerializeField] int DamageMax;
    [HideInInspector] private int Damage;
    [SerializeField] float AttackDistance;
    [SerializeField] float MoveSpeed;
    [SerializeField] float Timer;
    [SerializeField] Transform LeftLimit;
    [SerializeField] Transform RightLimit;
    [HideInInspector] public Transform Target;
    [HideInInspector] public bool InRange;
    public GameObject HotZone;
    public GameObject TriggerArea;
    #endregion

    #region Private Region
    private Animator Anim;
    private float Distance;
    private bool AttackMode;
    private bool Cooling;
    private float intTimer;
    #endregion

    // Update is called once per frame

    private void Awake() 
    {
        SelectTarget();
        intTimer = Timer;
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(!InsideOfLimits() && !InRange && !Anim.GetCurrentAnimatorStateInfo(0).IsName("Rat Attack"))
        {
            SelectTarget();
        }
        if(!AttackMode)
        {
            Move();
        }
        if(InRange)
        {
            EnemyLogic();
        }
    }

    void CoolDown()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0 && Cooling && AttackMode)
        {
            Cooling = false;
            Timer = intTimer;
        }
    }

    private void EnemyLogic()
    {
        Distance = Vector2.Distance(transform.position , Target.position);
        if(Distance > AttackDistance)
        {
            StopAttacking();
        }
        else if (AttackDistance >= Distance && Cooling == false)
        {
            Attack();
        }

        if(Cooling)
        {
            CoolDown();
            Anim.SetBool("IsAttacking", false);
        }
    }

    private void Move()
    {
        Anim.SetBool("IsWalking", true);
        if(!Anim.GetCurrentAnimatorStateInfo(0).IsName("Rat Attack"))
        {
            Vector2 TargetPos = new Vector2(Target.position.x ,transform.position.y);
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
    public void TriggerCooling()
    {
        Cooling = true;
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > LeftLimit.position.x && transform.position.x < RightLimit.position.x;
    }

    public void SelectTarget()
    {
        float DistanceToLeft = Vector2.Distance(transform.position , LeftLimit.position);
        float DistanceToRight = Vector2.Distance(transform.position , RightLimit.position);
        if(DistanceToLeft > DistanceToRight)
        {
            Target = LeftLimit;
        }
        else
        {
            Target = RightLimit;
        }

        FlipSprite();
    }

    public void FlipSprite()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > Target.position.x)
        {
            rotation.y = 180;
            GetComponent<HealthManager>().MySlider.gameObject.transform.localScale = new Vector3(-0.01f , 0.01f , 0.01f);
        }
        else
        {
            rotation.y = 0;
            GetComponent<HealthManager>().MySlider.gameObject.transform.localScale = new Vector3(0.01f , 0.01f , 0.01f);
        }
        transform.eulerAngles = rotation;
    }

    public void DamagePlayer()
    {
        Damage = Random.Range(DamageMin , DamageMax);
        Target.gameObject.GetComponent<HealthManager>().TakeDamage(Damage);
    }
}
