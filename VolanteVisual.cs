using UnityEngine;

public class VolanteVisual : MonoBehaviour
{
    [Header("Configurações do Volante")]
    public float anguloMaximo = 45f; 
    public float suavidade = 5f;    

    private float inputHorizontal;
    private float anguloAtual;

    void Update()
    {
       
        inputHorizontal = Input.GetAxis("Horizontal");

        
        float anguloAlvo = -inputHorizontal * anguloMaximo;

      
        anguloAtual = Mathf.Lerp(anguloAtual, anguloAlvo, Time.deltaTime * suavidade);

        
        transform.localRotation = Quaternion.Euler(0f, 0f, anguloAtual);
    }
}
