using UnityEngine;

public class DesaceleracaoParede : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            
            PlayerCarroComAceleracao playerCarro = other.GetComponent<PlayerCarroComAceleracao>();

           
            if (playerCarro != null)
            {
                playerCarro.velocidadeAtual = 0f; 
                
            }
        }
    }

  
}