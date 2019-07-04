using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseExitButton : MonoBehaviour
{
    private Button pauseExitButton;
    private GameObject resumeAndExitButtons;

    private StateMachine stateMachine;

    private void Start()
    {
        pauseExitButton = GetComponent<Button>();
        resumeAndExitButtons = GameObject.Find("ResumeAndExitButtons");
        resumeAndExitButtons.SetActive(false);

        stateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
    }

    private void FixedUpdate()
    {
        DeadCheck();
    }

    public void OnPauseExitButtonClick()
    {
        Time.timeScale = 0.0f;
        resumeAndExitButtons.SetActive(true);
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1.0f;
        resumeAndExitButtons.SetActive(false);
    }

    public void OnExitButtonClick()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void DeadCheck()
    {
        if (stateMachine.state == StateMachine.States.Dead)
        {
            if (pauseExitButton.interactable)
            {
                pauseExitButton.interactable = false;
                resumeAndExitButtons.SetActive(false);
            }
        }
        else
        {
            if (!pauseExitButton.interactable)
            {
                pauseExitButton.interactable = true;
            }
        }
    }
}
