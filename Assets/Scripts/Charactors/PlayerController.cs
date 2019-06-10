using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private StateMachine stateMachine;

    [HideInInspector]
    public bool onGround;
    public float speed;
    public float jumpPower;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<StateMachine>();

        onGround = false;
    }

    private void Update()
    {
        KeyboardControl();
    }

    private void KeyboardControl()
    {
        if (stateMachine.state == StateMachine.States.Blow ||
            stateMachine.state == StateMachine.States.Dead ||
            stateMachine.state == StateMachine.States.Tumble ||
            stateMachine.state == StateMachine.States.Infatuate ||
            stateMachine.state == StateMachine.States.Vomit)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            stateMachine.ChangeState("Infatuate");
            return;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            stateMachine.ChangeState("Vomit");
            return;
        }

        if (stateMachine.state != StateMachine.States.Inhale)
        {
            float sp = speed * Input.GetAxis("Horizontal");
            body.velocity = new Vector2(sp, body.velocity.y);
        }

        if (onGround)
        {
            if (Input.GetKey(KeyCode.X))
            {
                stateMachine.ChangeState("Inhale");
            }
            else if (Input.GetKeyUp(KeyCode.X))
            {
                stateMachine.ChangeState("Blow");
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                body.AddForce(new Vector2(0.0f, jumpPower));
            }
            else if (body.velocity.x == 0.0f)
            {
                stateMachine.ChangeState("Idle");
            }
            else if (body.velocity.x != 0.0f)
            {
                stateMachine.ChangeState("Move");

                if (Input.GetKeyDown(KeyCode.W))
                {
                    stateMachine.ChangeState("Tumble");
                }
            }
        }
        else if (!onGround)
        {
            stateMachine.ChangeState("Jump");
        }
    }

    public void Die()
    {
        stateMachine.ChangeState("Dead");
    }

    private void ChangeToStateIdle()
    {
        stateMachine.ChangeState("Idle");
    }
}