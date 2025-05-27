using UnityEngine;

public class Radar : MonoBehaviour
{
    public float velocidadeLimite = 20f; 
    public float penalidade = 5f;        


    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            Debug.Log("player nao foi detectado");

   
            PlayerCarroComAceleracao playerScript = other.GetComponent<PlayerCarroComAceleracao>();

            if (playerScript != null)
            {
             
                Debug.Log("Velocidade do Player: " + playerScript.velocidadeAtual);

               
                if (playerScript.velocidadeAtual >= velocidadeLimite)
                {
             
                    playerScript.velocidadeAtual -= penalidade;
                     playerScript.velocidadeAtual = Mathf.Clamp(playerScript.velocidadeAtual, 0f, playerScript.velocidadeMaxima);

                    Debug.Log("Player penalizado! Nova velocidade: " + playerScript.velocidadeAtual);
                }
                else
                {
                    Debug.Log("Velocidade abaixo do limite, sem penalização.");
                }
            }
        }
    }
}
