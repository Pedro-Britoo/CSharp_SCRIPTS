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
            // NÃO desativa o gameObject aqui, senão coroutine para
            // gameObject.SetActive(false);
        }
    }

    private IEnumerator Desativaabarreara()
    {
        yield return new WaitForSeconds(tempoestorado);

        foreach (GameObject barreira in barrera)
        {
            barreira.SetActive(false);
        }

        // Agora que desativou as barreiras, pode desativar a parede que disparou
        gameObject.SetActive(false);
    }


}