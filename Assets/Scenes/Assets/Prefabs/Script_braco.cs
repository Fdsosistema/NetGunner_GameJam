using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Script_braco : MonoBehaviour
{
    public float ValorAngulo = 45f;
    public Transform PontoOrigem;
    [SerializeField] private float VelocidadeRotacao = 60f;
    
 


   
    void Update()
    {
       
        Vector2 direcao = Camera.main.ScreenToWorldPoint(Input.mousePosition) - PontoOrigem.position;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg + ValorAngulo;
        Quaternion rotacao = Quaternion.AngleAxis(angulo, Vector3.forward);
        PontoOrigem.rotation = Quaternion.Slerp(PontoOrigem.rotation, rotacao, VelocidadeRotacao * Time.deltaTime);

        
       


       


    }
    
   
 


   


}
