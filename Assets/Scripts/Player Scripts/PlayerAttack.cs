using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InventoryManager IManager;
    public void Attack1()
    {
        if(IManager.SelectedItem == "Muka")
        {  
            GetComponent<Animator>().SetBool("IsAttacking1",true);
        }
    }

    private void StopAttacking1()
    {
        GetComponent<Animator>().SetBool("IsAttacking1",false);
    }
}
