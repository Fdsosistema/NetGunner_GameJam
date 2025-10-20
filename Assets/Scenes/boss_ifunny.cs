using UnityEngine;
using System;

public class boss_ifunny : MonoBehaviour
{
    private Action[] functions; 

    public GameObject QuadradoAtaque;
    
    private float nextAtack = 5f;
    public float TempoMinimoentreAtaques = 1f;
    public float TempoMaximoentreAtaques = 10f;
    public float velocidadeAtaque = 5f;
    public Transform PontoA;


    private void Start()
    {
        functions = new Action[]
          {
                Ataque1_A,
               
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

    void Ataque1_A()
    {
        GameObject ataque1_A = Instantiate(QuadradoAtaque,PontoA.position , Quaternion.identity);
 
    }

    void FunctionB()
    {
        Debug.Log("CU  was called!");
    }

    void FunctionC()
    {
        Debug.Log("Merda was called!");
    }



}
