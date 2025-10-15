using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AtaqueProjetil : MonoBehaviour
{
    public GameObject projetilPrefab; 
    public Transform pontoDisparo;     
    public float velocidadeProjetil = 10f;
    public float Cadencia =0.2f;
    private float nextFire = 0f;
    public float spreadAngle = 15f;
        public int NumeroDeBalas = 8;



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

        for (int i = 0; i < NumeroDeBalas; i++)
        {
            Vector3 spread = DirecaoSpread(pontoDisparo.forward, spreadAngle);

            GameObject projetil = Instantiate(projetilPrefab, pontoDisparo.position, Quaternion.LookRotation(spread));
            Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
            rb.linearVelocity =  spread * velocidadeProjetil ;
        }

    }

    Vector3 DirecaoSpread(Vector3 direcao, float angle)
    {
        float x = Random.Range(-angle / 2f, angle / 2f);
        float y = Random.Range(-angle / 2f, angle / 2f);

        Quaternion spreadRotacao = Quaternion.Euler(x, y, 0);
        return spreadRotacao * direcao;
    }

}
