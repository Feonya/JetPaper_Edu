using UnityEngine;

public class Air1CollisionChecker : AirCollisionChecker
{
    private new void Start()
    {
        base.Start();

        base.airCollider = transform.Find("Air (1)").GetComponent<CapsuleCollider2D>();
    }
}
