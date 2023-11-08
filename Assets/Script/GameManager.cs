using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;

    [SerializeField] GameObject _winScreen;
    [SerializeField] GameObject _loseScreen;

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
    }

    public void LoseGame()
    {
        PauseGame();
    }
}
