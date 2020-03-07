using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public void CallToRestartGame()
    {
        GameManager.instance.RestartGame();
    }
}
