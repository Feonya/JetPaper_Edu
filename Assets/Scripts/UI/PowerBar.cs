using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    private StateMachine stateMachine;
    private InhaleController inhaleController;
    private Image redFillImage;

    private void Start()
    {
        inhaleController = GameObject.FindGameObjectWithTag("Player").GetComponent<InhaleController>();
        stateMachine = inhaleController.GetComponent<StateMachine>();
        redFillImage = transform.GetChild(1).GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        CheckAirPower();
    }

    private void CheckAirPower()
    {
        if (stateMachine.state == StateMachine.States.Inhale || 
            stateMachine.state == StateMachine.States.Blow)
        {
            redFillImage.fillAmount = inhaleController.airPower / inhaleController.maxPower;
        }
        else if (redFillImage.fillAmount != 0.0f)
        {
            redFillImage.fillAmount = 0.0f;
        }
    }
}
