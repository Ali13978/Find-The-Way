using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    [SerializeField] int MinPlayerAttack;
    [SerializeField] int MaxPlayerAttack;
    GameObject Target;
    GameObject MainTarget;
    public bool TargetDied= false;

    private void Update() 
    {
        if(TargetDied)
        {
            Target.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Enemy Body"))
        {
            Target = other.gameObject.GetComponentInParent<HealthManager>().gameObject;
            MainTarget = Target.GetComponentInParent<MainRat>().gameObject;
            int Damage = Random.Range(MinPlayerAttack , MaxPlayerAttack);
            Target.GetComponent<HealthManager>().TakeDamage(Damage);
            if(Target.GetComponent<HealthManager>().TotalHealth <= 0)
            {
                Target.GetComponent<Rigidbody2D>().bodyType =RigidbodyType2D.Static;
                Target.GetComponent<Animator>().SetBool("IsAttacking" ,false);
                Target.GetComponent<Animator>().SetBool("IsWalking", false);
                Target.GetComponent<Animator>().SetBool("IsDied",true);
                TargetDied = true;
            }
        }
    }

    public void DestroyMainTarget()
    {
        TargetDied = false;
        Destroy(MainTarget);
    }
}
