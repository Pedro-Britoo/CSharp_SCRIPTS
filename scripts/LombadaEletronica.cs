using UnityEngine;
using TMPro;

public class LombadaEletronica : MonoBehaviour
{
    public TextMeshPro textoVelocidade;
    public float limiteVelocidade = 30f; 
    public float penalidadeFator = 0.5f; 

    private void OnTriggerEnter(Collider other)
    {
        float velocidade = 0f;

       
        var player1 = other.GetComponent<PlayerMovimento>();
        if (player1 != null)
        {
            velocidade = player1.velocidadeAtualKmH;

            if (velocidade > limiteVelocidade)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity *= penalidadeFator;
                }
            }
        }

        var player2 = other.GetComponent<PlayerCarroComAceleracao>();
        if (player2 != null)
        {
            velocidade = player2.velocidadeAtualKmH;

            if (velocidade > limiteVelocidade)
            {
                player2.velocidadeAtual *= penalidadeFator;
            }
        }

        int velocidadeInt = Mathf.RoundToInt(velocidade);
        textoVelocidade.text = velocidadeInt + " km/h";

        Debug.Log("Velocidade detectada: " + velocidadeInt + " km/h");
    }
}
