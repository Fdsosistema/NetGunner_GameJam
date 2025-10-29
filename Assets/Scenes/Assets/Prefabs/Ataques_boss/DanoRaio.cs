using UnityEngine;

public class DanoRaio : MonoBehaviour
{

    private float dano = 25f;

 
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Vida>()?.ReceberDano(dano);
            collision.GetComponent<PlayerHealthSlider>()?.TakeDamage(dano);

  

        }

    }

}
