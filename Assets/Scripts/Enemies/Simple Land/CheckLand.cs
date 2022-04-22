using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLand : MonoBehaviour
{
    private Rat_behavior EnemyParent;

    private void Awake() 
    {
        EnemyParent = GetComponentInParent<Rat_behavior>();
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            EnemyParent.HotZone.SetActive(false);
            EnemyParent.TriggerArea.SetActive(true);
            EnemyParent.InRange = false;
            EnemyParent.SelectTarget();
        }
    }
}
