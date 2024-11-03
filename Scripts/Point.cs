using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int score = 1; // Valor dos pontos ao coletar o objeto
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController não encontrado na cena.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que colidiu é o jogador
        {
            Player player = other.GetComponent<Player>();
            if (player != null && gameController != null)
            {
                player.AdicionarMoeda();
                gameController.AdicionarPontos(score); // Atualiza a pontuação total
                gameController.AtualizarTextoPontuacao(); // Atualiza o texto da pontuação na UI
                Destroy(gameObject); // Destroi o objeto moeda
            }
        }
    }
}
