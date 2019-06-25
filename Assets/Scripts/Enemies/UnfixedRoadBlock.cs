using UnityEngine;

public class UnfixedRoadBlock : MonoBehaviour
{
    private Transform unfixedRoadBlockTransform;

    private Vector3 originPosition;

    private void Start()
    {
        unfixedRoadBlockTransform = transform;

        originPosition = unfixedRoadBlockTransform.position;
    }

    private void FixedUpdate()
    {
        DestroyIt();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CoinBomb"))
        {
            collision.GetComponent<Animator>().SetBool("exploding", true);
        }
    }

    private void DestroyIt()
    {
        if (unfixedRoadBlockTransform.position.x - originPosition.x > 4)
        {
            Destroy(gameObject);
        }
    }
}
