using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [Header("Scripts dependecies")]
    [SerializeField] private GameObject gameOverMenuObj;

    [Header ("Player Prefabs")]
    [SerializeField] private GameObject playerExplotionPrefab;


    [SerializeField] private ParticleSystem trail;

    private void Start()
    {
        StopTrail();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bard"))
        {
            DestroyPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndDestructor") || other.gameObject.CompareTag("Bard"))
        {
            DestroyPlayer();
        }
    }


    private void DestroyPlayer()
    {
        // Play player explotion sound
        SoundManager.instance.PlaySound("PlayerExplotion");
        // Stop trail particles
        StopTrail();
        // Globarl bariable player dead true
        GameManager.instance.isPlayerDead = true;
        // disable mes render and collider
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
        // Active game over menu
        gameOverMenuObj.SetActive(true);
    }

    public void PlayTrail()
    {
        trail.Play();
    }

    public void StopTrail()
    {
        trail.Stop();
    }
}
