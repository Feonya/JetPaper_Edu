using System.Collections;
using UnityEngine;

public class UFO : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Transform playerTransform;
    private Collider2D playerCollider;
    private PlayerController playerController;
    private Transform ufoTransform;
    private Transform waveTransform;
    private Collider2D waveCollider;
    private AudioSource laserSound;

    private bool active;
    public int appearTime;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerCollider = playerTransform.GetComponent<CircleCollider2D>();
        playerController = playerTransform.GetComponent<PlayerController>();
        ufoTransform = transform;
        waveTransform = ufoTransform.GetChild(0);
        waveCollider = waveTransform.GetComponent<BoxCollider2D>();
        laserSound = GameObject.Find("LaserSound").GetComponent<AudioSource>();

        active = false;
    }

    private void FixedUpdate()
    {
        DestroyIt();
        ActivateIt();
        CheckCollide();
        FireWave();
    }

    private IEnumerator Appear()
    {
        if (active)
        {
            float randomX = playerTransform.position.x + Random.Range(0.0f, 4.0f);
            float randomY = Random.Range(1.0f, 10.0f);
            ufoTransform.position = new Vector3(randomX, randomY, 0.0f);

            yield return new WaitForSeconds(1.5f);

            waveTransform.position = ufoTransform.position - new Vector3(0.0f, 0.77f, 0.0f);
            waveTransform.gameObject.SetActive(true);
            laserSound.Play();
        }
    }

    private void FireWave()
    {
        if (waveTransform.gameObject.activeSelf)
        {
            waveTransform.position -= new Vector3(0.0f, 0.1f, 0.0f);

            if (waveTransform.position.y < -2.0f)
            {
                appearTime--;
                waveTransform.gameObject.SetActive(false);
                StartCoroutine(Appear());
            }
        }
    }

    private void CheckCollide()
    {
        if (waveCollider.IsTouching(playerCollider))
        {
            playerController.Die();
        }
    }

    private void ActivateIt()
    {
        if (playerDistanceChecker.inRange)
        {
            if (!active)
            {
                active = true;

                StartCoroutine(Appear());
            }
        }
    }

    private void DestroyIt()
    {
        if (appearTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
