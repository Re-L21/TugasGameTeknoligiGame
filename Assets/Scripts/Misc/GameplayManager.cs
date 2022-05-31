using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private static int highestScore;
    public int score;

    [SerializeField]private UIManager uiManager;

    private void Start()
    {
        uiManager.currentScore.SetText("Score : " + score);
        uiManager.highestScore.SetText("Score : " + highestScore);
        uiManager.gameOverPanelUI.SetActive(false);

    }

    public void IncrementScore(int newestScore)
    {
        score += newestScore;

        if (highestScore < score)
            highestScore = score;

        uiManager.currentScore.SetText("Score : " + score);
        uiManager.highestScore.SetText("Score : " + highestScore);
    }

    public void SetPanelGameOver()
    {
        uiManager.SetPanelScoreUI(highestScore, score);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
