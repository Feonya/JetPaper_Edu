using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;

    public float speed;

    private void Start()
    {
        playerTransform = transform;
    }

    private void FixedUpdate()
    {
        KeyboardMove();
    }

    private void KeyboardMove()
    {
        Vector3 kv = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        playerTransform.position += kv * speed;
    }
}
