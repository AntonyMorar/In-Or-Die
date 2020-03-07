using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDestructor : MonoBehaviour
{
    public LevelGenerator levelGenerator;

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
        if(totalBardCounter >= 10 && GameManager.instance.gameLevel == 0)
        {
            GameManager.instance.AddGameLevel();
        }else if (totalBardCounter >= 25 && GameManager.instance.gameLevel == 1)
        {
            GameManager.instance.AddGameLevel();
        }
        else if (totalBardCounter >= 45 && GameManager.instance.gameLevel == 2)
        {
            GameManager.instance.AddGameLevel();
        }
    }
}
