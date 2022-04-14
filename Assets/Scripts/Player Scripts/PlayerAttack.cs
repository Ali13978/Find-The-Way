using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public void Attack1()
    {
        GetComponent<Animator>().SetBool("IsAttacking1",true);
    }

    private void StopAttacking1()
    {
        GetComponent<Animator>().SetBool("IsAttacking1",false);
    }
}
