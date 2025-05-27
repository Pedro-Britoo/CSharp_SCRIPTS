using UnityEngine;

public class ParedeTrigger : MonoBehaviour
{
    public LinhaAtivadora linhaAlvo;
    public bool ativaLinha; // Se verdadeiro ativa, se falso desativa

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ativaLinha)
                linhaAlvo.AtivarLinha();
            else
                linhaAlvo.DesativarLinha();
        }
    }
}
