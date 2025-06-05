using UnityEngine;

public class LinhaAtivadora : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform[] pontos; 

    void Start()
    {
        lineRenderer.positionCount = pontos.Length;

        for (int i = 0; i < pontos.Length; i++)
        {
            lineRenderer.SetPosition(i, pontos[i].position);
        }

        lineRenderer.startColor = Color.white;                  // CODIGO NAO TA FUNCIONANDO NAO USAR
        lineRenderer.endColor = Color.white;   

        lineRenderer.enabled = false;
    }

    public void AtivarLinha()
    {
        lineRenderer.enabled = true;
    }

    public void DesativarLinha()
    {
        lineRenderer.enabled = false;
    }
}
