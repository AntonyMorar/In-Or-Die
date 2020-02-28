using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start Singleton
    public static UIManager instance;

    [Header("Events")]
    public GameObject eventSystem;

    [Header("Menu Canvas")]
    public GameObject[] menus = new GameObject[3];

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // End songleton

    private void Start()
    {
    }

    public void ShowMenu(int menuNum, bool show = true)
    {
        menus[menuNum].SetActive(show);
    }

    public void GoToMenu(int menuNum)
    {
        for (int i = 0; i<menus.Length;i++)
        {
            if (i == menuNum) { ShowMenu(menuNum); }
            else { ShowMenu(i, false); }
        }
    }
}
