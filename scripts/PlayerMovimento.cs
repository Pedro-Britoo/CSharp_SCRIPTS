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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        ultimaPosicao = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (bloqueado) return;

        float h = Input.GetAxisRaw("Horizontal"); // A (-1) / D (1)
        float v = Input.GetAxisRaw("Vertical");   // S (-1) / W (1)

        Vector3 inputDir = new Vector3(h, 0, v);
        if (inputDir.magnitude > 1)
            inputDir.Normalize();

        direcao = transform.TransformDirection(inputDir);
    }

    void FixedUpdate()
    {
        if (bloqueado) return;

        Vector3 movimento = direcao * velocidade * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimento);

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
