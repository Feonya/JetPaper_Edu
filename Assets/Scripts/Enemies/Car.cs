using UnityEngine;

public class Car : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Rigidbody2D carBody;
    private Collider2D carHeadCollider;
    private PlayerController playerController;
    private Collider2D playerCollider;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        carBody = GetComponent<Rigidbody2D>();
        carHeadCollider = GetComponents<BoxCollider2D>()[0];
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void CheckCollide()
    {
        if (carHeadCollider.IsTouching(playerCollider))
        {
            playerController.Die();
        }
    }

    private void Move()
    {
        if (playerDistanceChecker.inRange)
        {
            carBody.velocity = new Vector2(-2.0f, 0.0f);
            CheckCollide();
        }

        if (playerDistanceChecker.outOfRange)
        {
            Destroy(gameObject);
        }
    }
}
