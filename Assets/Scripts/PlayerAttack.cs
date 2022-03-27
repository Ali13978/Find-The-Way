using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack1();
    }

    private void Attack1()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetBool("IsAttacking1",true);
        }
    }

    private void StopAttacking1()
    {
        GetComponent<Animator>().SetBool("IsAttacking1",false);
    }
}
