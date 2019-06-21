using System.Collections;
using UnityEngine;

public class EvilCat : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Transform evilCatTransform;
    private SpriteRenderer evilCatSpriteRenderer;
    private Animator evilCatAnimator;
    private GameObject haha;
    private Transform playerTransform;
    private Transform planeTransform;
    private SpriteRenderer planeSpriteRenderer;
    private PlaneCollisionChecker planeCollisionChecker;
    private Sprite skullPlaneSprite;

    private bool active;
    [HideInInspector]
    public bool caputured;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        evilCatTransform = transform;
        evilCatSpriteRenderer = evilCatTransform.GetComponent<SpriteRenderer>();
        evilCatAnimator = evilCatTransform.GetComponent<Animator>();
        haha = evilCatTransform.GetChild(0).gameObject;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        planeTransform = GameObject.FindGameObjectWithTag("Plane").transform;
        planeSpriteRenderer = planeTransform.GetComponent<SpriteRenderer>();
        planeCollisionChecker = planeTransform.GetComponent<PlaneCollisionChecker>();
        skullPlaneSprite = Resources.LoadAll<Sprite>("planes")[4];

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
        if (!caputured)
        {
            caputured = true;
            evilCatSpriteRenderer.flipX = false;
            StartCoroutine(Haha());
        }
    }

    private void Move()
    {
        if (active)
        {
            if (!caputured)
            {
                evilCatTransform.position += new Vector3(-0.05f, 0.0f, 0.0f);
            }
            else
            {
                float positionX = playerTransform.position.x - 1.0f;
                evilCatTransform.position = new Vector3(positionX, evilCatTransform.position.y, 0.0f);
            }
        }
    }

    public void StartFly()
    {
        active = false;

        evilCatAnimator.SetBool("flying", true);

        StartCoroutine(TransformIntoPlane());
    }

    private void Fly()
    {
        if (evilCatAnimator.GetBool("flying"))
        {
            evilCatTransform.position += new Vector3(0.0f, 0.02f, 0.0f);
        }
    }

    private IEnumerator TransformIntoPlane()
    {
        yield return new WaitForSeconds(4.0f);

        planeSpriteRenderer.sprite = skullPlaneSprite;
        planeTransform.position = evilCatTransform.position;
        planeCollisionChecker.onGround = false;

        Destroy(gameObject);
    }

    private IEnumerator Haha()
    {
        haha.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        Destroy(haha);
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
