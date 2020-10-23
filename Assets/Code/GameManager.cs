using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        QuitGame();
    }

}