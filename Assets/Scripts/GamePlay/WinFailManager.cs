using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFailManager : MonoBehaviour
{
    [SerializeField] GameObject RetryCanvas;
    [SerializeField] GameObject WinCanvas;
    // Start is called before the first frame update
    void Start()
    {
        DisableOtherCanvas();
    }
    public void PlayerLost()
    {
        DisableOtherCanvas();
        RetryCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayerWin()
    {
        DisableOtherCanvas();
        WinCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    private void DisableOtherCanvas()
    {
        RetryCanvas.SetActive(false);
        WinCanvas.SetActive(false);
    }
}
