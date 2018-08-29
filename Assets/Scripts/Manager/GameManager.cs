using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using Assets.Assets;
using Assets.Scripts.Manager;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [SerializeField]
    private Transform left;
    [SerializeField]
    private Transform top;
    [SerializeField]
    private Transform right;
    [SerializeField]
    private Transform bottom;

    private float roundDuration = 60f;
    private float elapsedTime = 0f;
    private GameState gameState;
    private float score;
    void Awake()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 1;
        gameState = GameState.Running;
    }
    public GameState GameState{ get { return gameState; } set { gameState = value; } }
    
    public bool IsGameRunning()
    {
        return GameState == GameState.Running;
    }
    public void AddScore()
    {
        score += 10;
    }
    public float Score
    {
        get { return score; }
    }
    public float GetRemainingTime()
    {
        return roundDuration - elapsedTime;
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void Update()
    {
        TimerTick();
        ManageGameState();
    }

    private void TimerTick()
    {
        elapsedTime += Time.deltaTime;
    }

    private void ManageGameState()
    {
        switch (gameState)
        {
            case GameState.Running:
                if (elapsedTime >= roundDuration)
                {
                    elapsedTime = roundDuration;
                    gameState = GameState.WinScreen;
                }
                break;
            case GameState.WinScreen:
                Time.timeScale = 0;
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                break;
        }
    }

    public Vector3 Left
    {
        get
        {
            return left.position;
        }
    }
    public Vector3 Right
    {
        get
        {
            return right.position;
        }
    }
    public Vector3 Top
    {
        get
        {
            return top.position;
        }
    }
    public Vector3 Bottom
    {
        get
        {
            return bottom.position;
        }
    }
}
