using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GemsController : MonoBehaviour
{
    private Reviver reviver;
    private StateMachine stateMachine;
    private Text gemsNumberText;
    private GameObject useGemButton;

    private bool readyToShowUseGemButton;
    private int totalGemsNumber;

    private void Start()
    {
        reviver = GameObject.Find("Players").GetComponent<Reviver>();
        stateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();
        gemsNumberText = transform.GetChild(0).GetComponent<Text>();
        useGemButton = transform.GetChild(2).gameObject;
        readyToShowUseGemButton = false;
        InitTotalGemsNumber();
    }

    private void FixedUpdate()
    {
        CheckUseGemButton();
    }

    private void CheckGemsNumber()
    {
        gemsNumberText.text = "X " + totalGemsNumber;
    }

    private void InitTotalGemsNumber()
    {
        if (PlayerPrefs.HasKey("TotalGemsNumber"))
        {
            totalGemsNumber = PlayerPrefs.GetInt("TotalGemsNumber");
        }
        else
        {
            PlayerPrefs.SetInt("TotalGemsNumber", 3);
            PlayerPrefs.Save();
            totalGemsNumber = 3;
        }

        CheckGemsNumber();
    }

    public void AddGems(int n)
    {
        totalGemsNumber += n;
        PlayerPrefs.SetInt("TotalGemsNumber", totalGemsNumber);
        PlayerPrefs.Save();

        CheckGemsNumber();
    }

    public void UseOneGem()
    {
        totalGemsNumber -= 1;
        PlayerPrefs.SetInt("TotalGemsNumber", totalGemsNumber);
        PlayerPrefs.Save();

        CheckGemsNumber();

        reviver.ReadyToRevive();
    }

    public void OnBuyGemsButtonClick()
    {
        // 启动内购
        Reviver.androidJavaObject.Call("StartPurchase");
    }

    public void OnUseGemButtonClick()
    {
        UseOneGem();
    }

    private void CheckUseGemButton()
    {
        if (stateMachine.state == StateMachine.States.Dead && totalGemsNumber > 0)
        {
            if (!readyToShowUseGemButton)
            {
                StartCoroutine(ShowUseGemButton());
                readyToShowUseGemButton = true;
            }
        }
        else
        {
            if (useGemButton.activeSelf)
            {
                useGemButton.SetActive(false);
                readyToShowUseGemButton = false;
            }
        }
    }

    private IEnumerator ShowUseGemButton()
    {
        yield return new WaitForSeconds(2.0f);

        useGemButton.SetActive(true);
    }
}
