using UnityEngine;

public class DanoRaio : MonoBehaviour
{

    public float dano = 10f;

 
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Vida>()?.ReceberDano(dano);
            collision.GetComponent<PlayerHealthSlider>()?.TakeDamage(dano);

  

        }

    }

}
