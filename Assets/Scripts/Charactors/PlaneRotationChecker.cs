using UnityEngine;

public class PlaneRotationChecker : MonoBehaviour
{
    private Rigidbody2D body;
    private PlaneCollisionChecker planeCollisionChecker;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        planeCollisionChecker = GetComponent<PlaneCollisionChecker>();
    }

    private void FixedUpdate()
    {
        CheckRotation();
    }

    private void CheckRotation()
    {
        if (!planeCollisionChecker.onGround)
        {
            body.rotation = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg;
        }
    }
}
