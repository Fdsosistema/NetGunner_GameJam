using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool FlagPause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (FlagPause == true)
            {
                Resumir();
            }
            else
            {

                Cursor.visible = true;
                FlagPause = true;

                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }



        }

    }

    public void Resumir()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale =1;
        FlagPause=false;
        Debug.Log(FlagPause);
    }


    public void Sair()
    {
       
        SceneManager.LoadScene("TelaInicio");
        Time.timeScale = 1;
    }

}
