using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AtaqueProjetil : MonoBehaviour
{
    public GameObject projetilPrefab; 
    public Transform pontoDisparo;     
    public float velocidadeProjetil = 10f;
    public float TempoParaProximoTiro =0.2f;
    private float nextFire = 0f;
    public float spreadAngle = 15f;
        public int NumeroDeBalas = 8;



    void Update()
    {
      
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFire) {
         nextFire = Time.time + TempoParaProximoTiro;
            Disparar();

        }
        

    } 



    void Disparar()
    {
       
        Vector3 Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Mouse.z = 0f;
    
        Vector2 direcao = (Mouse - transform.position).normalized;

        for (int i = 0; i < NumeroDeBalas; i++)
        {
            Vector2 spread = DirecaoSpread(direcao, spreadAngle);

            GameObject projetil = Instantiate(projetilPrefab, pontoDisparo.position, Quaternion.identity);
            Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
            rb.linearVelocity =  spread * velocidadeProjetil ;
        }

    }

    Vector2 DirecaoSpread(Vector2 direcao, float angle)
    {
        float x = Random.Range(-angle /2f, angle /3f);
        float y = Random.Range(-angle / 2f, angle / 3f);

        Quaternion spreadRotacao = Quaternion.Euler(x, y, x);
        return spreadRotacao * direcao;
    }

}
