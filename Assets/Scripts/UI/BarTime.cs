using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BarTime : MonoBehaviour
{
    private Image timeBarImage;

    private void Start()
    {
        timeBarImage = GetComponent<Image>();
    }

    private void Update()
    {
        SetTimeBar();
    }

    private void SetTimeBar()
    {
        timeBarImage.fillAmount = TimeManager.instance.playerSlowTime / TimeManager.instance.playerMaxSlowTime;
    }
}
