using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Vida_boss : MonoBehaviour
{
    [Header("Configuração de Vida")]
    public float vidaMaxima = 100f;
    private float vidaAtual;

    [Header("Feedback de Dano")]
    public float duracaoPiscar = 0.15f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public int quantidadePiscos = 4;
    public float Brilho = 15f;
  

    void Start()
    {

        vidaAtual = vidaMaxima;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void ReceberDano(float dano)
    {
    

        vidaAtual -= dano;
        Debug.Log($"{gameObject.name} recebeu {dano} de dano. Vida restante: {vidaAtual}");


        StartCoroutine(Piscar());



        if (vidaAtual <= 0)
            Morrer();
    }

    void Morrer()
    {

        Debug.Log($"{gameObject.name} morreu!");
        Destroy(gameObject);
    }

    IEnumerator Piscar()
    {
        for (int i = 0; i < quantidadePiscos; i++)
        {
            spriteRenderer.color *= Brilho;
            yield return new WaitForSeconds(duracaoPiscar);
            spriteRenderer.color /= Brilho;
            yield return new WaitForSeconds(duracaoPiscar);
        }
    }



}
