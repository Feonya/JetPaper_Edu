using UnityEngine;

public class Road : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("（1）主角与路面碰撞！");
        }
    }
}
