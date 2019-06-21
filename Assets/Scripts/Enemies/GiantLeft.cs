using UnityEngine;

public class GiantLeft : MonoBehaviour
{
    private PlayerController playerController;
    private Animator leftAnimator;
    private Animator rightAnimator;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        leftAnimator = GetComponent<Animator>();
        rightAnimator = GameObject.Find("Right").GetComponent<Animator>();
    }

    private void ChangeRight()
    {
        rightAnimator.enabled = true;
        leftAnimator.enabled = false;
    }
}
