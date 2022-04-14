using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int TotalHealth;

    public void TakeDamage(int Damage)
    {
        Debug.Log(TotalHealth);
        TotalHealth = TotalHealth - Damage;
    }
}
