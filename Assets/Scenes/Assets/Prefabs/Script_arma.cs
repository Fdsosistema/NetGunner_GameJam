using Unity.Mathematics;
using UnityEngine;

public class Script_arma : MonoBehaviour
{

    public Transform PontoOrigem;
    [SerializeField] private float VelocidadeRotacao = 60f;
    [SerializeField] GameObject CursorAim;

    private void Start()
    {
    }
    void Update()
    {
        Cursor.visible = false;
        Vector2 direcao = Camera.main.ScreenToWorldPoint(Input.mousePosition) - PontoOrigem.position;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        Quaternion rotacao = Quaternion.AngleAxis(angulo, Vector3.forward);
        PontoOrigem.rotation = Quaternion.Slerp(PontoOrigem.rotation, rotacao, VelocidadeRotacao * Time.deltaTime);

        Vector2 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CursorAim.transform.position = cursor;
    }

   


}
