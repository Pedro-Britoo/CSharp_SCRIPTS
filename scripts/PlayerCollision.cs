using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Pontuação do jogador
    private int pontos = 100;

    // Função chamada quando o jogador entra na área do trigger
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto com o qual o jogador colidiu tem o nome "faixa_invadida"
        if (other.CompareTag("FaixaInvadida"))
        {
            // Exibe uma mensagem de debug
            Debug.Log("Você invadiu a pista e perdeu pontos!");

            // Subtrai pontos
            pontos -= 10;

            // Opcional: Exibe a nova pontuação
            Debug.Log("Pontuação atual: " + pontos);
        }
    }
}
