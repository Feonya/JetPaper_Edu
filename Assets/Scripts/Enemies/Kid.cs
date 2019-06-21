using UnityEngine;

public class Kid : MonoBehaviour
{
    private Transform kidTransform;
    private Transform KidBabasTransform;
    private Transform currentBabaTransform;

    private Vector3 originPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        kidTransform = transform;
        KidBabasTransform = GameObject.Find("KidBabas").transform;
        currentBabaTransform = KidBabasTransform.GetChild(0);

        originPosition = kidTransform.position;
        targetPosition = originPosition;
    }

    private void FixedUpdate()
    {
        RandomMove();
    }

    private void RandomMove()
    {
        if (kidTransform.position != targetPosition)
        {
            kidTransform.position = Vector3.MoveTowards(kidTransform.position, targetPosition, 0.03f);
        }
        else
        {
            GetNextTargetPosition();
            Baba();
        }
    }

    private void GetNextTargetPosition()
    {
        float randomX = originPosition.x + Random.Range(-4.0f, 4.0f);
        targetPosition = new Vector3(randomX, originPosition.y, originPosition.z);
    }

    private void Baba()
    {
        if (!currentBabaTransform.gameObject.activeSelf)
        {
            currentBabaTransform.gameObject.SetActive(true);
        }

        currentBabaTransform.position = kidTransform.position;
        currentBabaTransform.SetAsLastSibling();

        currentBabaTransform = KidBabasTransform.GetChild(0);
    }
}
