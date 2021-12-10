using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManageScenes : MonoBehaviour
{    
    public void GameScene()
    {
        GameManager.instance.StartGame();
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
