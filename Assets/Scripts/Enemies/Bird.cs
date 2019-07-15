using UnityEngine;

public class Bird : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Transform birdTransform;
    private Transform birdSoundTransform;
    private AudioSource birdSound;
    private Rigidbody2D planeBody;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        birdTransform = transform;
        birdSoundTransform = GameObject.Find("BirdSound").transform;
        birdSound = birdSoundTransform.GetComponent<AudioSource>();
        planeBody = GameObject.FindGameObjectWithTag("Plane").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Fly();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plane"))
        {
            planeBody.velocity += new Vector2(0.0f, -3.0f);
        }
    }

    private void Fly()
    {
        if (playerDistanceChecker.inRange)
        {
            if (!birdSound.isPlaying)
            {
                birdSound.Play();
            }

            birdTransform.position += new Vector3(-0.03f, Mathf.Sin(birdTransform.position.x) * 0.1f, 0.0f);
            birdSoundTransform.position = birdTransform.position;

            if (playerDistanceChecker.outOfRange)
            {
                Destroy(birdSoundTransform.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
