using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    private PlayerController player;

    private Slider lifeBar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        lifeBar = GameObject.FindGameObjectWithTag("LifeBar").GetComponent<Slider>();
        lifeBar.maxValue = player.maxLife;
    }

    private void Update()
    {
        lifeBar.value = player.currentLife;
    }

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
