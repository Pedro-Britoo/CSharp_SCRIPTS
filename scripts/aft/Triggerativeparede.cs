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
        yield return new WaitForSeconds(tempoestorado);

        foreach (GameObject barreira in barrera)
        {
            barreira.SetActive(false);
        }
    }
}
