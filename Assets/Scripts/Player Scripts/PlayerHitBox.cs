using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    [SerializeField] int MinPlayerAttack;
    [SerializeField] int MaxPlayerAttack;

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Enemy Body"))
        {
            GameObject Target = other.gameObject.GetComponentInParent<HealthManager>().gameObject;
            int Damage = Random.Range(MinPlayerAttack , MaxPlayerAttack);
            Target.GetComponent<HealthManager>().TakeDamage(Damage);
            if(Target.GetComponent<HealthManager>().TotalHealth <= 0)
            {
                Destroy(Target.GetComponentInParent<AudioListener>().gameObject);
            }
        }
    }
}
