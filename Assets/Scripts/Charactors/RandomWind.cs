using UnityEngine;

public class RandomWind : MonoBehaviour
{
    private Rigidbody2D body;
    private PlaneCollisionChecker planeCollisionChecker;

    public float minForce;
    public float maxForce;
    [HideInInspector]
    public float windForce;

    public float probability; // xx%
    private float randomNumber;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        planeCollisionChecker = GetComponent<PlaneCollisionChecker>();

        windForce = 1.0f;

        randomNumber = 0.0f;
    }

    private void FixedUpdate()
    {
        RandomChange();
        Fly();
    }

    private void RandomChange()
    {
        randomNumber = Random.Range(0.0f, 99.0f);

        if (randomNumber <= probability)
        {
            windForce = Random.Range(minForce, maxForce);
            Debug.Log("WindForce Changed to: " + windForce);
        }
    }

    private void Fly()
    {
        if (!planeCollisionChecker.onGround)
        {
            body.velocity = new Vector2(windForce, body.velocity.y);
        }
    }
}
