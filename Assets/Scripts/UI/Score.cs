using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("Script Dependencies")]
    [SerializeField] private TimeManager timeManager;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image timeBarImage;

    private void Update()
    {
        SetTimeBar();
        SetScoreText();
    }

    private void SetTimeBar()
    {
        timeBarImage.fillAmount = timeManager.playerSlowTime / timeManager.playerMaxSlowTime;
    }

    private void SetScoreText()
    {
        scoreText.SetText(GameManager.instance.GetScore().ToString());
    }
}
