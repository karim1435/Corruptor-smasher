using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text timerText;
    public GameObject gameCanvas;
    public Text gameOverText;

    public Text scoreText;
    void Update()
    {
        if (scoreText)
        {
            scoreText.text = GameManager.instance.Score.ToString();
        }
        if (timerText)
            timerText.text =FloatToTime(GameManager.instance.GetRemainingTime());
        if (!GameManager.instance.IsGameRunning()&&gameCanvas)
        {
            gameCanvas.SetActive(true);
            if (gameOverText)
                gameOverText.text = GameManager.instance.GameState == GameState.WinScreen ? "You won!" : "Game Over";
        }
    }
    string FloatToTime(float value)
    {
        string minutes = Mathf.Floor(value / 60.0f).ToString("0");
        string seconds = (value % 60.0f).ToString("00");
        string time = minutes + ":" + seconds;
        return time;
    }
}
