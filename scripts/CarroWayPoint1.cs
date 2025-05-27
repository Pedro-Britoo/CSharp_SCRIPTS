using UnityEngine;

public class CarroWaypoint1 : MonoBehaviour
{
    public Transform[] waypoints;
    public float velocidade = 5f;
    public float distanciaMinima = 0.1f;

    private int indiceAtual = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform alvo = waypoints[indiceAtual];


        transform.position = Vector3.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);


        Vector3 direcao = (alvo.position - transform.position);
        direcao.y = 0;
        direcao.Normalize();


        if (direcao != Vector3.zero)
        {
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
            rotacaoAlvo *= Quaternion.Euler(-90f, -90f, 90f);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, Time.deltaTime * 5f);
        }

        if (Vector3.Distance(transform.position, alvo.position) < distanciaMinima)
        {
            indiceAtual = (indiceAtual + 1) % waypoints.Length;
        }
    }
}
