using System.Collections;
using UnityEngine;

public class PurpleCat : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Transform purpleCatTransform;
    private SpriteRenderer purpleCatSpriteRenderer;
    private Animator purpleCatAnimator;
    private Transform playerTransform;
    private Transform planeTransform;
    private SpriteRenderer planeSpriteRenderer;
    private PlaneCollisionChecker planeCollisionChecker;
    private Sprite purplePlaneSprite;
    private CaputureChecker caputureChecker;

    private bool active;
    [HideInInspector]
    public bool caputured;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        purpleCatTransform = transform;
        purpleCatSpriteRenderer = purpleCatTransform.GetComponent<SpriteRenderer>();
        purpleCatAnimator = purpleCatTransform.GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        planeTransform = GameObject.FindGameObjectWithTag("Plane").transform;
        planeSpriteRenderer = planeTransform.GetComponent<SpriteRenderer>();
        planeCollisionChecker = planeTransform.GetComponent<PlaneCollisionChecker>();
        purplePlaneSprite = Resources.LoadAll<Sprite>("planes")[3];
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
            purpleCatSpriteRenderer.flipX = false;
        }
    }

    private void Move()
    {
        if (active)
        {
            if (!caputured)
            {
                purpleCatTransform.position += new Vector3(-0.05f, 0.0f, 0.0f);
            }
            else
            {
                float positionX = playerTransform.position.x - 1.0f;
                purpleCatTransform.position = new Vector3(positionX, purpleCatTransform.position.y, 0.0f);
            }
        }
    }

    public void StartFly()
    {
        active = false;

        purpleCatAnimator.SetBool("flying", true);

        StartCoroutine(TransformIntoPlane());
    }

    private void Fly()
    {
        if (purpleCatAnimator.GetBool("flying"))
        {
            purpleCatTransform.position += new Vector3(0.0f, 0.02f, 0.0f);
        }
    }

    private IEnumerator TransformIntoPlane()
    {
        yield return new WaitForSeconds(4.0f);

        caputured = false;
        planeSpriteRenderer.sprite = purplePlaneSprite;
        planeTransform.position = purpleCatTransform.position;
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
