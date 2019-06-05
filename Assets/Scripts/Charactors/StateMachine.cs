using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        Idle, Move, Jump, Inhale, Blow,
        Dead, Tumble, Infatuate, Vomit
    };
    [HideInInspector]
    public States state;

    private PlayerController playerController;
    private Animator animator;

    private void Start()
    {
        state = States.Idle;

        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    public void ChangeState(string s)
    {
        switch (s)
        {
            case "Idle":
                if (state != States.Idle)
                {
                    state = States.Idle;
                    SetParam("idling");
                }
                break;

            case "Move":
                if (state != States.Move)
                {
                    state = States.Move;
                    SetParam("moving");
                }
                break;

            case "Jump":
                if (state != States.Jump)
                {
                    state = States.Jump;
                    SetParam("jumping");
                }
                break;

            case "Inhale":
                if (state != States.Inhale)
                {
                    state = States.Inhale;
                    SetParam("inhaling");
                }
                break;

            case "Blow":
                if (state != States.Blow)
                {
                    state = States.Blow;
                    SetParam("blowing");
                }
                break;

            case "Dead":
                if (state != States.Dead)
                {
                    state = States.Dead;
                    SetParam("dying");
                }
                break;

            case "Tumble":
                if (state != States.Tumble)
                {
                    state = States.Tumble;
                    SetParam("tumbling");
                }
                break;

            case "Infatuate":
                if (state != States.Infatuate)
                {
                    state = States.Infatuate;
                    SetParam("infatuating");
                }
                break;

            case "Vomit":
                if (state != States.Vomit)
                {
                    state = States.Vomit;
                    SetParam("vomitting");
                }
                break;

            default:
                Debug.LogError("Wrong State name!");
                break;
        }
    }

    private void SetParam(string p)
    {
        if (!animator.GetBool(p))
        {
            int pNumber = animator.parameterCount;

            for (int i = 0; i < pNumber; i++)
            {
                string pName = animator.parameters[i].name;

                if (pName == p)
                {
                    animator.SetBool(pName, true);
                }
                else
                {
                    animator.SetBool(pName, false);
                }
            }
        }
    }
}
