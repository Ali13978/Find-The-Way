using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public Gradient MyGradient;
    public Image Fill;
    public Slider MySlider;
    public int TotalHealth;
    public int NoOfBars;
    [HideInInspector] public int StartingHealth;

    private void Start() 
    {
        StartingHealth = TotalHealth;
        MySlider.maxValue = TotalHealth;
		MySlider.value = TotalHealth;
		Fill.color = MyGradient.Evaluate(MySlider.normalizedValue);
    }

    public void increaseHealth(int IncreasedHealth)
    {
        TotalHealth += IncreasedHealth;
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
