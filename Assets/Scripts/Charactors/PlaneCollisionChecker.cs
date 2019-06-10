using UnityEngine;

public class PlaneCollisionChecker : MonoBehaviour
{
    private GameObject road;
    private PlayerController playerController;

    [HideInInspector]
    public bool onGround;

    private void Start()
    {
        road = GameObject.Find("Road");
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        onGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == road)
        {
            onGround = true;
            playerController.Die();
        }
    }
}
