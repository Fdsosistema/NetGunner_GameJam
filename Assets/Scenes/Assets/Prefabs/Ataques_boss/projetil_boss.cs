using System.Transactions;
using Unity.Mathematics;
using UnityEngine;

public class projetil_boss : MonoBehaviour
{

    public float velocidadeAtaque = 5f;
    public Transform PontoInicial;
    public Transform PontoFinal;
    private Vector3 alvo;
    private Vector3 pontoAnterior;
    private Vector3 deslocamnto;
   
    public float dano = 10f;


    private void Start()
    {
        alvo = PontoFinal.position;
        pontoAnterior = transform.position;
    }

    void Update()
    {
        
            transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
        deslocamnto = transform.position - deslocamnto;
        pontoAnterior = transform.position;
     
       

         if (Vector3.Distance(transform.position, alvo) < 0.1f) {
            Destroy(gameObject);

        }
        ;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            collision.GetComponent<Vida>()?.ReceberDano(dano);
            collision.GetComponent<PlayerHealthSlider>()?.TakeDamage(dano);

        }
    }

}
