using System.Collections;
using UnityEngine;


public class Projetil_eletrico : MonoBehaviour
{
    public float dano = 10f; // Dano que o proj�til causa

    void Start()
    {
        // Destroi o proj�til ap�s o tempo definido para evitar ac�mulo na cena

    }

    void OnTriggerEnter2D(Collider2D colisao)
    {

        StartCoroutine(Autodestruir());

        IEnumerator Autodestruir()
        {
            yield return new WaitForSeconds(2.5f);
            Destroy(gameObject);
        }

        if (colisao.CompareTag("Player"))
        {
            colisao.GetComponent<Vida>()?.ReceberDano(dano);
            Destroy(gameObject);
        }
    }
}

