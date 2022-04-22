using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotionsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI NoOfPotionsText;
    [SerializeField] int MinHealthAdd;
    [SerializeField] int MaxHealthAdd;
    [SerializeField] int NoOfPotions;
    HealthManager PlayerHealthManager;
    // Start is called before the first frame update
    void Start()
    {
        NoOfPotionsText.text = "X " + NoOfPotions.ToString();
        PlayerHealthManager = FindObjectOfType<PlayerMovement>().GetComponent<HealthManager>();
    }

    public void PotionButtonDown()
    {
        if(NoOfPotions <= 0)
        {return;}
        if(PlayerHealthManager.TotalHealth > PlayerHealthManager.StartingHealth - MinHealthAdd)
        {return;}
        int FinalHealthAdd = Random.Range(MinHealthAdd , MaxHealthAdd);
        PlayerHealthManager.increaseHealth(FinalHealthAdd);
        NoOfPotions--;
        NoOfPotionsText.text = "X " + NoOfPotions.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
