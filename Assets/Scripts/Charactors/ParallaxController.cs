using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private Transform playerTransform;
    private Transform mainCameraTransform;
    private Transform buildingsCameraTransform;
    private Transform cloudsCameraTransform;

    public float buildingsParallaxScale;
    public float cloudsParallaxScale;

    private void Start()
    {
        playerTransform = transform;
        mainCameraTransform = transform.GetChild(1);
        buildingsCameraTransform = transform.GetChild(2);
        cloudsCameraTransform = transform.GetChild(3);
    }

    private void FixedUpdate()
    {
        buildingsCameraTransform.position = mainCameraTransform.position * buildingsParallaxScale;
        cloudsCameraTransform.position = mainCameraTransform.position * cloudsParallaxScale;
    }
}
