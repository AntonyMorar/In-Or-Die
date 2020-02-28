using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private float secondsGived = 1f;
    [SerializeField] private int scoreGived = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.addScore(scoreGived);
            TimeManager.instance.AddSlowTime(secondsGived);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Destroy Ring
    }
}
