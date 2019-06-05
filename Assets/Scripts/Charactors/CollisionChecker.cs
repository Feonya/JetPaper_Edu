using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerController.onGround = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        int cnum = collision.contactCount;
        for (int i = 0; i < cnum; i++)
        {
            ContactPoint2D contact = collision.GetContact(i);
            if (contact.normal.y > 0.8f)
            {
                if (!playerController.onGround)
                {
                    playerController.onGround = true;
                }
            }
            else if (contact.normal.y <= 0.8f)
            {
                if (playerController.onGround)
                {
                    playerController.onGround = false;
                }
            }

        }
    }
}
