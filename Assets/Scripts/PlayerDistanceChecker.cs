using UnityEngine;

public class PlayerDistanceChecker : MonoBehaviour
{
    private Transform thisTransform;
    private Transform playerTransform;

    [HideInInspector]
    public bool inRange;
    public float range;
    [HideInInspector]
    public bool outOfRange;
    public float outRange;

    private void Start()
    {
        thisTransform = transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        inRange = false;
        outOfRange = false;
    }

    private void FixedUpdate()
    {
        CheckPlayerDistance();
    }

    private void CheckPlayerDistance()
    {
        float diff = thisTransform.position.x - playerTransform.position.x;

        // 主角进入范围内
        if (diff <= range)
        {
            if (!inRange)
            {
                inRange = true;
            }

            // 主角超过范围
            if (-diff >= outRange)
            {
                if (!outOfRange)
                {
                    outOfRange = true;
                }
            }
        }
        // 主角未进入范围内
        else if (diff > range)
        {
            if (inRange)
            {
                inRange = false;
            }
        }
    }
}
