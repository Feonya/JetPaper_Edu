using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void OnStartGameButtonClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
    }
}
