using UnityEngine;
using System.Collections;

public class Triggerativeparede : MonoBehaviour
{
    public GameObject[] barrera;
    public float tempoestorado = 5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Desativaabarreara());
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Desativaabarreara()
    {
        yield return new WaitForSeconds(tempoestorado);     //obs: todo o codigo com trigger de parede tem a memsa categoria ( ativa com a tag PLayer, cuidado com isso, se o seu objeto nao tiver player o bagulho nao vai funcionar

        foreach (GameObject barreira in barrera)
        {
            barreira.SetActive(false);
        }
    }
}
