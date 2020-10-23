using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    private PlayerController player;

    public float currentPoints = 0;

    public float currentMultiplicator = 1;

    private Slider lifeBar;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            SetupGameScene();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            GameSceneUpdate();
        }
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

    public void SetupGameScene()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        lifeBar = GameObject.FindGameObjectWithTag("LifeBar").GetComponent<Slider>();
        lifeBar.maxValue = player.maxLife;
    }

    public void GameSceneUpdate()
    {
        lifeBar.value = player.currentLife;
        if (player.currentLife <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void OnEnemyDestroyed(GameObject enemy)
    {
        currentPoints += enemy.GetComponent<EnemyController>().value * currentMultiplicator;
        currentMultiplicator += 0.1f;
    }

}
