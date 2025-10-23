using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class boss_ifunny : MonoBehaviour
{
    private Action[] functions; 

    public GameObject Ataque1_A;
    public GameObject Ataque1_B;
    public GameObject Ataque1_C;
    public GameObject Ataque2Aviso_A;
    public GameObject Ataque2_A;
    public GameObject Ataque2Aviso_B;
    public GameObject Ataque2_B;


    private float nextAtack = 5f;
    public float TempoMinimoentreAtaques = 1f;
    public float TempoMaximoentreAtaques = 10f;
    public float velocidadeAtaque = 5f;
    public Transform PontoA;
    private float TempoParaORaio = 2f;
    private float delayif = 1.5f;


    private void Start()
    {
        functions = new Action[]
          {
           Funcao2_B,
           Funcao1_A,
           Funcao1_B,
           Funcao1_C,
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

        StartCoroutine(Tempo());

        IEnumerator Tempo()
        {
            yield return new WaitForSeconds(2);

            Destroy(ataqueAviso);
            GameObject AtaqueRaio = Instantiate(Ataque2_A, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);

            StartCoroutine(DestruirAposTempo());

            IEnumerator DestruirAposTempo()
            {
                yield return new WaitForSeconds(1);
                Destroy(AtaqueRaio);
            }
        }
    }

    void Funcao2_B()
    {
        GameObject ataqueAvisoB = Instantiate(Ataque2Aviso_B, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);

        StartCoroutine(Tempo());

        IEnumerator Tempo()
        {
            yield return new WaitForSeconds(2);

            Destroy(ataqueAvisoB);
            GameObject AtaqueRaioB = Instantiate(Ataque2_B, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);

            StartCoroutine(DestruirAposTempo());

            IEnumerator DestruirAposTempo()
            {
                yield return new WaitForSeconds(1);
                Destroy(AtaqueRaioB);
            }
        }
    }



}
