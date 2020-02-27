using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private void Update()
    {
        if (GameManager.instance.isGamePlaying)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
