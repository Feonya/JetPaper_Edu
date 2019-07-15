using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource coinSound;

    private void Start()
    {
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Plane"))
        {
            coinSound.Play();

            TotalScores.score += 1;
            Destroy(gameObject);
        }
    }
}
