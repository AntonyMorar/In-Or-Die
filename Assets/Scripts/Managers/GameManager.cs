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
    public int gameLevel { get; private set; }
    public bool isPlayerDead;

    [Header("Game")]
    public bool isGamePlaying;

    [Header("Debug Settings")]
    [SerializeField] private bool debug;

    private void Start()
    {
        StartCoroutine(PlayBackgrounsSong());
    }

    private IEnumerator PlayBackgrounsSong()
    {
        yield return new WaitForSeconds(0.5f);
        // Play the game background sound
        SoundManager.instance.PlaySound("Background");
    }

    public void GamePlay()
    {
        isGamePlaying = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisions>().PlayTrail();
    }

    public void GameOver()
    {
        isGamePlaying = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        RestartGameValues();
        StartGame();
    }

    private void RestartGameValues()
    {
        score = 0;
        gems = 0;
        TimeManager.instance.ResetPlayerTimeStatus();
        isPlayerDead = false;
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

    public void AddGameLevel()
    {
        if (gameLevel < 3)
        {
            gameLevel++;
        }
    }
}
