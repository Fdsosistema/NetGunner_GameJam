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
    private bool podeAtacar = true;

    public GameObject Ataque2C1Aviso;
    public GameObject Ataque2C1;
    public GameObject Ataque2C2Aviso;
    public GameObject Ataque2C2;
    public GameObject Ataque2C3Aviso;
    public GameObject Ataque2C3;

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
       
        
        if (Time.time >= nextAtack && podeAtacar == true)
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
        podeAtacar = false;
        StartCoroutine(PodeAtacarTrue1A());
        IEnumerator PodeAtacarTrue1A()
        {
            yield return new WaitForSeconds(2);
            podeAtacar = true;
        }
    }

    void Funcao1_B()
    {
        GameObject ataque1B = Instantiate(Ataque1_B, PontoA.position, Quaternion.identity);
        podeAtacar = false;
        StartCoroutine(PodeAtacarTrue1B());
        IEnumerator PodeAtacarTrue1B()
        {
            yield return new WaitForSeconds(2);
            podeAtacar = true;
        }
    }

    void Funcao1_C()
    {
        GameObject ataque1C = Instantiate(Ataque1_C, PontoA.position, Quaternion.identity);
        podeAtacar = false;
        StartCoroutine(PodeAtacarTrue1C());
        IEnumerator PodeAtacarTrue1C()
        {
            yield return new WaitForSeconds(2);
            podeAtacar = true;
        }
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
        podeAtacar = false;
        StartCoroutine(PodeAtacarTrue2A());
        IEnumerator PodeAtacarTrue2A()
        {
            yield return new WaitForSeconds(3);
            podeAtacar = true;
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
        podeAtacar = false;
        StartCoroutine(PodeAtacarTrue2B());
        IEnumerator PodeAtacarTrue2B()
        {
            yield return new WaitForSeconds(3);
            podeAtacar = true;
        }
    }

    void Funcao3_B()
    {
        GameObject ataqueavisoC1 = Instantiate(Ataque2C1Aviso, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);

        StartCoroutine(Tempo());

        IEnumerator Tempo()
        {
            yield return new WaitForSeconds(2);

            Destroy(ataqueavisoC1);
            GameObject AtaqueRaioC1 = Instantiate(Ataque2C1, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);

            StartCoroutine(DestruirAposTempo());

            IEnumerator DestruirAposTempo()
            {
                yield return new WaitForSeconds(0.5f);
                Destroy(AtaqueRaioC1);
            }
        }




        podeAtacar = false;
        StartCoroutine(PodeAtacarTrue2B());
        IEnumerator PodeAtacarTrue2B()
        {
            yield return new WaitForSeconds(2.5f);
            podeAtacar = true;
        }
    }

}
