using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;      // Top left score
    public TextMeshProUGUI finalScoreText; // Game Over score

    public void ShowStartMenu()
    {
        if(startScreen) startScreen.SetActive(true);
        if(gameOverScreen) gameOverScreen.SetActive(false);
        if(scoreText) scoreText.gameObject.SetActive(false);
    }

    public void ShowHUD()
    {
        if(startScreen) startScreen.SetActive(false);
        if(gameOverScreen) gameOverScreen.SetActive(false);
        if(scoreText) scoreText.gameObject.SetActive(true);
    }

    public void ShowGameOver(int score)
    {
        if(startScreen) startScreen.SetActive(false);
        if(gameOverScreen) gameOverScreen.SetActive(true);
        if(scoreText) scoreText.gameObject.SetActive(false);
        if(finalScoreText) finalScoreText.text = "Final Score: " + score;
    }

    public void UpdateScoreUI(int newScore)
    {
        if(scoreText) scoreText.text = "Score: " + newScore;
    }
}