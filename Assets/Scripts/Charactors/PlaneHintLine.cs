using UnityEngine;

public class PlaneHintLine : MonoBehaviour
{
    private Transform planeTransform;
    private LineRenderer lineRenderer;

    public float heightToShow;

    private void Start()
    {
        planeTransform = GameObject.FindGameObjectWithTag("Plane").transform;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    private void FixedUpdate()
    {
        ShowLine();
    }

    private void ShowLine()
    {
        if (planeTransform.position.y >= heightToShow)
        {
            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
            }

            lineRenderer.SetPosition(1, planeTransform.position);
            lineRenderer.SetPosition(0, new Vector3(planeTransform.position.x, -2.5f, 0.0f));
        }
        else
        {
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }
    }
}
