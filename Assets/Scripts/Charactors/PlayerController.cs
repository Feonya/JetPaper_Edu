using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D body;
    protected StateMachine stateMachine;

    [HideInInspector]
    public bool onGround;
    public float speed;
    public float jumpPower;
    [HideInInspector]
    public bool isJumpButtonDown;
    [HideInInspector]
    public bool isBlowButtonDown;
    [HideInInspector]
    public bool isBlowButtonUp;

    [HideInInspector]
    public bool canControl;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<StateMachine>();

        onGround = true;

        isJumpButtonDown = false;
        isBlowButtonDown = false;
        isBlowButtonUp = false;

        canControl = false;
    }

    //private void Update()
    //{
    //    KeyboardControl();
    //}

    protected void FixedUpdate()
    {
        Control();
    }

    private void Control()
    {
        if (!canControl)
        {
            return;
        }

        if (stateMachine.state == StateMachine.States.Blow ||
            stateMachine.state == StateMachine.States.Dead ||
            stateMachine.state == StateMachine.States.Tumble ||
            stateMachine.state == StateMachine.States.Infatuate ||
            stateMachine.state == StateMachine.States.Vomit)
        {
            return;
        }

        if (stateMachine.state != StateMachine.States.Inhale)
        {
            float sp = Input.acceleration.x;
            sp = Mathf.Clamp(sp, -1.0f, 1.0f) * speed * 3.5f;
            body.velocity = new Vector2(sp, body.velocity.y);
        }

        if (onGround)
        {
            if (isBlowButtonDown)
            {
                stateMachine.ChangeState("Inhale");
            }
            else if (isBlowButtonUp)
            {
                stateMachine.ChangeState("Blow");
                isBlowButtonUp = false;
            }
            else if (isJumpButtonDown)
            {
                body.AddForce(new Vector2(0.0f, jumpPower));
                isJumpButtonDown = false;
            }
            else if (body.velocity.x == 0.0f)
            {
                stateMachine.ChangeState("Idle");
            }
            else if (body.velocity.x != 0.0f)
            {
                stateMachine.ChangeState("Move");
            }
        }
        else if (!onGround)
        {
            stateMachine.ChangeState("Jump");
        }
    }

    //private void KeyboardControl()
    //{
    //    if (!canControl)
    //    {
    //        return;
    //    }

    //    if (stateMachine.state == StateMachine.States.Blow ||
    //        stateMachine.state == StateMachine.States.Dead ||
    //        stateMachine.state == StateMachine.States.Tumble ||
    //        stateMachine.state == StateMachine.States.Infatuate ||
    //        stateMachine.state == StateMachine.States.Vomit)
    //    {
    //        return;
    //    }

    //    if (stateMachine.state != StateMachine.States.Inhale)
    //    {
    //        float sp = speed * Input.GetAxis("Horizontal");
    //        body.velocity = new Vector2(sp, body.velocity.y);
    //    }

    //    if (onGround)
    //    {
    //        if (Input.GetKey(KeyCode.X) || isBlowButtonDown)
    //        {
    //            stateMachine.ChangeState("Inhale");
    //        }
    //        else if (Input.GetKeyUp(KeyCode.X) || isBlowButtonUp)
    //        {
    //            stateMachine.ChangeState("Blow");
    //            isBlowButtonUp = false;
    //        }
    //        else if (Input.GetKeyDown(KeyCode.Z) || isJumpButtonDown)
    //        {
    //            body.AddForce(new Vector2(0.0f, jumpPower));
    //            isJumpButtonDown = false;
    //        }
    //        else if (body.velocity.x == 0.0f)
    //        {
    //            stateMachine.ChangeState("Idle");
    //        }
    //        else if (body.velocity.x != 0.0f)
    //        {
    //            stateMachine.ChangeState("Move");
    //        }
    //    }
    //    else if (!onGround)
    //    {
    //        stateMachine.ChangeState("Jump");
    //    }
    //}

    public virtual void Infatuate()
    {
        stateMachine.ChangeState("Infatuate");
    }

    public virtual void Vomit()
    {
        stateMachine.ChangeState("Vomit");
    }

    public void Tumble()
    {
        stateMachine.ChangeState("Tumble");
    }

    public void Die()
    {
        stateMachine.ChangeState("Dead");
    }

    public void Idle()
    {
        stateMachine.ChangeState("Idle");
    }
}