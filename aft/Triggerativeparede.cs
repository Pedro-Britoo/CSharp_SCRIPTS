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
            // N�O desativa o gameObject aqui, sen�o coroutine para
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