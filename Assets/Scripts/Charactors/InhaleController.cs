using UnityEngine;

public class InhaleController : MonoBehaviour
{
    private StateMachine stateMachine;

    private Transform airTransform;

    [HideInInspector]
    public float airPower;
    public float maxPower;
    public float increasePower;

    public float maxScale;
    private float increaseScale;

    private bool startInhale;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();

        airTransform = transform.Find("Air");
        
        airPower = 0.0f;
        increaseScale = 0.0f;

        startInhale = false;
    }

    private void FixedUpdate()
    {
        Inhale();
    }

    private void Inhale()
    {
        if (stateMachine.state == StateMachine.States.Inhale)
        {
            if (!startInhale)
            {
                startInhale = true;

                airPower = 0.0f;
                airTransform.localScale = Vector3.one;
            }
            else
            {
                if (airPower < maxPower)
                {
                    airPower += increasePower;
                }
            }
        }
        else
        {
            if (startInhale)
            {
                startInhale = false;

                increaseScale = (maxScale - 1.0f) / maxPower * airPower;
                airTransform.localScale += new Vector3(increaseScale, increaseScale, 0.0f);

                Debug.Log("airPower: " + airPower);
                Debug.Log("airScale: " + airTransform.localScale);
            }
        }
    }
}
