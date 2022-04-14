using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private Rat_behavior EnemyParent;
    private bool inRange;
    private Animator Anim;

    private void Awake() 
    {
        EnemyParent = GetComponentInParent<Rat_behavior>();
        Anim = GetComponentInParent<Animator>();
    }

    private void Update() 
    {
        if(inRange && !Anim.GetCurrentAnimatorStateInfo(0).IsName("Rat Attack"))
        {
            EnemyParent.FlipSprite();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            EnemyParent.TriggerArea.SetActive(true);
            EnemyParent.InRange = false;
            EnemyParent.SelectTarget();
        }
    }
}
