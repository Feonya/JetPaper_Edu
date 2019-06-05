using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!playerController.onGround)
        {
            playerController.onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerController.onGround)
        {
            playerController.onGround = false;
        }
    }
}
