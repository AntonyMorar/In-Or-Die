using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject bardPrefab;
    public Material[] redMaterials = new Material[2];

    [SerializeField]
    private float lastBardPosX = 21f;
    private bool nextIsDarkMaterial = true;

    public void AddNewBards()
    {
        //Instance Top bard
        GameObject topBard = Instantiate(bardPrefab, new Vector3(lastBardPosX + 3f, Random.Range(5.5f,9f), 0f), Quaternion.identity);
        topBard.transform.SetParent(transform);

        //Instance Bottom bard
        GameObject bottomBard = Instantiate(bardPrefab, new Vector3(lastBardPosX + 3f, Random.Range(-5f, -7f), 0f), Quaternion.identity);
        bottomBard.transform.SetParent(transform);

        //Asign Material
        if (nextIsDarkMaterial)
        {
            topBard.GetComponent<MeshRenderer>().material = redMaterials[1];
            bottomBard.GetComponent<MeshRenderer>().material = redMaterials[1];
            nextIsDarkMaterial = false;
        }
        else
        {
            nextIsDarkMaterial = true;
        }

        // Add Position
        lastBardPosX += 3;
    }
}
