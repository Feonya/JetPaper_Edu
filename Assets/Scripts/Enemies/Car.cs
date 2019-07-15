using UnityEngine;

public class Car : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Rigidbody2D carBody;
    private Collider2D carHeadCollider;
    private PlayerController playerController;
    private Collider2D playerCollider;
    private Transform carTransform;
    private GameObject carSounds;
    private Transform klaxonSoundTransfom;
    private AudioSource klaxonSound;
    private AudioSource clashSound;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        carBody = GetComponent<Rigidbody2D>();
        carHeadCollider = GetComponents<BoxCollider2D>()[0];
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        carTransform = transform;
        carSounds = GameObject.Find("CarSounds");
        klaxonSoundTransfom = carSounds.transform.GetChild(0);
        klaxonSound = carSounds.transform.GetChild(0).GetComponent<AudioSource>();
        clashSound = carSounds.transform.GetChild(1).GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void CheckCollide()
    {
        if (carHeadCollider.IsTouching(playerCollider))
        {
            if (!clashSound.isPlaying)
            {
                clashSound.Play();
            }
            playerController.Die();
        }
    }

    private void Move()
    {
        if (playerDistanceChecker.inRange)
        {
            if (!klaxonSound.isPlaying)
            {
                klaxonSound.Play();
            }
            klaxonSoundTransfom.position = carTransform.position;

            carBody.velocity = new Vector2(-2.0f, 0.0f);
            CheckCollide();
        }

        if (playerDistanceChecker.outOfRange)
        {
            Destroy(carSounds);
            Destroy(gameObject);
        }
    }
}
