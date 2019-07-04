using System.Collections;
using UnityEngine;

public class YellowCat : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Transform yellowCatTransform;
    private SpriteRenderer yellowCatSpriteRenderer;
    private Animator yellowCatAnimator;
    private Transform playerTransform;
    private Transform planeTransform;
    private SpriteRenderer planeSpriteRenderer;
    private PlaneCollisionChecker planeCollisionChecker;
    private Sprite yellowPlaneSprite;
    private CaputureChecker caputureChecker;

    private bool active;
    [HideInInspector]
    public bool caputured;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        yellowCatTransform = transform;
        yellowCatSpriteRenderer = yellowCatTransform.GetComponent<SpriteRenderer>();
        yellowCatAnimator = yellowCatTransform.GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        planeTransform = GameObject.FindGameObjectWithTag("Plane").transform;
        planeSpriteRenderer = planeTransform.GetComponent<SpriteRenderer>();
        planeCollisionChecker = planeTransform.GetComponent<PlaneCollisionChecker>();
        yellowPlaneSprite = Resources.LoadAll<Sprite>("planes")[1];
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
            yellowCatSpriteRenderer.flipX = false;
        }
    }

    private void Move()
    {
        if (active)
        {
            if (!caputured)
            {
                yellowCatTransform.position += new Vector3(-0.05f, 0.0f, 0.0f);
            }
            else
            {
                float positionX = playerTransform.position.x - 1.0f;
                yellowCatTransform.position = new Vector3(positionX, yellowCatTransform.position.y, 0.0f);
            }
        }
    }

    public void StartFly()
    {
        active = false;

        yellowCatAnimator.SetBool("flying", true);

        StartCoroutine(TransformIntoPlane());
    }

    private void Fly()
    {
        if (yellowCatAnimator.GetBool("flying"))
        {
            yellowCatTransform.position += new Vector3(0.0f, 0.02f, 0.0f);
        }
    }

    private IEnumerator TransformIntoPlane()
    {
        yield return new WaitForSeconds(4.0f);

        caputured = false;
        planeSpriteRenderer.sprite = yellowPlaneSprite;
        planeTransform.position = yellowCatTransform.position;
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
