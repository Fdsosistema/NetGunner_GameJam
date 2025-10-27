using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resumir()
    {
        pauseMenu.SetActive(false);
        Time.timeScale =1;
    }


    public void Sair()
    {
        SceneManager.LoadScene("TelaInicio");
        Time.timeScale = 1;
    }

}
