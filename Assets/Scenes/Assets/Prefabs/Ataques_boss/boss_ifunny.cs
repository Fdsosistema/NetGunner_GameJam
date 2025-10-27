using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public Transform PontoDisparoBoss;
    public Transform PontoPlayer;
    public Transform PontoInicialAnimacao;
    public Transform PontoFinalAnimacao;
    public Sprite OlhosBrilantes;
    public Sprite IfunnyNormal;
    public Sprite Eletricidade;
    private SpriteRenderer OlhosBrilantesRenderer;

    private Vector3 pontoAnterior;
    private Vector3 deslocamnto;

    private float nextAtack = 5f;
    public float TempoMinimoentreAtaques = 1f;
    public float TempoMaximoentreAtaques = 10f;
    public Transform PontoA;
    private bool podeAtacar = true;
    public float spreadAngle = 90f;
    public int NumeroDeProjeteis = 8;
    public float VelocidadeProjetilEletrico = 10f;
    private float velocidadeAtaque = 10f;


    public GameObject Ataque2C1Aviso;
    public GameObject Ataque2C1;
    public GameObject Ataque2C2Aviso;
    public GameObject Ataque2C2;
    public GameObject Ataque2C3Aviso;
    public GameObject Ataque2C3;
    public GameObject Ataque2C4Aviso;
    public GameObject Ataque2C4;
    public GameObject AtaqueEletrico;

    private void Start()
    {
        functions = new Action[]
          {
  Funcao1_A,
  Funcao1_B,
  Funcao1_C,
  Funcao2_A,
  Funcao2_B,
  Funcao2_C,
      Funcao3,
      Funcao3_B
    
          };


        pontoAnterior = transform.position;
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
        podeAtacar = false;

        Vector3 alvo = new Vector2(9f, 7.423934f);


        StartCoroutine(Ataque1A());
      
         IEnumerator Ataque1A()
        { 

            while (Vector3.Distance(transform.position, alvo) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
            pontoAnterior = transform.position;
            yield return null;
        }
            yield return new WaitForSeconds(1.5f);
            GameObject ataque1A = Instantiate(Ataque1_A,PontoA.position , Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
            if (Vector3.Distance(transform.position, alvo) < 0.01f)
            {
                alvo = (alvo == PontoInicialAnimacao.position) ? PontoFinalAnimacao.position : PontoInicialAnimacao.position;
                while (Vector3.Distance(transform.position, alvo) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                    pontoAnterior = transform.position;

                    yield return null;
                }
            }
        }

        StartCoroutine(PodeAtacarTrue1A());
        IEnumerator PodeAtacarTrue1A()
        {
            yield return new WaitForSeconds(5.5f);
            podeAtacar = true;
        }

    }

    void Funcao1_B()
    {

        Vector3 alvo = new Vector2(-9f, 7.423934f);


        StartCoroutine(Ataque1B());

        IEnumerator Ataque1B()
        {

            while (Vector3.Distance(transform.position, alvo) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                pontoAnterior = transform.position;
                yield return null;
            }
            yield return new WaitForSeconds(1.5f);
            GameObject ataque1B = Instantiate(Ataque1_B, PontoA.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
            if (Vector3.Distance(transform.position, alvo) < 0.01f)
            {
                alvo = (alvo == PontoInicialAnimacao.position) ? PontoFinalAnimacao.position : PontoInicialAnimacao.position;
                while (Vector3.Distance(transform.position, alvo) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                    pontoAnterior = transform.position;
                    yield return null;
                }
            }
        }


        podeAtacar = false;
        StartCoroutine(PodeAtacarTrue1B());
        IEnumerator PodeAtacarTrue1B()
        {
            yield return new WaitForSeconds(5.5f);
            podeAtacar = true;
        }
    }

    void Funcao1_C()
    {

        Vector3 alvo = new Vector2(transform.position.x,5.423934f);


        StartCoroutine(Ataque1C());

        IEnumerator Ataque1C()
        {

            while (Vector3.Distance(transform.position, alvo) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                pontoAnterior = transform.position;
                yield return null;
            }
            yield return new WaitForSeconds(1.5f);
            GameObject ataque1C = Instantiate(Ataque1_C, PontoA.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
            if (Vector3.Distance(transform.position, alvo) < 0.01f)
            {
                alvo = (alvo == PontoInicialAnimacao.position) ? PontoFinalAnimacao.position : PontoInicialAnimacao.position;
                while (Vector3.Distance(transform.position, alvo) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                    pontoAnterior = transform.position;
                    yield return null;
                }
            }
        }


        podeAtacar = false;
        StartCoroutine(PodeAtacarTrue1C());
        IEnumerator PodeAtacarTrue1C()
        {
            yield return new WaitForSeconds(5.5f);
            podeAtacar = true;
        }
    }

    void Funcao2_A()
    {


        Vector3 alvo = new Vector2(transform.position.x, 4.423934f);


        StartCoroutine(Ataque2A());

        IEnumerator Ataque2A()
        {
            OlhosBrilantesRenderer = GetComponent<SpriteRenderer>();
            OlhosBrilantesRenderer.sprite = OlhosBrilantes;

            while (Vector3.Distance(transform.position, alvo) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                pontoAnterior = transform.position;
                yield return null;
             
            }
            yield return new WaitForSeconds(0.5f);
            GameObject ataqueAviso = Instantiate(Ataque2Aviso_A, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);

            yield return new WaitForSeconds(2);

            Destroy(ataqueAviso);
            GameObject AtaqueRaio = Instantiate(Ataque2_A, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);


            yield return new WaitForSeconds(1);
            Destroy(AtaqueRaio);


            yield return new WaitForSeconds(0.5f);
            if (Vector3.Distance(transform.position, alvo) < 0.01f)
            {
                alvo = (alvo == PontoInicialAnimacao.position) ? PontoFinalAnimacao.position : PontoInicialAnimacao.position;
                while (Vector3.Distance(transform.position, alvo) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                    pontoAnterior = transform.position;
                    OlhosBrilantesRenderer.sprite = IfunnyNormal;
                    yield return null;
                   
                }
               
            }
        }


        podeAtacar = false;
        StartCoroutine(PodeAtacarTrue2A());
        IEnumerator PodeAtacarTrue2A()
        {
            yield return new WaitForSeconds(6.5f);
            podeAtacar = true;
        }
    }

    void Funcao2_B()
    {
  
        Vector3 alvo = new Vector2(9f, 4.423934f);


        StartCoroutine(Ataque2B());

        IEnumerator Ataque2B()
        {
            OlhosBrilantesRenderer = GetComponent<SpriteRenderer>();
            OlhosBrilantesRenderer.sprite = OlhosBrilantes;

            while (Vector3.Distance(transform.position, alvo) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                pontoAnterior = transform.position;
                yield return null;

            }
            yield return new WaitForSeconds(0.5f);
            GameObject ataqueAvisoB = Instantiate(Ataque2Aviso_B, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);

            yield return new WaitForSeconds(2);

            Destroy(ataqueAvisoB);
            GameObject AtaqueRaioB = Instantiate(Ataque2_B, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);


            yield return new WaitForSeconds(1);
            Destroy(AtaqueRaioB);


            yield return new WaitForSeconds(0.5f);
            if (Vector3.Distance(transform.position, alvo) < 0.01f)
            {
                alvo = (alvo == PontoInicialAnimacao.position) ? PontoFinalAnimacao.position : PontoInicialAnimacao.position;
                while (Vector3.Distance(transform.position, alvo) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                    pontoAnterior = transform.position;
                    OlhosBrilantesRenderer.sprite = IfunnyNormal;
                    yield return null;

                }

            }
        }


        podeAtacar = false;
        StartCoroutine(PodeAtacarTrue2B());
        IEnumerator PodeAtacarTrue2B()
        {
            yield return new WaitForSeconds(6.5f);
            podeAtacar = true;
        }
            
    }

   

    //Sequencia de ataques o boss
    void Funcao2_C()
    {
        podeAtacar = false;


        Vector3 alvo = new Vector2(-9f, 4.423934f);


        StartCoroutine(Ataque2C());

        IEnumerator Ataque2C()
        {
            OlhosBrilantesRenderer = GetComponent<SpriteRenderer>();
            OlhosBrilantesRenderer.sprite = OlhosBrilantes;

            while (Vector3.Distance(transform.position, alvo) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                pontoAnterior = transform.position;
                yield return null;

            }
            yield return new WaitForSeconds(0.5f);
            GameObject ataqueAvisoC = Instantiate(Ataque2C1Aviso, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);

            yield return new WaitForSeconds(2);

            Destroy(ataqueAvisoC);
            GameObject AtaqueRaioC = Instantiate(Ataque2C1, new Vector3(7.560022f, -1.383803f, -0.02648988f), Quaternion.identity);


            yield return new WaitForSeconds(0.5f);
            Destroy(AtaqueRaioC);

            yield return new WaitForSeconds(0.5f);
            Ataque_boss_sequencia_2();

      


      
        }





    }




    void Ataque_boss_sequencia_2()
    {

            GameObject ataqueavisoC2 = Instantiate(Ataque2C2Aviso, new Vector3(8.83f, 0.1544533f, -0.02648988f), Quaternion.identity);

            StartCoroutine(TempoC2());

            IEnumerator TempoC2()
            {
                yield return new WaitForSeconds(2);

                Destroy(ataqueavisoC2);
                GameObject AtaqueRaioC2 = Instantiate(Ataque2C2, new Vector3(8.83f, 0.1544533f, -0.02648988f), Quaternion.identity);

                StartCoroutine(DestruirAposTempo());

                IEnumerator DestruirAposTempo()
                {
                    yield return new WaitForSeconds(0.5f);
                    Destroy(AtaqueRaioC2);
                yield return new WaitForSeconds(0.5f);
                Ataque_boss_sequencia_3();
                 
                }


            }
    }

    void Ataque_boss_sequencia_3()
    {

        GameObject ataqueavisoC3 = Instantiate(Ataque2C3Aviso, new Vector3(8.83f, 0.1544533f, -0.02648988f), Quaternion.identity);

        StartCoroutine(TempoC3());

        IEnumerator TempoC3()
        {
            yield return new WaitForSeconds(2);

            Destroy(ataqueavisoC3);
            GameObject AtaqueRaioC3 = Instantiate(Ataque2C3, new Vector3(8.83f, 0.1544533f, -0.02648988f), Quaternion.identity);

            StartCoroutine(DestruirAposTempo());

            IEnumerator DestruirAposTempo()
            {
                yield return new WaitForSeconds(0.25f);
                Destroy(AtaqueRaioC3);
                yield return new WaitForSeconds(0.5f);
                Ataque_boss_sequencia_4();
            }


        }
    }

    void Ataque_boss_sequencia_4()
    {

        Vector3 alvo = new Vector2(-9f, 4.423934f);

        GameObject ataqueavisoC4 = Instantiate(Ataque2C4Aviso, new Vector3(8.83f, 0.1544533f, -0.02648988f), Quaternion.identity);

        StartCoroutine(TempoC3());

        IEnumerator TempoC3()
        {
            yield return new WaitForSeconds(2);

            Destroy(ataqueavisoC4);
            GameObject AtaqueRaioC4 = Instantiate(Ataque2C4, new Vector3(8.83f, 0.1544533f, -0.02648988f), Quaternion.identity);

            StartCoroutine(DestruirAposTempo());

            IEnumerator DestruirAposTempo()
            {
                yield return new WaitForSeconds(0.25f);
                Destroy(AtaqueRaioC4);
              
            }

            yield return new WaitForSeconds(0.5f);
            if (Vector3.Distance(transform.position, alvo) < 0.01f)
            {
                alvo = (alvo == PontoInicialAnimacao.position) ? PontoFinalAnimacao.position : PontoInicialAnimacao.position;
                while (Vector3.Distance(transform.position, alvo) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                    pontoAnterior = transform.position;
                    OlhosBrilantesRenderer.sprite = IfunnyNormal;
                    yield return null;

                }

            }

            StartCoroutine(PodeAtacarTrue2C());
            IEnumerator PodeAtacarTrue2C()
            {
                yield return new WaitForSeconds(2.5f);
                podeAtacar = true;
            }
        }
    }
    //Sequencia de ataques o boss

    void Funcao3()
    {
        podeAtacar = false;

        
        

        Vector3 alvo = new Vector2(9f, 7.423934f);



        StartCoroutine(Ataque3());

        IEnumerator Ataque3()
        {

            OlhosBrilantesRenderer = GetComponent<SpriteRenderer>();
            OlhosBrilantesRenderer.sprite = OlhosBrilantes;

            while (Vector3.Distance(transform.position, alvo) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                pontoAnterior = transform.position;
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);

            Vector2 direcao = (PontoPlayer.position - transform.position).normalized;

            for (int i = 0; i < NumeroDeProjeteis; i++)
            {
                Vector2 spread = DirecaoSpread(direcao, spreadAngle);
                GameObject ataqueEletricoRaio = Instantiate(AtaqueEletrico, PontoDisparoBoss.position, Quaternion.identity);
                Rigidbody2D rb = ataqueEletricoRaio.GetComponent<Rigidbody2D>();
                rb.linearVelocity = spread * VelocidadeProjetilEletrico;
            }

            StartCoroutine(Espera());

            IEnumerator Espera()
            {
                {
                    Vector2 direcao = (PontoPlayer.position - transform.position).normalized;
                    yield return new WaitForSeconds(0.75f);

                    for (int i = 0; i < NumeroDeProjeteis; i++)
                    {

                        Vector2 spread = DirecaoSpread(direcao, spreadAngle);
                        GameObject ataqueEletricoRaio = Instantiate(AtaqueEletrico, PontoDisparoBoss.position, Quaternion.identity);
                        Rigidbody2D rb = ataqueEletricoRaio.GetComponent<Rigidbody2D>();
                        rb.linearVelocity = spread * VelocidadeProjetilEletrico;
                    }

                    yield return new WaitForSeconds(1.5f);

                    for (int i = 0; i < NumeroDeProjeteis; i++)
                    {

                        Vector2 spread = DirecaoSpread(direcao, spreadAngle);
                        GameObject ataqueEletricoRaio = Instantiate(AtaqueEletrico, PontoDisparoBoss.position, Quaternion.identity);
                        Rigidbody2D rb = ataqueEletricoRaio.GetComponent<Rigidbody2D>();
                        rb.linearVelocity = spread * VelocidadeProjetilEletrico;
                    }



                }
            }



            yield return new WaitForSeconds(2.5f);
            if (Vector3.Distance(transform.position, alvo) < 0.01f)
            {
                alvo = (alvo == PontoInicialAnimacao.position) ? PontoFinalAnimacao.position : PontoInicialAnimacao.position;
                while (Vector3.Distance(transform.position, alvo) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                    pontoAnterior = transform.position;
                    OlhosBrilantesRenderer.sprite = IfunnyNormal;
                    yield return null;
                }
            }
        }


       

       
        StartCoroutine(PodeAtacarTrue2B());
        IEnumerator PodeAtacarTrue2B()
        {
            yield return new WaitForSeconds(7.5f);
            podeAtacar = true;
        }

    }



    void Funcao3_B()
    {
        podeAtacar = false;




        Vector3 alvo = new Vector2(-9f, 7.423934f);



        StartCoroutine(Ataque3_B());

        IEnumerator Ataque3_B()
        {

            OlhosBrilantesRenderer = GetComponent<SpriteRenderer>();
            OlhosBrilantesRenderer.sprite = OlhosBrilantes;

            while (Vector3.Distance(transform.position, alvo) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                pontoAnterior = transform.position;
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);


            Vector2 direcao = (PontoPlayer.position - transform.position).normalized;

            for (int i = 0; i < NumeroDeProjeteis; i++)
            {
                Vector2 spread = DirecaoSpread(direcao, spreadAngle);
                GameObject ataqueEletricoRaio = Instantiate(AtaqueEletrico, PontoDisparoBoss.position, Quaternion.identity);
                Rigidbody2D rb = ataqueEletricoRaio.GetComponent<Rigidbody2D>();
                rb.linearVelocity = spread * VelocidadeProjetilEletrico;
            }

            StartCoroutine(Espera());

            IEnumerator Espera()
            {
                {
         
                    yield return new WaitForSeconds(0.75f);

                    for (int i = 0; i < NumeroDeProjeteis; i++)
                    {

                        Vector2 spread = DirecaoSpread(direcao, spreadAngle);
                        GameObject ataqueEletricoRaio = Instantiate(AtaqueEletrico, PontoDisparoBoss.position, Quaternion.identity);
                        Rigidbody2D rb = ataqueEletricoRaio.GetComponent<Rigidbody2D>();
                        rb.linearVelocity = spread * VelocidadeProjetilEletrico;
                    }

                    yield return new WaitForSeconds(1.5f);

                    for (int i = 0; i < NumeroDeProjeteis; i++)
                    {

                        Vector2 spread = DirecaoSpread(direcao, spreadAngle);
                        GameObject ataqueEletricoRaio = Instantiate(AtaqueEletrico, PontoDisparoBoss.position, Quaternion.identity);
                        Rigidbody2D rb = ataqueEletricoRaio.GetComponent<Rigidbody2D>();
                        rb.linearVelocity = spread * VelocidadeProjetilEletrico;
                    }



                }
            }



            yield return new WaitForSeconds(2.5f);
            if (Vector3.Distance(transform.position, alvo) < 0.01f)
            {
                alvo = (alvo == PontoInicialAnimacao.position) ? PontoFinalAnimacao.position : PontoInicialAnimacao.position;
                while (Vector3.Distance(transform.position, alvo) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
                    pontoAnterior = transform.position;
                    OlhosBrilantesRenderer.sprite = IfunnyNormal;
                    yield return null;
                }
            }
        }





        StartCoroutine(PodeAtacarTrue2B());
        IEnumerator PodeAtacarTrue2B()
        {
            yield return new WaitForSeconds(7.5f);
            podeAtacar = true;
        }

    }



    Vector2 DirecaoSpread(Vector2 direcao, float angle)
        {
            float x = UnityEngine.Random.Range(-angle / 2f, angle / 3f);
            float y = UnityEngine.Random.Range(-angle / 2f, angle / 3f);

            Quaternion spreadRotacao = Quaternion.Euler(x, y, x);
            return spreadRotacao * direcao;
        }

    }
