using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    private Transform playersTransform;
    private Transform[] allPlayersTransform;

    [HideInInspector]
    public static string currentPlayerName = "GreenHatBoy";

    private void Awake()
    {
        playersTransform = transform;
        allPlayersTransform = new Transform[5];

        GetAllPlayers();
        SwitchPlayer();
    }

    private void FixedUpdate()
    {
        KeyboardSwitchPlayer();
    }

    private void GetAllPlayers()
    {
        for (int i = 0; i < playersTransform.childCount; i++)
        {
            allPlayersTransform[i] = playersTransform.GetChild(i);

            allPlayersTransform[i].gameObject.SetActive(false);
        }
    }

    private void SwitchPlayer()
    {
        switch (currentPlayerName)
        {
            case "GreenHatBoy":
                allPlayersTransform[0].gameObject.SetActive(true);
                break;

            case "WhiteNurse":
                allPlayersTransform[1].gameObject.SetActive(true);
                break;

            case "RedApe":
                allPlayersTransform[2].gameObject.SetActive(true);
                break;

            case "YellowHatBoy":
                allPlayersTransform[3].gameObject.SetActive(true);
                break;

            case "ColoredEgg":
                allPlayersTransform[4].gameObject.SetActive(true);
                break;
        }
    }

    private void KeyboardSwitchPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            currentPlayerName = "GreenHatBoy";
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentPlayerName = "WhiteNurse";
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentPlayerName = "RedApe";
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentPlayerName = "YellowHatBoy";
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentPlayerName = "ColoredEgg";
            SceneManager.LoadScene("GameScene");
        }
    }
}
