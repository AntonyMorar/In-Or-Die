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

    [Header("External Scripts")]
    [SerializeField] private GameObject MainMenu;

    [Header("Debug Settings")]
    [SerializeField] private bool debug;

    public bool isGamePlaying { get; private set; }
    public bool isGamePaused { get; private set; }

    public void GamePlay(bool _play = true)
    {
        isGamePlaying = _play;
    }

    public void PauseGame(bool _pause = true)
    {
        isGamePaused = _pause;
    }

    public void RestartGame()
    {
        isGamePlaying = false;
        isGamePaused = false;
        SceneManager.LoadScene("Game");
    }

    public void StartGame()
    {
        isGamePlaying = true;
    }
}
