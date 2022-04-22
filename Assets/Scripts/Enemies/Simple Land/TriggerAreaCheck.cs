using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private Rat_behavior EnemyParent;

    private void Awake() 
    {
        EnemyParent = GetComponentInParent<Rat_behavior>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            EnemyParent.Target = other.transform;
            EnemyParent.InRange = true;
            EnemyParent.HotZone.SetActive(true);
        }
    }
}
