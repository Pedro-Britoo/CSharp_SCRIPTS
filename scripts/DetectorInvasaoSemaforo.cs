using UnityEngine;

public class DetectorInvasaoSemaforo : MonoBehaviour
{
    public Semaforo semaforo; // Referência ao script do semáforo
    public CarroWaypoint carro; // Referência ao carro que deve bater no player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (semaforo.luzVermelha.activeSelf) // Se o semáforo estiver vermelho
            {
                Debug.Log("Jogador furou o sinal vermelho!");
                carro.enabled = true; // Ativa o carro para seguir o caminho
            }
        }
    }
}
