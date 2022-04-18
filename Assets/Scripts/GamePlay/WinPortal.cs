using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Current Level" , (PlayerPrefs.GetInt("Current Level") + 1));
            FindObjectOfType<WinFailManager>().PlayerWin();
        }
    }
}
