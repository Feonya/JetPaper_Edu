using UnityEngine;

public class Dog : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerDistanceChecker playerDistanceChecker;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool canBite;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        canBite = false;
    }

    private void FixedUpdate()
    {
        ActiveAnimator();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canBite)
        {
            playerController.Die();
            spriteRenderer.sortingLayerName = "InFrontOfPlayer";
        }
    }

    private void ActiveAnimator()
    {
        if (playerDistanceChecker.inRange)
        {
            if (!animator.enabled)
            {
                animator.enabled = true;
            }
        }
    }

    private void StartBite()
    {
        canBite = true;
    }

    private void DestroyIt()
    {
        Destroy(gameObject);
    }
}
