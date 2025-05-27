using UnityEngine;
using TMPro;

public class DetectorDeVelocidade : MonoBehaviour
{
    public TextMeshPro visorVelocidade; // Referência ao texto da lombada

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Pega a velocidade em m/s e converte para km/h
            float velocidadeMS = rb.linearVelocity.magnitude;
            float velocidadeKMH = velocidadeMS * 3.6f;

            // Arredonda e exibe no visor
            visorVelocidade.text = Mathf.RoundToInt(velocidadeKMH) + " km/h";
            Debug.Log("Velocidade detectada: " + velocidadeKMH + " km/h");
        }
    }
}
