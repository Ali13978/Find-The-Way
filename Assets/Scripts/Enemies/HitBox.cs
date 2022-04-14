using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private Rat_behavior ParentRat;
    // Start is called before the first frame update
    void Start()
    {
        ParentRat = GetComponentInParent<Rat_behavior>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ParentRat.DamagePlayer();
        }
    }

}
