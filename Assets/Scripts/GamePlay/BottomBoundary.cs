using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBoundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject Player = other.gameObject;
            Player.GetComponent<PlayerMovement>().Respawn();
        }
    }
}
