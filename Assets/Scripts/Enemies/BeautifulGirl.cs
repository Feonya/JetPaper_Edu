using UnityEngine;

public class BeautifulGirl : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Transform kissTransform;
    private SpriteRenderer kissSpriteRenderer;
    private Collider2D kissCollider;
    private Collider2D playerCollider;
    private PlayerController playerController;
    private Transform playerTransform;
    private AudioSource kissSound;

    private Vector3 kissOriginPosition;
    private Vector3 kissTargetPosition;

    private bool isKissing;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        kissTransform = transform.GetChild(0);
        kissSpriteRenderer = kissTransform.GetComponent<SpriteRenderer>();
        kissCollider = kissTransform.GetComponent<BoxCollider2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        kissSound = GameObject.Find("KissSound").GetComponent<AudioSource>();

        kissOriginPosition = kissTransform.position;
        kissTargetPosition = kissTransform.position;

        isKissing = false;
    }

    private void FixedUpdate()
    {
        KissMove();
    }

    private void KissMove()
    {
        if (isKissing)
        {
            kissTransform.position += Vector3.Normalize(kissTargetPosition - kissOriginPosition) * 0.12f;

            CheckKissCollide();
        }
    }

    private void CheckKissCollide()
    {
        if (kissCollider.IsTouching(playerCollider))
        {
            playerController.Infatuate();

            kissSpriteRenderer.enabled = false;
            kissCollider.enabled = false;
        }
    }

    private void StartKiss()
    {
        kissSound.Play();

        kissSpriteRenderer.enabled = true;
        kissCollider.enabled = true;

        kissTargetPosition = playerTransform.position;

        isKissing = true;
    }

    private void StopKiss()
    {
        kissSpriteRenderer.enabled = false;
        kissCollider.enabled = false;

        kissTransform.position = kissOriginPosition;

        isKissing = false;
    }
}
