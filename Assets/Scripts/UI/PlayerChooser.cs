using UnityEngine;
using UnityEngine.UI;

public class PlayerChooser : MonoBehaviour
{
    private Toggle playerToggle;
    private Toggle player1Toggle;
    private Toggle player2Toggle;
    private Toggle player3Toggle;
    private Toggle player4Toggle;

    private void Start()
    {
        playerToggle = transform.GetChild(0).GetComponent<Toggle>();
        player1Toggle = transform.GetChild(1).GetComponent<Toggle>();
        player2Toggle = transform.GetChild(2).GetComponent<Toggle>();
        player3Toggle = transform.GetChild(3).GetComponent<Toggle>();
        player4Toggle = transform.GetChild(4).GetComponent<Toggle>();

        CheckCurrentPlayer();
    }

    private void CheckCurrentPlayer()
    {
        switch (PlayerSwitcher.currentPlayerName)
        {
            case "GreenHatBoy":
                playerToggle.isOn = true;
                break;

            case "WhiteNurse":
                player1Toggle.isOn = true;
                break;

            case "RedApe":
                player2Toggle.isOn = true;
                break;

            case "YellowHatBoy":
                player3Toggle.isOn = true;
                break;

            case "ColoredEgg":
                player4Toggle.isOn = true;
                break;
        }
    }

    public void OnPlayerToggleClick()
    {
        PlayerSwitcher.currentPlayerName = "GreenHatBoy";
    }

    public void OnPlayer1ToggleClick()
    {
        PlayerSwitcher.currentPlayerName = "WhiteNurse";
    }

    public void OnPlayer2ToggleClick()
    {
        PlayerSwitcher.currentPlayerName = "RedApe";
    }

    public void OnPlayer3ToggleClick()
    {
        PlayerSwitcher.currentPlayerName = "YellowHatBoy";
    }

    public void OnPlayer4ToggleClick()
    {
        PlayerSwitcher.currentPlayerName = "ColoredEgg";
    }
}
