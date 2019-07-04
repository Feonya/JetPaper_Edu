using UnityEngine;

public class MultipleAirInhaleController : InhaleController
{
    private Transform air1Transform;
    private Transform air2Transform;

    private new void Start()
    {
        base.Start();

        air1Transform = transform.Find("Air (1)");
        air2Transform = transform.Find("Air (2)");
    }

    private new void FixedUpdate()
    {
        base.FixedUpdate();

        CheckAirScale();
    }

    private void CheckAirScale()
    {
        if (air1Transform.localScale != base.airTransform.localScale)
        {
            air1Transform.localScale = base.airTransform.localScale;
            air2Transform.localScale = base.airTransform.localScale;
        }
    }
}
