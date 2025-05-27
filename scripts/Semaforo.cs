using UnityEngine;
using System.Collections;

public class Semaforo : MonoBehaviour
{
    public GameObject luzVermelha;
    public GameObject luzAmarela;
    public GameObject luzVerde; 

    void Start()
    {
        StartCoroutine(ControlarSemaforo());
    }

    IEnumerator ControlarSemaforo()
    {
        while (true)
        {
           
            luzVermelha.SetActive(true);
            luzAmarela.SetActive(false);
            luzVerde.SetActive(false);
            yield return new WaitForSeconds(5f);  // ESPERA SEGUNDOS PARA ATIVAR A LUZS VERMELHA

            
            luzVermelha.SetActive(false);
            luzAmarela.SetActive(true);
            luzVerde.SetActive(false);
            yield return new WaitForSeconds(3f); // ESPERA SEGUNDOS PARA ATIVAR A LUZ VERMELHA


            luzVermelha.SetActive(false);
            luzAmarela.SetActive(false);
            luzVerde.SetActive(true);
            yield return new WaitForSeconds(10f); // ESPERA SEGUNDOS PARA ATIVAR A LUZ VERMELHA
        }
    }


}
