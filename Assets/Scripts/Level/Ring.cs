using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject explotionPrefab;

    [SerializeField] private float secondsGived = 1f;
    [SerializeField] private int scoreGived = 1;

    private bool playerStep;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !playerStep)
        {
            playerStep = true;

            GameManager.instance.addScore(scoreGived);
            TimeManager.instance.AddSlowTime(secondsGived);

            GameObject explotionClone = Instantiate(explotionPrefab, transform.position, Quaternion.identity);
            explotionClone.transform.SetParent(transform);

            // Play ring sound
            SoundManager.instance.PlaySound("RingPass");

            LeanTween.scale(gameObject, Vector3.zero, 0.25f).setDelay(0.2f).setOnComplete(DestroyMe);
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
