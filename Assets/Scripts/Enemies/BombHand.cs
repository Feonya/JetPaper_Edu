using System.Collections;
using UnityEngine;

public class BombHand : MonoBehaviour
{
    private PlayerDistanceChecker playerDistanceChecker;
    private Transform currentBombTransform;
    private Rigidbody2D currentBombBody;
    private Bomb currentBomb;
    private Transform bombHandTransform;

    private void Start()
    {
        playerDistanceChecker = GetComponent<PlayerDistanceChecker>();
        currentBombTransform = transform.GetChild(0);
        currentBombBody = currentBombTransform.GetComponent<Rigidbody2D>();
        currentBomb = currentBombTransform.GetComponent<Bomb>();
        bombHandTransform = transform;
    }

    private void ThrowBomb()
    {
        if (playerDistanceChecker.inRange && !playerDistanceChecker.outOfRange)
        {
            if (!currentBombTransform.gameObject.activeSelf)
            {
                currentBombTransform.gameObject.SetActive(true);
            }

            currentBombTransform.position = bombHandTransform.position;
            currentBomb.StartCoroutine(currentBomb.WaitForExplode());

            float powerX = Random.Range(-100.0f, 100.0f);
            float powerY = Random.Range(200.0f, 400.0f);
            float torque = Random.Range(-45.0f, 45.0f);
            currentBombBody.AddForce(new Vector2(powerX, powerY));
            currentBombBody.AddTorque(torque);

            currentBombTransform.SetAsLastSibling();
            currentBombTransform = bombHandTransform.GetChild(0);
            currentBomb = currentBombTransform.GetComponent<Bomb>();
            currentBombBody = currentBombTransform.GetComponent<Rigidbody2D>();
        }
    }
}
