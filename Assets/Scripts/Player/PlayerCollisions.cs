using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [Header ("Player Prefabs")]
    [SerializeField] private GameObject playerExplotionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bard"))
        {
            DestroyPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra a triger sdf");

        if (other.gameObject.CompareTag("EndDestructor") || other.gameObject.CompareTag("Bard"))
        {
            DestroyPlayer();
        }
    }


    private void DestroyPlayer()
    {
        GameManager.instance.isPlayerDead = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        GameObject explotionClone = Instantiate(playerExplotionPrefab, transform.position, Quaternion.identity);
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
        GameManager.instance.GameOver();
    }
}
