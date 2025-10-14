using UnityEngine;

public class Script_arma : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject projetilPrefab;
    public Transform pontoDisparo;

    // Update is called once per frame
    void Update()
    {
        
    }

    void Disparar()
    {


        Vector3 mouse = Input.mousePosition;
        Vector3 PontoCena = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 offset = new Vector2(mouse.x - PontoCena.x, mouse.z - PontoCena.z);
        //Vector3 angulo = Mathf.Atan2(offset.z, offset.x) * Mathf.Rad2Deg;




    }

}
