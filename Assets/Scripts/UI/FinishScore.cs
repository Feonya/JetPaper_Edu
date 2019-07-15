using UnityEngine;
using UnityEngine.UI;

public class FinishScore : MonoBehaviour
{
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();

        scoreText.text = "总得分：" + TotalScores.score;
    }
}
