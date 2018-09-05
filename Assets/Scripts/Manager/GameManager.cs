using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using Assets.Assets;
using Assets.Scripts.Manager;

public class GameManager : Singleton<GameManager> {

    [SerializeField]
    private Transform left;
    [SerializeField]
    private Transform top;
    [SerializeField]
    private Transform right;
    [SerializeField]
    private Transform bottom;

    private float roundDuration =0f;
    private float elapsedTime = 0f;
    private GameState gameState= GameState.Running;
    private float score;

    private GameAudio gameAudio;
    void Start()
    {
        gameAudio = FindObjectOfType<GameAudio>();

        SoundManager.Instance.PlayBackingSound(gameAudio.backingSound);
    }
    public GameState GameState{ get { return gameState; } set { gameState = value; } }
    
    public bool IsGameRunning()
    {
        return GameState == GameState.Running;
    }
    public void AddScore(float point)
    {
        score += point;
    }
    public float Score
    {
        get { return score; }
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void Update()
    {
        ManageGameState();
    }
    private void ManageGameState()
    {
        switch (gameState)
        {
            case GameState.Running:
                Time.timeScale = 1;
                break;
            case GameState.WinScreen:
                Time.timeScale = 0;
                break;
            case GameState.GameOver:
                SoundManager.Instance.TurnofAllAudio();
                Time.timeScale = 0;
                break;
        }
    }
 

    public Vector3 LeftBound
    {
        get
        {
            return left.position;
        }
    }
    public Vector3 RightBound
    {
        get
        {
            return right.position;
        }
    }
    public Vector3 TopBound
    {
        get
        {
            return top.position;
        }
    }
    public Vector3 BottomBound
    {
        get
        {
            return bottom.position;
        }
    }
}
