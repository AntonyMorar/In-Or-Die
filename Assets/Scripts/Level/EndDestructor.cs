using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDestructor : MonoBehaviour
{
    public LevelGenerator levelGenerator;
    public CameraController cameraController;

    private int totalBardCounter = 0;
    private int bardCounter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bard"))
        {
            Destroy(other.gameObject);
            bardCounter++;
            totalBardCounter++;
            //Debug.Log(totalBardCounter);

            if (bardCounter == 2)
            {
                levelGenerator.AddNewBards();
                bardCounter = 0;
            }
        }

        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if(totalBardCounter >= 120 && GameManager.instance.gameLevel == 0)
        {
            GameManager.instance.AddGameLevel();
            cameraController.ChangeCameraSpeed(5.7f);

        }
        else if (totalBardCounter >= 300 && GameManager.instance.gameLevel == 1)
        {
            GameManager.instance.AddGameLevel();
            cameraController.ChangeCameraSpeed(6.7f);
        }
        else if (totalBardCounter >= 600 && GameManager.instance.gameLevel == 2)
        {
            GameManager.instance.AddGameLevel();
            cameraController.ChangeCameraSpeed(8.5f);
        }
    }
}
