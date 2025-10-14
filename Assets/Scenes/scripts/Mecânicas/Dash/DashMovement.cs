using UnityEngine;


public class Dash : MonoBehaviour
{

    public float forcaPulo = 8f;
    public float MultiplicadorPulo = 2f;
    public float velocidade = 5f;       // Velocidade normal de movimento
    public float forcaDash = 15f;       // Intensidade do dash
    public float tempoDash = 0.2f;      // Duração do dash
    public float tempoRecarga = 1f;     // Tempo até poder dar outro dash
    public Transform checarChao;
    public float raioChecagem = 0.2f;
    public LayerMask chaoLayer;

    private Rigidbody2D rb;
    private bool podeDarDash = true;    // Controla cooldown
    private bool estaDashando;          // Verifica se o player está dashing
    private bool PodePular;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Se já está em dash, ignora o controle comum
        if (estaDashando) return;

        // Movimento horizontal
        float movimento = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);

        // Se apertar SHIFT e puder dashing, inicia
        if (Input.GetKeyDown(KeyCode.LeftShift) && podeDarDash)
        {
            StartCoroutine(ExecutarDash(movimento));
        }

        // Vira o sprite de acordo com a direção
        if (movimento != 0)
            transform.localScale = new Vector3(Mathf.Sign(movimento), 1, 1);

        PodePular = Physics2D.OverlapCircle(checarChao.position, raioChecagem, chaoLayer);
        if (Input.GetKeyDown(KeyCode.Space) && PodePular)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }

        // Se o jogador apertar espaço e estiver no chão, pula
        if (Input.GetKey(KeyCode.LeftControl) && PodePular)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo * MultiplicadorPulo);
        }

    }

    private System.Collections.IEnumerator ExecutarDash(float direcao)
    {
        // Marca o início do dash
        podeDarDash = false;
        estaDashando = true;

        // Aplica a velocidade intensa por um curto período
        rb.linearVelocity = new Vector2(direcao * forcaDash, 0f);

        yield return new WaitForSeconds(tempoDash);

        // Finaliza o dash e retorna ao controle normal
        estaDashando = false;

        // Espera até o cooldown acabar
        yield return new WaitForSeconds(tempoRecarga);
        podeDarDash = true;
    }

    void OnDrawGizmosSelected()
    {
        if (checarChao == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(checarChao.position, raioChecagem);
    }

}
