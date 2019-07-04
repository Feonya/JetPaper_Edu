using System.Collections;
using UnityEngine;

public class BlackCat : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Transform blackCatTransform;
    private SpriteRenderer blackCatSpriteRenderer;
    private Animator blackCatAnimator;
    private Transform playerTransform;
    private Transform planeTransform;
    private SpriteRenderer planeSpriteRenderer;
    private PlaneCollisionChecker planeCollisionChecker;
    private Sprite blackPlaneSprite;
    private CaputureChecker caputureChecker;

    private bool active;
    [HideInInspector]
    public bool caputured;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        blackCatTransform = transform;
        blackCatSpriteRenderer = blackCatTransform.GetComponent<SpriteRenderer>();
        blackCatAnimator = blackCatTransform.GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        planeTransform = GameObject.FindGameObjectWithTag("Plane").transform;
        planeSpriteRenderer = planeTransform.GetComponent<SpriteRenderer>();
        planeCollisionChecker = planeTransform.GetComponent<PlaneCollisionChecker>();
        blackPlaneSprite = Resources.LoadAll<Sprite>("planes")[2];
        caputureChecker = GetComponent<CaputureChecker>();

        active = false;
        caputured = false;
    }

    private void FixedUpdate()
    {
        DestroyIt();
        ActivateIt();
        Move();
        Fly();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !caputured)
        {
            caputureChecker.CheckCaputure();
            caputured = true;
            blackCatSpriteRenderer.flipX = false;
        }
    }

    private void Move()
    {
        if (active)
        {
            if (!caputured)
            {
                blackCatTransform.position += new Vector3(-0.05f, 0.0f, 0.0f);
            }
            else
            {
                float positionX = playerTransform.position.x - 1.0f;
                blackCatTransform.position = new Vector3(positionX, blackCatTransform.position.y, 0.0f);
            }
        }
    }

    public void StartFly()
    {
        active = false;

        blackCatAnimator.SetBool("flying", true);

        StartCoroutine(TransformIntoPlane());
    }

    private void Fly()
    {
        if (blackCatAnimator.GetBool("flying"))
        {
            blackCatTransform.position += new Vector3(0.0f, 0.02f, 0.0f);
        }
    }

    private IEnumerator TransformIntoPlane()
    {
        yield return new WaitForSeconds(4.0f);

        caputured = false;
        planeSpriteRenderer.sprite = blackPlaneSprite;
        planeTransform.position = blackCatTransform.position;
        planeCollisionChecker.onGround = false;

        Destroy(gameObject);
    }

    private void ActivateIt()
    {
        if (playerDistanceChecker.inRange && !caputured)
        {
            if (!active)
            {
                active = true;
            }
        }
    }

    private void DestroyIt()
    {
        if (playerDistanceChecker.outOfRange && !caputured)
        {
            Destroy(gameObject);
        }
    }
}
