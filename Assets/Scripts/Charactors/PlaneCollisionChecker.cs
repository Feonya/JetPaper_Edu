using UnityEngine;

public class PlaneCollisionChecker : MonoBehaviour
{
    private GameObject road;
    private PlayerController playerController;
    private EvilCat evilCat;
    private YellowCat yellowCat;
    private BlackCat blackCat;
    private PurpleCat purpleCat;

    [HideInInspector]
    public bool onGround;

    private void Start()
    {
        road = GameObject.Find("Road");
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        evilCat = GameObject.Find("EvilCat").GetComponent<EvilCat>();
        yellowCat = GameObject.Find("YellowCat").GetComponent<YellowCat>();
        blackCat = GameObject.Find("BlackCat").GetComponent<BlackCat>();
        purpleCat = GameObject.Find("PurpleCat").GetComponent<PurpleCat>();

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
            else if (yellowCat.caputured)
            {
                yellowCat.StartFly();
            }
            else if (blackCat.caputured)
            {
                blackCat.StartFly();
            }
            else if (purpleCat.caputured)
            {
                purpleCat.StartFly();
            }
            else
            {
                playerController.Die();
            }
        }
    }
}
