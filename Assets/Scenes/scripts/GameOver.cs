using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
 
    public void Recomecar()
    {
        SceneManager.LoadScene("level_1");
    }

    public void Sair()
    {
        SceneManager.LoadScene("TelaInicio");
    }

}
