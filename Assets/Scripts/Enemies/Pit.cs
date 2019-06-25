using UnityEngine;

public class Pit : MonoBehaviour
{
    private Transform pitTransform;
    private GameObject fakePlayer;
    private Transform playerTransform;
    private PlayerController playerController;
    private SpriteRenderer playerSpriteRenderer;

    private bool playerFallen;

    private void Start()
    {
        pitTransform = transform;
        fakePlayer = pitTransform.GetChild(0).gameObject;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = playerTransform.GetComponent<PlayerController>();
        playerSpriteRenderer = playerTransform.GetComponent<SpriteRenderer>();

        playerFallen = false;
    }

    private void FixedUpdate()
    {
        CheckFall();

        if (Input.GetKeyDown(KeyCode.R))
        {
            playerFallen = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.Die();

            playerFallen = true;
        }
    }

    private void CheckFall()
    {
        if (playerFallen)
        {
            if (!fakePlayer.activeSelf)
            {
                fakePlayer.SetActive(true);
                playerSpriteRenderer.enabled = false;
            }
        }
        else
        {
            if (fakePlayer.activeSelf)
            {
                fakePlayer.SetActive(false);
                playerSpriteRenderer.enabled = true;
                playerTransform.position = pitTransform.position + new Vector3(-2.0f, 0.5f, 0.0f);
            }
        }
    }
}
