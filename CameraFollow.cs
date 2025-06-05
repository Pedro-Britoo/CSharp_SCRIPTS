using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform alvo;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float suavidade = 5f;

    void LateUpdate()
    {
        if (!alvo) return;

        Vector3 posicaoDesejada = alvo.position + alvo.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, posicaoDesejada, Time.deltaTime * suavidade);

        
        Quaternion rotacaoDesejada = Quaternion.LookRotation(alvo.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoDesejada, Time.deltaTime * suavidade);
    }
}
