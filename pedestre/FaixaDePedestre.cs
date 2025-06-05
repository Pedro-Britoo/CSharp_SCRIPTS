using UnityEngine;
using System.Collections;

public class FaixaDePedestre : MonoBehaviour
{
    public GameObject luzVermelha;

    private Coroutine penalizacaoCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && luzVermelha.activeSelf)
        {
            penalizacaoCoroutine = StartCoroutine(ContarPenalizacao());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && penalizacaoCoroutine != null)
        {
            StopCoroutine(penalizacaoCoroutine);
            penalizacaoCoroutine = null;
        }
    }

    IEnumerator ContarPenalizacao()
    {
        float tempo = 0f;

        while (tempo < 3f)
        {
            if (!luzVermelha.activeSelf)
            {
                yield break; 
            }

            tempo += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Penalização: ficou 3 segundos na faixa com o sinal vermelho!");
    }
}
