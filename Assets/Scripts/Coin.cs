using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Plane"))
        {
            TotalScores.score += 1;
            Destroy(gameObject);

            Debug.Log("Current Scores: " + TotalScores.score);
        }
    }
}
