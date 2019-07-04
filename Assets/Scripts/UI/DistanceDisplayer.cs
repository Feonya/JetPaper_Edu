using UnityEngine;
using UnityEngine.UI;

public class DistanceDisplayer : MonoBehaviour
{
    private Text distanceText;
    private Transform playerTransform;
    private Transform startLineTransform;
    private Transform finishLineTransform;

    private float totalDistanceRatio;
    private int currentDistance;
    private int previousDistance;
    private string distanceTitle;

    private void Start()
    {
        distanceText = GetComponent<Text>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        startLineTransform = GameObject.Find("StartLine").transform;
        finishLineTransform = GameObject.Find("FinishLine").transform;

        totalDistanceRatio = 100.0f / (finishLineTransform.position.x - startLineTransform.position.x);
        currentDistance = 0;
        previousDistance = currentDistance;
        distanceTitle = "路程：";
    }

    private void FixedUpdate()
    {
        CountDistance();
        DisplayDistance();
        CheckScore();
    }

    private void CountDistance()
    {
        float positionDiff = playerTransform.position.x - startLineTransform.position.x;
        if (playerTransform.position.x > finishLineTransform.position.x)
        {
            currentDistance = 100;
        }
        else if (positionDiff >= 0.0f)
        {
            currentDistance = (int)Mathf.Floor(positionDiff * totalDistanceRatio);
        }
    }

    private void DisplayDistance()
    {
        distanceText.text = distanceTitle + currentDistance;
    }

    private void CheckScore()
    {
        if (previousDistance < currentDistance)
        {
            TotalScores.score++;
            previousDistance = currentDistance;
        }
        else if (previousDistance > currentDistance)
        {
            TotalScores.score--;
            previousDistance = currentDistance;
        }
    }
}

