using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSystem : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("Current Level" , 1);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Current Level" , 1 ));
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Current Level" , 1 ));
    }
    public void Retry()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Current Level" , 1 ));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
