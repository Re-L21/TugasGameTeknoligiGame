using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthPoints;

    public TextMeshProUGUI highestScore;
    public TextMeshProUGUI currentScore;

    public TextMeshProUGUI highestScorePanel;
    public TextMeshProUGUI currentScorePanel;

    public GameObject gameOverPanelUI;
    public Slider slider;

    public void SetTextHealthBar(int maxHealth, int currentHealth)
    {
        healthPoints.SetText(currentHealth + " / " + maxHealth);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHeatlh(int health)
    {
        slider.value = health;
    }

    public void SetPanelScoreUI(int highScore, int score)
    {
        gameOverPanelUI.SetActive(true);

        highestScorePanel.SetText("Highest Score : " + highScore);
        currentScorePanel.SetText("Score : " + score);
    }

}
