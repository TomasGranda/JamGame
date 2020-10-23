using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    private PlayerController player;

    public float currentScore = 0;

    public float currentMultiplier = 1;

    private Slider lifeBarUi;

    private Text multiplierUI;

    private Text scoreUI;

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
        lifeBarUi = GameObject.Find("LifeBar").GetComponent<Slider>();
        multiplierUI = GameObject.Find("Multiplier").GetComponent<Text>();
        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        lifeBarUi.maxValue = player.maxLife;
    }

    public void GameSceneUpdate()
    {
        lifeBarUi.value = player.currentLife;
        multiplierUI.text = "x" + Math.Round(currentMultiplier, 1).ToString();
        scoreUI.text = Math.Floor(currentScore).ToString();

        if (player.currentLife <= 0)
        {
            player.TriggerDeadAnimation();
            if (player.isDestroyed)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }

        currentMultiplier = 2 - player.currentLife / 100;
    }

    public void OnEnemyDestroyed(GameObject enemy)
    {
        currentScore += enemy.GetComponent<EnemyController>().value * currentMultiplier;
    }

    public void OnBossDestroyed(GameObject enemy)
    {
        currentScore += enemy.GetComponent<BossController>().value * currentMultiplier;
    }

}
