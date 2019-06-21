using UnityEngine;

public class Locust : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Transform locustTransform;
    private Rigidbody2D planeBody;

    private bool active;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        locustTransform = transform;
        planeBody = GameObject.FindGameObjectWithTag("Plane").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        DestroyThem();
        ActivateThem();
        Fly();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plane"))
        {
            planeBody.velocity += new Vector2(0.0f, -0.6f);
        }
    }

    private void Fly()
    {
        if (active)
        {
            locustTransform.position += new Vector3(-0.1f, 0.0f, 0.0f);
        }
    }

    private void ActivateThem()
    {
        if (playerDistanceChecker.inRange)
        {
            if (!active)
            {
                active = true;
            }
        }
    }

    private void DestroyThem()
    {
        if (playerDistanceChecker.outOfRange)
        {
            Destroy(gameObject);
        }
    }
}
