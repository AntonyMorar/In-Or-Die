using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start thr Singleton
    public static GameManager instance;

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // End of thr Singleton

    [Header("Player")]
    [SerializeField] private int score = 0;
    [SerializeField] private int highScore;
    [SerializeField] private int gems = 0;
    [SerializeField] private int totalGems;

    [Header("Debug Settings")]
    [SerializeField] private bool debug;

    public bool isGamePlaying;

    public void GamePlay()
    {
        isGamePlaying = true;
    }

    public void GameOver()
    {
        //TODO destroy player
        isGamePlaying = false;
        UIManager.instance.GoToMenu(1);
    }

    public void RestartGame()
    {
        UIManager.instance.GoToMenu(2);
        RestartGameValues();
        SceneManager.LoadScene("Game");
    }

    private void RestartGameValues()
    {
        score = 0;
        gems = 0;
        TimeManager.instance.ResetPlayerTimeStatus();
    }

    public int GetScore() { return score; }

    public void addScore(int _score)
    {
        score += _score;
    }

    public void addGems(int _gems)
    {
        gems = _gems;
    }
}
