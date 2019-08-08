using UnityEngine;

public class Player4Controller : PlayerController
{
    private new void FixedUpdate()
    {
        base.FixedUpdate();
        JumpInTheSky();
    }

    private void JumpInTheSky()
    {
        if (base.isJumpButtonDown)
        {
            if (base.stateMachine.state == StateMachine.States.Jump && base.body.velocity.y < 0.0f)
            {
                base.body.AddForce(new Vector2(0.0f, base.jumpPower));
            }
        }
    }
}
