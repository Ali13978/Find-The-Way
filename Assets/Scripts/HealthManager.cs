using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Gradient MyGradient;
    public Image Fill;
    public Slider MySlider;
    public int TotalHealth;
    [HideInInspector] public int StartingHealth;

    private void Start() 
    {
        StartingHealth = TotalHealth;
        MySlider.maxValue = TotalHealth;
		MySlider.value = TotalHealth;
		Fill.color = MyGradient.Evaluate(MySlider.normalizedValue);
    }

    public void TakeDamage(int Damage)
    {
        TotalHealth = TotalHealth - Damage;
		MySlider.value = TotalHealth;
		Fill.color = MyGradient.Evaluate(MySlider.normalizedValue);
    }
}
