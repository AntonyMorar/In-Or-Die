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
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        Debug.Log("Reaady to destroy");
        yield return new WaitForSeconds(0.6f);
        GameManager.instance.GameOver();
    }
}
