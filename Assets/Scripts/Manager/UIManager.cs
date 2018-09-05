using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Manager;
using Assets.Assets;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private GameObject gameCanvas;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text bestScoreText;

    private bool beatBestScore=false;

    private float bestScore = 0f;
    void Start()
    {
        bestScore = GetBestScore();
    }
    void Update()
    {
        SetScore();
        WinOrGameover();
    }
    private void SetScore()
    {
        float currentScore= GameManager.Instance.Score;
        SetNewBestScore(currentScore);
        scoreText.text = "Score: " + currentScore.ToString();
    }
    private void SetNewBestScore(float currentScore)
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            beatBestScore = true;
            PlayerPrefs.SetFloat(Saving.BestScore, bestScore);
        }
    }
    private void WinOrGameover()
    {
        if (!GameManager.Instance.IsGameRunning() && gameCanvas)
        {
            ShowFinalResult();

            UpdateBestScore();
        }
    }

    private void ShowFinalResult()
    {
        gameCanvas.SetActive(true);
        if (gameOverText)
            gameOverText.text = GameManager.Instance.GameState == GameState.WinScreen ? "You won!" : "Game Over";
    }

    private void UpdateBestScore()
    {
        Color textColor = beatBestScore ? Color.yellow : Color.white;
        if (bestScoreText)
        {
            bestScoreText.color = textColor;
            bestScoreText.text = GetBestScore().ToString();
        }
    }

    private static float GetBestScore()
    {
        return PlayerPrefs.GetFloat(Saving.BestScore);
    }

}
