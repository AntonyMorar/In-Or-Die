using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
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
        timeBarImage.fillAmount = TimeManager.instance.playerSlowTime / TimeManager.instance.playerMaxSlowTime;
    }

    private void SetScoreText()
    {
        scoreText.SetText(GameManager.instance.GetScore().ToString());
    }
}
