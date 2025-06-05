using UnityEngine;

public class AtivaEstacionamento : MonoBehaviour
{
    public GameObject[] barreiras; 
    public GameObject canvasEstacione;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject barreira in barreiras)
            {
                barreira.SetActive(true); 
            }

            if (canvasEstacione != null)
            {
                canvasEstacione.SetActive(true); 
            }

            
            gameObject.SetActive(true);
        }
    }
}
