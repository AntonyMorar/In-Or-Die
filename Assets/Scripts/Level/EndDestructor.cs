using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDestructor : MonoBehaviour
{
    public LevelGenerator levelGenerator;

    private int bardCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bard") || other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            bardCounter++;

            if (bardCounter == 2)
            {
                levelGenerator.AddNewBards();
                bardCounter = 0;
            }
        }
    }
}
