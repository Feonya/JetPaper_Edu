using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;

    private bool onGround;

    public float speed;
    public float jumpPower;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        onGround = false;
    }

    private void FixedUpdate()
    {
        KeyboardControl();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        int cnum = collision.contactCount;
        for (int i = 0; i < cnum; i++)
        {
            ContactPoint2D contact = collision.GetContact(i);
            if (contact.normal.y > 0.8f)
            {
                if (!onGround)
                {
                    onGround = true;
                }
            }
            else if (contact.normal.y <= 0.8f)
            {
                if (onGround)
                {
                    onGround = false;
                }
            }

        }
    }

    private void KeyboardControl()
    {
        // 移动
        float sp = speed * Input.GetAxis("Horizontal");
        body.velocity = new Vector2(sp, body.velocity.y);

        // 跳跃
        if (onGround)
        {
            if (Input.GetAxis("Vertical") > 0.0f)
            {
                body.AddForce(new Vector2(0.0f, jumpPower));
            }
        }
    }
}
