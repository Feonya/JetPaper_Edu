using UnityEngine;

public class BlowButton : MonoBehaviour
{
    private PlayerController playerController;
    private StateMachine stateMachine;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        stateMachine = playerController.GetComponent<StateMachine>();
    }

    public void onBlowButtonDown()
    {
        playerController.isBlowButtonDown = true;
    }

    public void onBlowButtonUp()
    {
        if (stateMachine.state == StateMachine.States.Inhale)
        {
            playerController.isBlowButtonDown = false;
            playerController.isBlowButtonUp = true;
        }
        else
        {
            playerController.isBlowButtonDown = false;
            playerController.isBlowButtonUp = false;
        }
    }
}
