using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Script_arma : MonoBehaviour
{

    public Transform PontoOrigem;
    [SerializeField] private float VelocidadeRotacao = 60f;
    [SerializeField] GameObject CursorAim;
    private SpriteRenderer RecarregarRenderer;
    [SerializeField] GameObject Recarregar;
    private bool Atirou = false;
    private float nextFire = 0f;

    private bool EstaCarregando = false;

    private void Start()
    {
      
        Cursor.visible = false;
    }
    void Update()
    {
        Cursor.visible = false;
        Vector2 direcao = Camera.main.ScreenToWorldPoint(Input.mousePosition) - PontoOrigem.position;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        Quaternion rotacao = Quaternion.AngleAxis(angulo, Vector3.forward);
        PontoOrigem.rotation = Quaternion.Slerp(PontoOrigem.rotation, rotacao, VelocidadeRotacao * Time.deltaTime);

        Vector2 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && EstaCarregando == false )
        {
            Atirou = true;
            EstaCarregando=true;
            StartCoroutine(EsperarRecarga());
        }


        if (Atirou == false)
        {
            CursorAim.SetActive(true);
            CursorAim.transform.position = cursor;
        } else if(Atirou == true)
        {
            Recarregar.SetActive(true);
            CursorAim.SetActive(false);
            Recarregar.transform.position = cursor;
           
        }


    }
    
   
 


    IEnumerator EsperarRecarga()
    {
        yield return new WaitForSeconds(3);
        Atirou = false;
        EstaCarregando = false;
        Recarregar.SetActive(false );
    }


}
