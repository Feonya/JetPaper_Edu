using UnityEngine;

public class Fun : MonoBehaviour
{
    private Transform playerTransform;
    private Transform planeTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        planeTransform = GameObject.FindGameObjectWithTag("Plane").transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerTransform.position += new Vector3(-0.02f, 0.0f, 0.0f);
        }

        if (collision.CompareTag("Plane"))
        {
            planeTransform.position += new Vector3(-0.02f, 0.0f, 0.0f);
        }
    }
}
