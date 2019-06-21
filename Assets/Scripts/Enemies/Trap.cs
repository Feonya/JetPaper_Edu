using UnityEngine;

public class Trap : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D playerBody;
    private Transform playerTransform;
    private StateMachine stateMachine;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
    }

    private void FixedUpdate()
    {
        CheckTumbleDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.Tumble();
        }
    }

    private void CheckTumbleDirection()
    {
        if (stateMachine.state == StateMachine.States.Tumble)
        {
            if (playerBody.velocity.x < 0.0f)
            {
                playerTransform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            if (playerTransform.localScale.x != 1.0f)
            {
                playerTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
    }
}
