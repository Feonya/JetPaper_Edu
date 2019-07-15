using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
