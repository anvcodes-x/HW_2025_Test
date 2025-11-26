using UnityEngine;
using TMPro;

public class EndScreenUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Final Score: " + score;
    }
}
