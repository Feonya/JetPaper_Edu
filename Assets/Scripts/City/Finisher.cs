using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finisher : MonoBehaviour
{
    private SpriteRenderer girlSpriteRenderer;
    private Transform girlTransform;
    private Animator girlAnimator;
    private GameObject goodLetter;
    private GameObject badLetter;
    private GameObject shoe;
    private Rigidbody2D shoeBody;
    private Collider2D shoeCollider;
    private Transform playerTransform;
    private Rigidbody2D playerBody;
    private Collider2D playerCollider;
    private PlayerController playerController;
    private StateMachine stateMachine;
    private Transform finishLineTransform;
    private Transform planeTransform;
    private Rigidbody2D planeBody;
    private SpriteRenderer planeSpriteRenderer;

    private void Start()
    {
        girlSpriteRenderer = GetComponent<SpriteRenderer>();
        girlSpriteRenderer.enabled = false;
        girlTransform = transform;
        girlAnimator = GetComponent<Animator>();
        goodLetter = girlSpriteRenderer.transform.GetChild(0).gameObject;
        goodLetter.SetActive(false);
        badLetter = girlSpriteRenderer.transform.GetChild(1).gameObject;
        badLetter.SetActive(false);
        shoe = girlSpriteRenderer.transform.GetChild(2).gameObject;
        shoe.SetActive(false);
        shoeBody = shoe.GetComponent<Rigidbody2D>();
        shoeCollider = shoe.GetComponent<BoxCollider2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerBody = playerTransform.GetComponent<Rigidbody2D>();
        playerCollider = playerTransform.GetComponent<CircleCollider2D>();
        playerController = playerTransform.GetComponent<PlayerController>();
        stateMachine = playerTransform.GetComponent<StateMachine>();
        finishLineTransform = GameObject.Find("FinishLine").transform;
        planeTransform = GameObject.FindGameObjectWithTag("Plane").transform;
        planeBody = planeTransform.GetComponent<Rigidbody2D>();
        planeSpriteRenderer = planeTransform.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckPlayer();
        CheckPlane();
        CheckShoeCollide();
        CheckLetterIsBadOrGood();
    }

    private void CheckPlayer()
    {
        if (playerTransform.position.x > finishLineTransform.position.x)
        {
            if (playerController.canControl)
            {
                playerController.canControl = false;
                playerBody.velocity = Vector2.zero;
                stateMachine.ChangeState("Idle");

                girlSpriteRenderer.enabled = true;

                planeBody.simulated = false;
                planeTransform.rotation = Quaternion.AngleAxis(Mathf.Atan2(girlTransform.position.y - planeTransform.position.y, girlTransform.position.x - planeTransform.position.x) * Mathf.Rad2Deg, new Vector3(0.0f, 0.0f, 1.0f));
            }

            planeTransform.position = Vector3.MoveTowards(planeTransform.position, girlTransform.position, 0.03f);
        }
    }

    private void CheckPlane()
    {
        if (planeTransform.position.x >= finishLineTransform.position.x + 1.0f)
        {
            planeTransform.position = new Vector3(finishLineTransform.position.x + 1.0f, planeTransform.position.y, 0.0f);
        }
    }

    private void CheckLetterIsBadOrGood()
    {
        if (planeTransform.position == girlTransform.position)
        {
            if (planeSpriteRenderer.sprite.name == "planes_4" && !girlAnimator.GetBool("angering"))
            {
                planeSpriteRenderer.enabled = false;
                girlAnimator.SetBool("angering", true);
                StartCoroutine(ShowBadLetter());
            }
            else if (!goodLetter.activeSelf && !girlAnimator.GetBool("angering"))
            {
                planeSpriteRenderer.enabled = false;
                StartCoroutine(ShowGoodLetter());
            }
        }
    }

    private IEnumerator ShowBadLetter()
    {
        badLetter.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        shoe.SetActive(true);
        shoeBody.AddForce(new Vector2(-80.0f, 0.0f));
    }

    private IEnumerator ShowGoodLetter()
    {
        goodLetter.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("FinishScene");
    }

    private void CheckShoeCollide()
    {
        if (shoeCollider.IsTouching(playerCollider))
        {
            playerController.Die();
        }
    }
}
