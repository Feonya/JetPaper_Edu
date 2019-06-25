using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator bombAnimator;
    private GameObject explode;
    private Collider2D explodeCollider;
    private Collider2D playerCollider;
    private PlayerController playerController;

    private void Start()
    {
        bombAnimator = GetComponent<Animator>();
        explode = transform.GetChild(0).gameObject;
        explodeCollider = explode.GetComponent<CircleCollider2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        playerController = playerCollider.GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        CheckCollide();
    }

    public IEnumerator WaitForExplode()
    {
        yield return new WaitForSeconds(3.0f);

        bombAnimator.SetBool("exploding", true);
    }

    private void FinishExplode()
    {
        bombAnimator.SetBool("exploding", false);

        gameObject.SetActive(false);
        explode.SetActive(false);
    }

    private void CheckCollide()
    {
        if (explodeCollider.IsTouching(playerCollider))
        {
            playerController.Die();
        }
    }
}
