using UnityEngine;
using UnityEngine;

public class CaminhoRenderer : MonoBehaviour
{
    public Transform[] pontosDoCaminho; // arraste aqui os pontos no inspetor
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = pontosDoCaminho.Length;

        for (int i = 0; i < pontosDoCaminho.Length; i++)
        {
            line.SetPosition(i, pontosDoCaminho[i].position);
        }

        // Estilo opcional
        line.startWidth = 0.3f;
        line.endWidth = 0.3f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.cyan;
        line.endColor = Color.cyan;
    }
}
