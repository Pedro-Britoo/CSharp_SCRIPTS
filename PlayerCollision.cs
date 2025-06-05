using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Pontua��o do jogador
    private int pontos = 100;

    // Fun��o chamada quando o jogador entra na �rea do trigger
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto com o qual o jogador colidiu tem o nome "faixa_invadida"
        if (other.CompareTag("FaixaInvadida"))
        {
            // Exibe uma mensagem de debug
            Debug.Log("Voc� invadiu a pista e perdeu pontos!");

            // Subtrai pontos
            pontos -= 10;

            // Opcional: Exibe a nova pontua��o
            Debug.Log("Pontua��o atual: " + pontos);
        }
    }
}
