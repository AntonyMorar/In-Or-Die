using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject bardPrefab;
    public GameObject ringPrefab;
    public GameObject diamondPrefab;
    public Material[] redMaterials = new Material[2];
    public Material[] blueMaterials = new Material[2];
    public Material[] greenMaterials = new Material[2];
    public Material[] blackMaterials = new Material[2];

    // Bard variables
    private float lastBardPosX = 21f;
    private bool nextIsDarkMaterial = true;

    [Header("Level values")]
    public Hashtable ringDistanceInit2 = new Hashtable();
    public Hashtable diamondDistanceInit2 = new Hashtable();
    public Hashtable bardMaterials = new Hashtable();

    // Ring variables
    private float ringDistanceInit = 16f;
    private float ringDistance;

    // Gem Variables
    private float diamondDistanceInit = 25f;
    private float diamondDistance;

    private void Start()
    {
        ringDistance = ringDistanceInit;
        diamondDistance = diamondDistanceInit;
        //Initial values
        ringDistanceInit2.Add((int)0, 16f);
        ringDistanceInit2.Add((int)1, 19f);
        ringDistanceInit2.Add((int)2, 22f);
        ringDistanceInit2.Add((int)3, 25f);

        diamondDistanceInit2.Add((int)0, 24);
        diamondDistanceInit2.Add((int)1, 26);
        diamondDistanceInit2.Add((int)2, 28);
        diamondDistanceInit2.Add((int)3, 32);

        bardMaterials.Add((int)0, redMaterials);
        bardMaterials.Add((int)1, blueMaterials);
        bardMaterials.Add((int)2, greenMaterials);
        bardMaterials.Add((int)3, blackMaterials);
    }

    private void Update()
    {
        // Adds Diamond
        AddNewDiamond();
        // Adds ring
        AddNewRing();
    }

    public void AddNewBards()
    {
        //Instance Top bard
        GameObject topBard = Instantiate(bardPrefab, new Vector3(lastBardPosX + 3f, Random.Range(5.5f,9f), 0f), Quaternion.identity);
        topBard.transform.SetParent(transform);

        //Instance Bottom bard
        GameObject bottomBard = Instantiate(bardPrefab, new Vector3(lastBardPosX + 3f, Random.Range(-5f, -7f), 0f), Quaternion.identity);
        bottomBard.transform.SetParent(transform);

        //Asign Dark Material
        if (nextIsDarkMaterial)
        {
            topBard.GetComponent<MeshRenderer>().material = redMaterials[1];
            bottomBard.GetComponent<MeshRenderer>().material = redMaterials[1];
            nextIsDarkMaterial = false;
        }
        // Normal material
        else
        {
            topBard.GetComponent<MeshRenderer>().material = redMaterials[0];
            bottomBard.GetComponent<MeshRenderer>().material = redMaterials[0];
            nextIsDarkMaterial = true;
        }

        // Add Position
        lastBardPosX += 3;
    }

    private void AddNewRing()
    {
        if (Camera.main.transform.position.x >= ringDistance)
        {
            Instantiate(ringPrefab, new Vector3(ringDistance + Random.Range(22f, 27f), Random.Range(-1f, 2f), 0f), Quaternion.Euler(0f, 90f, 0f));
            ringDistance += ringDistanceInit;
        }

    }

    private void AddNewDiamond()
    {
        if (Camera.main.transform.position.x >= diamondDistance)
        {
            Instantiate(diamondPrefab,new Vector3(diamondDistance + Random.Range(20f,35f), Random.Range(-6f,8f),0f),Quaternion.identity);
            diamondDistance += diamondDistanceInit;
        }
    }
}
