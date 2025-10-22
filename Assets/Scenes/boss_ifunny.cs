using UnityEngine;
using System;

public class boss_ifunny : MonoBehaviour
{
    private Action[] functions; 

    public GameObject Ataque1_A;
    public GameObject Ataque1_B;
    public GameObject Ataque1_C;
    public GameObject Ataque2Aviso_A;
    public GameObject Ataque2_A;


    private float nextAtack = 5f;
    public float TempoMinimoentreAtaques = 1f;
    public float TempoMaximoentreAtaques = 10f;
    public float velocidadeAtaque = 5f;
    public Transform PontoA;
    private float TempoParaORaio = 2f;


    private void Start()
    {
        functions = new Action[]
          {
           Funcao2_A,
          };
    }

    void Update()
    {



        float TempoentreAtaques = UnityEngine.Random.Range(TempoMinimoentreAtaques, TempoMaximoentreAtaques);
       
        
        if (Time.time >= nextAtack)
        {
            nextAtack = Time.time + TempoentreAtaques;

            ChamarFuncaoAleatoria();

        }
    
    }


    private void ChamarFuncaoAleatoria()
    {
        int indexAleatorio = UnityEngine.Random.Range(0, functions.Length);
        functions[indexAleatorio]?.Invoke();
    }

    void Funcao1_A()
    {
        GameObject ataque1A = Instantiate(Ataque1_A,PontoA.position , Quaternion.identity);
 
    }

    void Funcao1_B()
    {
        GameObject ataque1B = Instantiate(Ataque1_B, PontoA.position, Quaternion.identity);

    }

    void Funcao1_C()
    {
        GameObject ataque1C = Instantiate(Ataque1_C, PontoA.position, Quaternion.identity);

    }

    void Funcao2_A()
    {
        GameObject ataqueAviso = Instantiate(Ataque2Aviso_A, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);


       
          Destroy(ataqueAviso);
            GameObject AtaqueRaio = Instantiate(Ataque2_A, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);
        
    }

}
