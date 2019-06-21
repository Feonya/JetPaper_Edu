using UnityEngine;

public class PlaneCollisionChecker : MonoBehaviour
{
    private GameObject road;
    private PlayerController playerController;
    private EvilCat evilCat;

    [HideInInspector]
    public bool onGround;

    private void Start()
    {
        road = GameObject.Find("Road");
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        evilCat = GameObject.Find("EvilCat").GetComponent<EvilCat>();

        onGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == road)
        {
            onGround = true;

            if (evilCat.caputured)
            {
                evilCat.StartFly();
            }
            else
            {
                playerController.Die();
            }
        }
    }
}
