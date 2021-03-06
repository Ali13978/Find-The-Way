using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField] int ProjectileMinDamage;
    [SerializeField] int ProjectileMaxDamage;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if(this.gameObject.GetComponent<CircleCollider2D>().IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Debug.Log("Enemy Hitted1");
            GameObject Target = other.gameObject.GetComponentInParent<HealthManager>().gameObject;
            GameObject MainTarget = Target.GetComponentInParent<MainRat>().gameObject;
            int Damage = Random.Range(ProjectileMinDamage , ProjectileMaxDamage);
            Target.GetComponent<HealthManager>().TakeDamage(Damage);
            if(Target.GetComponent<HealthManager>().TotalHealth <= 0)
            {
                Destroy(MainTarget);
            }
            Destroy(gameObject);
        }
    }
}
