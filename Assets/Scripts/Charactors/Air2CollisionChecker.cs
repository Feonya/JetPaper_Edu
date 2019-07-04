using UnityEngine;

public class Air2CollisionChecker : AirCollisionChecker
{
    private new void Start()
    {
        base.Start();

        base.airCollider = transform.Find("Air (2)").GetComponent<CapsuleCollider2D>();
    }
}
