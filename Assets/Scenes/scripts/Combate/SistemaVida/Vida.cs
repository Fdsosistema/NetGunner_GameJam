using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Vida : MonoBehaviour
{
    [Header("Configuração de Vida")]
    public float vidaMaxima = 100f; 
    private float vidaAtual;

    [Header("Feedback de Dano")]
    public float duracaoPiscar = 0.15f;
    public float tempoInvulneravel = 1f;
    private bool invulneravel = false;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public int quantidadePiscos = 4;
  
   

    void Start()
    {
       
        vidaAtual = vidaMaxima;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void ReceberDano(float dano)
    {

        if (invulneravel) return; // Ignora se estiver invulnerável

        vidaAtual -= dano;
        Debug.Log($"{gameObject.name} recebeu {dano} de dano. Vida restante: {vidaAtual}");

        // Inicia piscar
        StartCoroutine(Piscar());
        StartCoroutine(TornarInvulneravel());
   

        if (vidaAtual <= 0)
            Morrer();
    }

    void Morrer()
    {
       
        Debug.Log($"{gameObject.name} morreu!");
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
        Cursor.visible = true;
    }

     IEnumerator Piscar()
    {
        for (int i = 0; i < quantidadePiscos; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(duracaoPiscar);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(duracaoPiscar);
        }
    }

    private IEnumerator TornarInvulneravel()
    {
        invulneravel = true;
        yield return new WaitForSeconds(tempoInvulneravel);
        invulneravel = false;
    }

}
