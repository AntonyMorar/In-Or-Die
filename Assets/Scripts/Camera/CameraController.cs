using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private float moveSpeed;

    private void Start()
    {
        moveSpeed = 5f;
    }

    private void Update()
    {
        if (GameManager.instance.isGamePlaying)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }

    public void ChangeCameraSpeed(float speed)
    {
        if (speed > 0f && speed < 100f)
        {
            moveSpeed = speed;
        }
    }
}
