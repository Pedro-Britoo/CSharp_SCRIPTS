using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovimento : MonoBehaviour
{
    public float velocidade = 5f;
    public float velocidadeAtualKmH { get; private set; }
    public int pontos = 100;

    private Rigidbody rb;
    private Vector3 direcao;
    private Vector3 ultimaPosicao;
    private bool bloqueado = false;
    public bool cintoAtivado = false;


    void Start()
    {
       
            rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        ultimaPosicao = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!cintoAtivado || bloqueado) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        direcao = (transform.right * h + transform.forward * v).normalized;
    }

    void FixedUpdate()
    {
        if (!cintoAtivado || bloqueado) return;

        Vector3 movimento = direcao * velocidade;
        Vector3 novaPosicao = rb.position + movimento * Time.fixedDeltaTime;
        rb.MovePosition(novaPosicao);

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
        yield return new WaitForSeconds(segundos);
        bloqueado = false;
    }
}