using UnityEngine;
using TMPro; 

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void UpdateScoreUI(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }
}