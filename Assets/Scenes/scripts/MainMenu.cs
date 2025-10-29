using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 0;
    }

  

    public void PlayGame()
    {
        SceneManager.LoadScene("level_1");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
