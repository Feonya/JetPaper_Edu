using UnityEngine;

public class Tyre : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Transform tyreTransform;
    private PlayerController playerController;
    private Rigidbody2D planeBody;

    private bool active;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        tyreTransform = transform;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        planeBody = GameObject.FindGameObjectWithTag("Plane").GetComponent<Rigidbody2D>();

        active = false;
    }

    private void FixedUpdate()
    {
        DestroyIt();
        ActivateIt();
        BounceMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.Die();
        }

        if (collision.CompareTag("Plane"))
        {
            planeBody.velocity += new Vector2(0.0f, -1.0f);
        }
    }

    private void BounceMove()
    {
        if (active)
        {
            tyreTransform.position += new Vector3(-0.01f, 0.0f, 0.0f);
            tyreTransform.position = new Vector3(tyreTransform.position.x, 
                Mathf.Abs(Mathf.Sin(tyreTransform.position.x * 2.0f) * 3.0f) - 2.0f, 0.0f);
        }
    }

    private void ActivateIt()
    {
        if (playerDistanceChecker.inRange)
        {
            if (!active)
            {
                active = true;
            }
        }
    }

    private void DestroyIt()
    {
        if (playerDistanceChecker.outOfRange)
        {
            Destroy(gameObject);
        }
    }
}
