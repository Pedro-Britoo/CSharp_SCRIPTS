using UnityEngine;

public class ParedeTrigger : MonoBehaviour
{
    public LinhaAtivadora linhaAlvo;
    public bool ativaLinha; // boll de verdadeiro ou falso carai

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
