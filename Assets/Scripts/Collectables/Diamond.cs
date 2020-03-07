using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] GameObject diamondParticlesPrefab;
    private bool playerStep;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !playerStep)
        {
            TrappedDiamond();
            playerStep = true;
        }
    }

    private void TrappedDiamond()
    {
        // Play Diamond Audio
        SoundManager.instance.PlaySound("Diamond");
        // Add score to game manager score
        AddDiamondsScore(1);
        //Instantiate particles
        GameObject particlesClone = Instantiate(diamondParticlesPrefab, transform.position, Quaternion.identity);
        particlesClone.transform.SetParent(transform);
        // Diamond Animation
        LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.4f).setEase(LeanTweenType.easeOutBounce);
        StartCoroutine(DestroyDiamond());
    }

    private IEnumerator DestroyDiamond()
    {
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);
    }

    private void AddDiamondsScore(int diamond = 1)
    {
        GameManager.instance.addGems(diamond);
    }
}
