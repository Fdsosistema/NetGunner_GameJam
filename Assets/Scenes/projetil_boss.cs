using System.Transactions;
using Unity.Mathematics;
using UnityEngine;

public class projetil_boss : MonoBehaviour
{

    public float velocidadeAtaque = 5f;
    public Transform PontoInicial;
    public Transform PontoFinal;
    private Vector3 alvo;
    private Vector3 pontoAnterior;
    private Vector3 deslocamnto;
    public bool VaiRepetir = false;

    private void Start()
    {
        alvo = PontoFinal.position;
        pontoAnterior = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvo, velocidadeAtaque * Time.deltaTime);
        deslocamnto = transform.position - deslocamnto;
        pontoAnterior = transform.position;

        if(VaiRepetir == true && Vector3.Distance(transform.position, alvo) < 0.1f)
        {
            alvo = (alvo == PontoInicial.position) ? PontoFinal.position : PontoInicial.position;
        };

    }
}
