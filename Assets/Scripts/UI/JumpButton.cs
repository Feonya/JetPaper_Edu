using UnityEngine;

public class JumpButton : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void onJumpButtonDown()
    {
        playerController.isJumpButtonDown = true;
    }

    public void onJumpButtonUp()
    {
        playerController.isJumpButtonDown = false;
    }
}
