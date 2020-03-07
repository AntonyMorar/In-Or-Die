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
    private float lastBardPosX = 27f;
    private bool nextIsDarkMaterial = true;

    // Level values
    private Hashtable ringDistanceInit = new Hashtable();
    private Hashtable diamondDistanceInit = new Hashtable();
    private Hashtable bardMaterials = new Hashtable();
    private Hashtable darkBardMaterials = new Hashtable();

    // Ring variables
    private float ringDistance;

    // Gem Variables
    private float diamondDistance;

    private void Awake()
    {
        //Initial values
        ringDistanceInit.Add((int)0, 19f);
        ringDistanceInit.Add((int)1, 23f);
        ringDistanceInit.Add((int)2, 28f);
        ringDistanceInit.Add((int)3, 33f);

        diamondDistanceInit.Add((int)0, 49f);
        diamondDistanceInit.Add((int)1, 37f);
        diamondDistanceInit.Add((int)2, 29f);
        diamondDistanceInit.Add((int)3, 25f);
    }

    private void Start()
    {
        ringDistance = (float)ringDistanceInit[0];
        diamondDistance = (float)diamondDistanceInit[0];

        bardMaterials.Add((int)0, redMaterials[0]);
        bardMaterials.Add((int)1, blueMaterials[0]);
        bardMaterials.Add((int)2, greenMaterials[0]);
        bardMaterials.Add((int)3, blackMaterials[0]);

        darkBardMaterials.Add((int)0, redMaterials[1]);
        darkBardMaterials.Add((int)1, blueMaterials[1]);
        darkBardMaterials.Add((int)2, greenMaterials[1]);
        darkBardMaterials.Add((int)3, blackMaterials[1]);
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
           
            topBard.GetComponent<MeshRenderer>().material = (Material)darkBardMaterials[GameManager.instance.gameLevel];
            bottomBard.GetComponent<MeshRenderer>().material = (Material)darkBardMaterials[GameManager.instance.gameLevel];
            nextIsDarkMaterial = false;
        }
        // Normal material
        else
        {
            topBard.GetComponent<MeshRenderer>().material = (Material)bardMaterials[GameManager.instance.gameLevel];
            bottomBard.GetComponent<MeshRenderer>().material = (Material)bardMaterials[GameManager.instance.gameLevel];
            nextIsDarkMaterial = true;
        }

        // Add Position
        lastBardPosX += 3;
    }

    private void AddNewRing()
    {
        if (Camera.main.transform.position.x >= ringDistance)
        {
            GameObject ringClone = Instantiate(ringPrefab, new Vector3(ringDistance + Random.Range(22f, 30f), Random.Range(-1f, 2f), 0f), Quaternion.Euler(0f, 90f, 0f));
            if (GameManager.instance.gameLevel == 1)
            {
                ringClone.transform.localScale = new Vector3(0.9f,0.9f,0.9f);
            }
            else if (GameManager.instance.gameLevel == 2)
            {
                ringClone.transform.localScale = new Vector3(0.77f, 0.77f, 0.77f);
            }
            else if (GameManager.instance.gameLevel == 3)
            {
                ringClone.transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
            }
            ringDistance += (float)ringDistanceInit[GameManager.instance.gameLevel];
        }

    }

    private void AddNewDiamond()
    {
        if (Camera.main.transform.position.x >= diamondDistance)
        {
            Instantiate(diamondPrefab,new Vector3(diamondDistance + Random.Range(20f,35f), Random.Range(-6f,8f),0f),Quaternion.identity);
            diamondDistance += (float)diamondDistanceInit[GameManager.instance.gameLevel];
        }
    }
}
