using UnityEngine;

public class CoinBomb : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.Die();
            animator.SetBool("exploding", true);
        }
    }

    private void DestroyIt()
    {
        Destroy(gameObject);
    }
}
