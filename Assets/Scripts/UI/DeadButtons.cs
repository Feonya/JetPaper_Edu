using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadButtons : MonoBehaviour
{
    private GameObject watchAdButton;
    private GameObject restartButton;
    private GameObject exitButton;

    private StateMachine stateMachine;
    //private Reviver testReviver;

    private bool readyToShowButtons;

    private void Start()
    {
        watchAdButton = transform.GetChild(0).gameObject;
        restartButton = transform.GetChild(1).gameObject;
        exitButton = transform.GetChild(2).gameObject;
        watchAdButton.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);

        stateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
        //testReviver = stateMachine.transform.parent.GetComponent<Reviver>();

        readyToShowButtons = false;
    }

    private void FixedUpdate()
    {
        DeadCheck();
    }

    public void OnWatchAdButtonClick()
    {
        // 观看广告
        Reviver.androidJavaObject.Call("ShowAds");
        //testReviver.Revive();
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnExitButtonClick()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void DeadCheck()
    {
        if (stateMachine.state == StateMachine.States.Dead)
        {
            if (!readyToShowButtons)
            {
                StartCoroutine(ShowButtons());
                readyToShowButtons = true;
            }
        }
        else
        {
            if (readyToShowButtons)
            {
                watchAdButton.SetActive(false);
                restartButton.SetActive(false);
                exitButton.SetActive(false);
                readyToShowButtons = false;
            }
        }
    }

    private IEnumerator ShowButtons()
    {
        yield return new WaitForSeconds(2.0f);
        
        watchAdButton.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
    }
}
