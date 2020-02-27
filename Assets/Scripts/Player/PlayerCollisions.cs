using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bard"))
        {
            Debug.Log("Entra a colission");
            DestroyPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra a triger sdf");

        if (other.gameObject.CompareTag("EndDestructor") || other.gameObject.CompareTag("Bard"))
        {
            Debug.Log("Entra a triger");
            DestroyPlayer();
        }
    }


    private void DestroyPlayer()
    {
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1);
        GameManager.instance.RestartGame();
    }
}
