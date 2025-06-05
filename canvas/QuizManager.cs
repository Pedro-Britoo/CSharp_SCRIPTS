using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class QuizManager : MonoBehaviour
{
    [Header("Configura��es")]
    public GameObject quizCanvas;              // Refer�ncia ao Canvas do quiz
    public TMP_Text textoPergunta;             // Texto onde ser� exibida a pergunta
    public Button botaoVerdadeiro;             // Bot�o para a resposta Verdadeira
    public Button botaoFalso;                  // Bot�o para a resposta Falsa

    [Header("Feedback de Erro")]
    public GameObject painelErro;              // Painel ou texto para indicar "Resposta Errada"
    public Button botaoRetornar;               // Bot�o para voltar e tentar responder novamente

    [Header("Perguntas")]
    public Pergunta[] perguntas;               // Array contendo todas as perguntas

    //canva de parab�ns
    public GameObject painelParabens;

    // Controle interno do quiz
    private int perguntaAtual = 0;             // �ndice da pergunta atual
    private int totalRespondidas = 0;          // Contador de perguntas j� respondidas
    private bool primeiraFase = true;          // Indica se est� na primeira fase (primeiras 5 perguntas)

    void Start()
    {
        // Esconde o quiz e o painel de erro ao iniciar
        quizCanvas.SetActive(false);
        painelErro.SetActive(false);
        painelParabens.SetActive(false);

        // Define as a��es dos bot�es de verdadeiro e falso
        botaoVerdadeiro.onClick.AddListener(() => Responder(true));
        botaoFalso.onClick.AddListener(() => Responder(false));

        // Define a a��o do bot�o de retornar ap�s erro
        botaoRetornar.onClick.AddListener(VoltarPergunta);
    }

    // M�todo p�blico para ativar o quiz
    public void AtivarQuiz()
    {
        quizCanvas.SetActive(true);
        MostrarPergunta();
    }

    // Exibe a pergunta atual na tela
    void MostrarPergunta()
    {
        painelErro.SetActive(false);  // Esconde o painel de erro se estiver ativo
        textoPergunta.text = perguntas[perguntaAtual].texto;  // Atualiza o texto da pergunta

        // Ativa os bot�es de resposta
        botaoVerdadeiro.gameObject.SetActive(true);
        botaoFalso.gameObject.SetActive(true);
    }

    // Verifica a resposta do jogador
    void Responder(bool respostaJogador)
    {
        if (respostaJogador == perguntas[perguntaAtual].respostaCorreta)
        {
            // Resposta correta
            perguntaAtual++;
            totalRespondidas++;

            // Verifica se terminou a fase
            if ((primeiraFase && totalRespondidas >= 5) || (!primeiraFase && totalRespondidas >= 10))
            {
                quizCanvas.SetActive(false);  // Esconde o quiz
                painelParabens.SetActive(true);
                StartCoroutine(EsperarDesativar());

                if (primeiraFase)
                {
                    // Concluiu a primeira fase, prepara para a segunda
                    primeiraFase = false;
                    Debug.Log("Primeira fase conclu�da. Jogo continua.");
                }
                else
                {
                    // Concluiu o quiz completo
                    Debug.Log("Quiz finalizado.");
                }
            }
            else
            {
                // Continua para a pr�xima pergunta
                MostrarPergunta();
            }
        }
        else
        {
            // Resposta errada, mostra o painel de erro
            MostrarErro();
        }
    }

    // Exibe o painel de erro e esconde os bot�es de resposta
    void MostrarErro()
    {
        painelErro.SetActive(true);
        botaoVerdadeiro.gameObject.SetActive(false);
        botaoFalso.gameObject.SetActive(false);
    }

    // Permite voltar e tentar novamente ap�s erro
    void VoltarPergunta()
    {
        MostrarPergunta();
    }

    // M�todo para iniciar o quiz (reset da primeira fase)
    public void MostrarQuiz()
    {
        quizCanvas.SetActive(true);
        perguntaAtual = 0;
        MostrarPergunta();
    }

    // M�todo para iniciar a segunda fase do quiz
    void IniciarSegundaFase()
    {
        primeiraFase = false;       // Marca que est� na segunda fase
        perguntaAtual = 5;          // Come�a da pergunta 6 (�ndice 5)
        totalRespondidas = 5;       // J� foram respondidas 5 perguntas
        quizCanvas.SetActive(true);
        MostrarPergunta();
    }

    // Teste manual com teclas Q e E
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MostrarQuiz();          // Inicia a primeira fase
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            IniciarSegundaFase();   // For�a a segunda fase
        }
    }

    private void DisableCanvas()
    {
        quizCanvas.SetActive(false);
        painelErro.SetActive(false);
        painelParabens.SetActive(false);
    }

    IEnumerator EsperarDesativar()
    {
        yield return new WaitForSeconds(3f);
        DisableCanvas();
    }
}


