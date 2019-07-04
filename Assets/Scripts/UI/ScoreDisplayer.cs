using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    private Text scoreText;

    private int currentScore;
    private string scoreTitle;

    private void Start()
    {
        scoreText = GetComponent<Text>();

        currentScore = 0;
        scoreTitle = "分数：";
        scoreText.text = scoreTitle + currentScore;

        TotalScores.score = 0;
    }

    private void FixedUpdate()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        if (currentScore != TotalScores.score)
        {
            currentScore = TotalScores.score;
            scoreText.text = scoreTitle + currentScore;
        }
    }
}
