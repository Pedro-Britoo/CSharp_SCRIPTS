using UnityEngine;

public class DetectorInvasaoSemaforo : MonoBehaviour
{
    public Semaforo semaforo; // Refer�ncia ao script do sem�foro
    public CarroWaypoint carro; // Refer�ncia ao carro que deve bater no player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (semaforo.luzVermelha.activeSelf) // Se o sem�foro estiver vermelho
            {
                Debug.Log("Jogador furou o sinal vermelho!");
                carro.enabled = true; // Ativa o carro para seguir o caminho
            }
        }
    }
}
