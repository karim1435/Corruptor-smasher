using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using Assets.Assets;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private Transform left;
    public Transform top;
    public Transform right;
    public Transform bottom;

    public float roundDuration = 60f;
    private float elapsedTime = 0f;
    public static GameManager instance;
    private GameState gameState;
    private float score;

    public GameState GameState
    {
        get
        {
            return gameState;
        }
        set
        {
            gameState=value;
        }
    }
    void Awake()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 1;
        gameState = GameState.Running;
    }
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
        elapsedTime += Time.deltaTime;
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
            default:
                break;
        }
        
    }
    public  Vector3 Left
    {
        get
        {
            return left.position;
        }
    }
    public  Vector3 Right
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
public enum GameState { Running,WinScreen,GameOver}