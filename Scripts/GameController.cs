using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int totalScore = 0; // Variável para rastrear o total de pontos
    public Text scoreText; // Referência ao objeto de texto que mostra a contagem de pontos
    public GameObject endGameText; // Referência ao objeto de texto que mostra a mensagem de fim de jogo
    void Start()
    {
        AtualizarTextoPontuacao();
    }

    // Método para atualizar o texto de contagem de pontos
    public void AtualizarTextoPontuacao()
    {
        scoreText.text = "Pontos: " + totalScore.ToString() + "/13";
    }

    // Método para verificar se o número total de pontos atingiu o limite
    private void VerificarFimDoJogo()
    {
        if (totalScore >= 13)
        {
            // Se o número total de pontos for maior ou igual a 13, mostra a mensagem de fim de jogo
            endGameText.SetActive(true);
            // Pausa o jogo
            Time.timeScale = 0f;
        }
    }

    // Método para adicionar pontos
    public void AdicionarPontos(int pontos)
    {
        totalScore += pontos; // Adiciona os pontos ao total
        // Verifica se o jogo deve ser encerrado
        VerificarFimDoJogo();
        // Atualiza o texto de contagem de pontos
        AtualizarTextoPontuacao();
    }
}
