using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;

    [SerializeField] GameObject _winScreen;
    [SerializeField] GameObject _loseScreen;
    private void Awake()
    {
        if( _instance != null && _instance != this)
        {
            Destroy(gameObject);
        } 
        else
        {
            _instance = this;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        PauseGame();
        _winScreen.SetActive(true);
    }

    public void LoseGame()
    {
        PauseGame();
        _loseScreen.SetActive(true);
    }

    public void ChangeScene(string name)
    {
        _winScreen.SetActive(false);
        _loseScreen.SetActive(false);
        SceneManager.LoadScene(name);
    }
}
