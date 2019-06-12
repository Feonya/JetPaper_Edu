using UnityEngine;

public class AirCollisionChecker : MonoBehaviour
{
    private StateMachine stateMachine;

    private Collider2D airCollider;
    private Rigidbody2D planeBody;

    private bool canCollide;

    private InhaleController inhaleController;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();

        airCollider = transform.Find("Air").GetComponent<CapsuleCollider2D>();
        planeBody = GameObject.FindWithTag("Plane").GetComponent<Rigidbody2D>();

        canCollide = false;

        inhaleController = GetComponent<InhaleController>();
    }

    private void FixedUpdate()
    {
        CheckCollider();
    }

    private void CheckCollider()
    {
        if (stateMachine.state == StateMachine.States.Blow)
        {
            if (!canCollide)
            {
                canCollide = true;

                airCollider.enabled = true;
            }
        }
        else
        {
            if (canCollide)
            {
                canCollide = false;

                airCollider.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plane"))
        {
            if (airCollider.enabled)
            {
                airCollider.enabled = false;

                planeBody.AddForce(new Vector2(0.0f, inhaleController.airPower));
            }
        }
    }
}
