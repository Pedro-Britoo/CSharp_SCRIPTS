using UnityEngine;

public class VerificadorAreaProibida : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AreaProibida"))
        {
            Debug.LogError("eRRO: O jogador entrou em uma are probida!");
        }
    }
}
