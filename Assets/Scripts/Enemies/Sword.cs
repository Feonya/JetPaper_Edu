using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerController playerController;
    private AudioSource swordSound;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        swordSound = GameObject.Find("SwordSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.Die();
        }
    }

    private void PlaySwordSound()
    {
        swordSound.Play();
    }
}
