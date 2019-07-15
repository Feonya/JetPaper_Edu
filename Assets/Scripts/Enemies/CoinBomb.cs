using UnityEngine;

public class CoinBomb : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;
    private AudioSource explodeSound;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        explodeSound = GameObject.Find("ExplodeSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            explodeSound.Play();
            playerController.Die();
            animator.SetBool("exploding", true);
        }
    }

    private void DestroyIt()
    {
        Destroy(gameObject);
    }
}
