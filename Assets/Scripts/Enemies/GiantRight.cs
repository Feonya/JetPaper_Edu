using UnityEngine;

public class GiantRight : MonoBehaviour
{
    private PlayerController playerController;
    private Collider2D playerCollider;
    private GameObject Giant;
    private PlayerDistanceChecker playerDistanceChecker;
    private Animator rightAnimator;
    private Transform rightTransform;
    private Collider2D rightCollider;
    private Animator leftAnimator;
    private Transform leftTransform;
    private Collider2D leftCollider;

    private bool active;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerCollider = playerController.GetComponent<CircleCollider2D>();
        Giant = GameObject.Find("Giant");
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        rightAnimator = GetComponent<Animator>();
        rightTransform = transform;
        rightCollider = rightTransform.GetChild(1).GetComponent<BoxCollider2D>();
        leftAnimator = GameObject.Find("Left").GetComponent<Animator>();
        leftTransform = leftAnimator.transform;
        leftCollider = leftTransform.GetChild(1).GetComponent<BoxCollider2D>();

        active = false;
    }

    private void FixedUpdate()
    {
        DestroyIt();
        ActivateIt();
        CheckCollide();
        Move();
    }

    private void CheckCollide()
    {
        if (rightCollider.IsTouching(playerCollider) || leftCollider.IsTouching(playerCollider))
        {
            playerController.Die();
        }
    }

    private void ActivateIt()
    {
        if (playerDistanceChecker.inRange)
        {
            if (!active)
            {
                active = true;

                rightAnimator.enabled = true;
                leftAnimator.enabled = false;
            }
        }
    }

    private void Move()
    {
        if (rightAnimator.enabled)
        {
            rightTransform.GetChild(0).position += new Vector3(-0.01f, 0.0f, 0.0f);
            rightTransform.GetChild(1).position += new Vector3(-0.01f, 0.0f, 0.0f);
        }
        else if (leftAnimator.enabled)
        {
            leftTransform.GetChild(0).position += new Vector3(-0.01f, 0.0f, 0.0f);
            leftTransform.GetChild(1).position += new Vector3(-0.01f, 0.0f, 0.0f);
        }
    }

    private void ChangeLeft()
    {
        leftAnimator.enabled = true;
        rightAnimator.enabled = false;
    }

    private void DestroyIt()
    {
        if (playerDistanceChecker.outOfRange)
        {
            Destroy(Giant);
        }
    }
}
