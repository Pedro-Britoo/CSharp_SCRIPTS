using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCarroComAceleracao : MonoBehaviour
{
    public float aceleracaoInicial = 10f;
    public float velocidadeMaxima = 30f;
    public float rotacao = 100f;
    public float aceleracaoPorSegundo = 2f;

    public float velocidadeAtual;
    public float velocidadeAtualKmH { get; private set; }

    public int pontos = 100;

    private Rigidbody rb;
    private Vector3 ultimaPosicao;
    private bool bloqueado = false;
    public bool cintoAtivado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ultimaPosicao = transform.position;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (!cintoAtivado || bloqueado) return;

        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        // Aceleração progressiva
        if (inputVertical > 0f)
        {
            velocidadeAtual += aceleracaoPorSegundo * Time.fixedDeltaTime;
        }
        else if (inputVertical < 0f)
        {
            velocidadeAtual -= aceleracaoPorSegundo * Time.fixedDeltaTime;
        }
        else
        {
            velocidadeAtual = Mathf.MoveTowards(velocidadeAtual, 0f, aceleracaoPorSegundo * Time.fixedDeltaTime);
        }

        velocidadeAtual = Mathf.Clamp(velocidadeAtual, -velocidadeMaxima * 0.5f, velocidadeMaxima);

        // Movimento
        Vector3 movimento = transform.forward * velocidadeAtual * aceleracaoInicial * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimento);

        // Rotação
        if (Mathf.Abs(velocidadeAtual) > 0.1f)
        {
            float rotacaoDelta = inputHorizontal * rotacao * Time.fixedDeltaTime;
            Quaternion rotacaoAtual = Quaternion.Euler(0f, rotacaoDelta, 0f);
            rb.MoveRotation(rb.rotation * rotacaoAtual);
        }

        // Velocidade km/h
        float deslocamento = Vector3.Distance(transform.position, ultimaPosicao);
        float velocidadeMS = deslocamento / Time.fixedDeltaTime;
        velocidadeAtualKmH = velocidadeMS * 3.6f;

        ultimaPosicao = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Debug.Log("Player encostou");
            RemoverPontos(10);
            StartCoroutine(BloquearMovimentoTemporariamente(5f));
        }
    }

    void RemoverPontos(int valor)
    {
        pontos -= valor;
        Debug.Log("Pontos restantes: " + pontos);
    }

    IEnumerator BloquearMovimentoTemporariamente(float segundos)
    {
        bloqueado = true;
        velocidadeAtual = 0;
        yield return new WaitForSeconds(segundos);
        bloqueado = false;
    }
}