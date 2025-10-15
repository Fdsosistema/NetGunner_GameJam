using UnityEngine;


public class Projetil : MonoBehaviour
{
    public float dano = 10f; // Dano que o projétil causa
   
    void Start()
    {
        // Destroi o projétil após o tempo definido para evitar acúmulo na cena
       
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (colisao.CompareTag("Inimigo"))
        {
            colisao.GetComponent<Vida>()?.ReceberDano(dano);
            Destroy(gameObject);
        }
    }
}
