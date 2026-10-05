using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public bool isPaused;
    
    public bool isPauseMenuEnabled = true;
    
    public List<Obstacle> obstacleList;
    
    public PlayerController playerController;
    
    public EndScreen endScreen;
    
    public bool isGameOver;

    public int score;

    public TMP_Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        obstacleList = new List<Obstacle>();
    }

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }
        if (obstacleList != null && playerController)
        {
            if (obstacleList.Count <= 0 && playerController.controlledPawn)
            {
                WinGame();
            }
        }
        if (playerController && !playerController.controlledPawn)
        {
            LoseGame();
        }

        if (scoreText)
        {
            scoreText.text = "" + score;
        }
    }

    public void ResetGameState()
    {
        isPaused = false;
        isPauseMenuEnabled = true;
        isGameOver = false;
        score = 0;
        
        Time.timeScale = 1f;

        playerController = null;
        endScreen = null;
        
        obstacleList.Clear();
    }

    private void LoseGame()
    {
        isPauseMenuEnabled = false;
        Debug.Log("You lose!");
        if (endScreen)
        { 
            endScreen.ShowEndScreen("Fail!");
        } 
        isPaused = true;
        Time.timeScale = 0f;
        isGameOver = true;
    }

    private void WinGame()
    {
        isPauseMenuEnabled = false;
        Debug.Log("You win!");
        if (endScreen)
        {
            endScreen.ShowEndScreen("Victory!");
        }
        isPaused = true;
        Time.timeScale = 0f;
        isGameOver = true;
    }
}
