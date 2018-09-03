using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Manager;

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
    void Update()
    {
        SetScore();
        CreateTimer();
        WinOrGameover();
    }
    private void SetScore()
    {
        if (scoreText)
            scoreText.text = GameManager.Instance.Score.ToString();
    }
    private void CreateTimer()
    {
        if (timerText)
            timerText.text = FormatStringToTimer(GameManager.Instance.GetRemainingTime());
    }
    private void WinOrGameover()
    {
        if (!GameManager.Instance.IsGameRunning() && gameCanvas)
        {
            gameCanvas.SetActive(true);
            if (gameOverText)
                gameOverText.text = GameManager.Instance.GameState == GameState.WinScreen ? "You won!" : "Game Over";
        }
    }

    string FormatStringToTimer(float value)
    {
        string minutes = Mathf.Floor(value / 60.0f).ToString("0");
        string seconds = (value % 60.0f).ToString("00");
        string time = minutes + ":" + seconds;
        return time;
    }
}
