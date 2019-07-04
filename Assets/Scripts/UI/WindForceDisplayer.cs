using UnityEngine;
using UnityEngine.UI;

public class WindForceDisplayer : MonoBehaviour
{
    private Text windForceText;
    private RandomWind randomWind;

    private float windForceMultiple;
    private float currentWindForce;
    private string windForceTitle;

    private void Start()
    {
        windForceText = GetComponent<Text>();
        randomWind = GameObject.FindGameObjectWithTag("Plane").GetComponent<RandomWind>();

        windForceMultiple = 40.0f;
        currentWindForce = 0;
        windForceTitle = "风力：";
        windForceText.text = windForceTitle + currentWindForce;
    }

    private void FixedUpdate()
    {
        DisplayWindForce();
    }

    private void DisplayWindForce()
    {
        if (currentWindForce != randomWind.windForce)
        {
            currentWindForce = randomWind.windForce;
            windForceText.text = windForceTitle + Mathf.RoundToInt(currentWindForce * windForceMultiple);
        }
    }
}
