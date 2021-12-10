using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance; //used to call from other scripts as a singleton.



    public event Action
        gameOver, collectebleCollected, gameStarted; //used as events, holds references to methods to call later.

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //keeps game object holding the game manager from getting removed from scene.
        }
    }

    public void StartGame()
    {
        gameStarted?.Invoke();
    }

    public void GameOver()
    {
        gameOver?.Invoke(); //invokes all subscribers to game over event.
        StartCoroutine("Menu");
    }

    private IEnumerator Menu() //waits for 1 sec for death effect to take place then sends user to menu scene.
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
    }

    public void CollectiblesCollect()
    {
        collectebleCollected?.Invoke();
    }
    
}