using UnityEngine;

public class DetectaContatoPlayer : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Você encostou no canto da pista!");

            
        }
    }
}
    