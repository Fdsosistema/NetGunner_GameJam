using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AtaqueProjetil : MonoBehaviour
{
    public GameObject projetilPrefab; 
    public Transform pontoDisparo;     
    public float velocidadeProjetil = 10f;
    public float Cadencia =0.2f;
    private float nextFire = 0f;
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFire) {
         nextFire = Time.time + Cadencia;
            Disparar();

        }


    }



    void Disparar()
    {
       
        Vector3 Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Mouse.z = 0f;
    
        Vector2 direcao = (Mouse - transform.position).normalized;
      
        GameObject projetil = Instantiate(projetilPrefab, pontoDisparo.position, Quaternion.identity);
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direcao * velocidadeProjetil;


    }
}
