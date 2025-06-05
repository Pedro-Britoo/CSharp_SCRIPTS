using UnityEngine;
using UnityEngine.UI;

public class VerificadorDoCinto : MonoBehaviour
{
    public GameObject canvasCinto;
    public PlayerCarroComAceleracao scriptMovimento;

    private bool cintoAtivado = false;

    void Start()
    {
        if (scriptMovimento != null)
        {
            scriptMovimento.cintoAtivado = false;
        }
    }

    void Update()
    {
        if (!cintoAtivado && Input.GetKeyDown(KeyCode.G))
        {
            AtivarCinto();
        }
    }

    void AtivarCinto()
    {
        cintoAtivado = true;

        if (scriptMovimento != null)
            scriptMovimento.cintoAtivado = true;

        if (canvasCinto != null)
            canvasCinto.SetActive(false);

        Debug.Log("Cinto ativado. Carro liberado.");
    }
}
