using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject[] InventoryItems;
    [SerializeField] GameObject[] CanvasInventoryItems;
    string SelectedItem;
    // Start is called before the first frame update
    void Start()
    {
        DisabeOtherItems();
    }

    public void ShieldSelected()
    {
        DisabeOtherItems();
        SelectedItem = "Shield";
        CanvasInventoryItems[0].GetComponent<Image>().color = Color.green;
        InventoryItems[0].SetActive(true);
    }
    public void MukaSelected()
    {
        DisabeOtherItems();
        SelectedItem = "Muka";
        CanvasInventoryItems[1].GetComponent<Image>().color = Color.green;
        InventoryItems[1].SetActive(true);
    }
    public void AppleSelected()
    {
        DisabeOtherItems();
        SelectedItem = "Apple";
        CanvasInventoryItems[2].GetComponent<Image>().color = Color.green;
        InventoryItems[2].SetActive(true);
    }

    public void HealthPotionSelected()
    {
        DisabeOtherItems();
        SelectedItem = "Health Potion";
        CanvasInventoryItems[3].GetComponent<Image>().color = Color.green;
        InventoryItems[3].SetActive(true);
    }
    public void ManaPotionSelected()
    {
        DisabeOtherItems();
        SelectedItem = "Mana Potion";
        CanvasInventoryItems[4].GetComponent<Image>().color = Color.green;
        InventoryItems[4].SetActive(true);
    }
    private void DisabeOtherItems()
    {
        foreach (GameObject item in CanvasInventoryItems)
        {
            item.GetComponent<Image>().color = Color.yellow;
        }
        foreach (GameObject item in InventoryItems)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
