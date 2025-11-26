using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Drag ScoreText here

    public void UpdateScoreUI(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + newScore;
        }
    }
}
