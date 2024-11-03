using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float jumpForce = 10f; // Força do pulo
    public float velocidadeMovimento;
    public SpriteRenderer spriteRenderer;
    public LayerMask groundLayer; // Camada que representa o chão
    public Transform groundCheck; // Ponto de verificação do chão
    public float groundCheckRadius = 0.2f; // Raio de verificação do chão
    public Transform pontoDeRespawn; // Ponto de respawn do personagem

    private bool isGrounded; // Variável para verificar se o personagem está no chão
    private bool hasJumped; // Variável para verificar se o personagem já pulou
    private int moedasColetadas;

    private Animator animator;
    private int correndoHash = Animator.StringToHash("correndo");
    private int pulandoHash = Animator.StringToHash("pulando");

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        // Verifica se o personagem está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Movimento horizontal
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocidade = rigidbody2D.velocity;
        velocidade.x = horizontal * velocidadeMovimento;
        rigidbody2D.velocity = velocidade;

        // Virar para a esquerda se a direção do movimento for menor que zero
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        // Virar para a direita se a direção do movimento for maior que zero
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Se estiver no chão e a tecla de espaço for pressionada, pula
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        animator.SetBool("correndo", horizontal != 0);
        animator.SetBool("pulando", !hasJumped);
    }

    void Jump()
    {
        // Verifica se o personagem já pulou
        if (!hasJumped)
        {
            // Aplica uma força para cima para realizar o pulo
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            hasJumped = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reseta a variável de pulo quando colide com o chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Se o jogador colidir com o objeto de queda, mova-o para o ponto de respawn
        if (other.CompareTag("vazio"))
        {
            Respawn(); // Certifique-se de que o método Respawn() é chamado corretamente
        }
    }

    // Método para mover o jogador para o ponto de respawn
    void Respawn()
    {
        transform.position = pontoDeRespawn.position;
        // Resetar o estado de pulo
        hasJumped = false; // Certifique-se de que a variável hasJumped é resetada para false
    }

    // Métodos para adicionar e obter moedas
    public void AdicionarMoeda()
    {
        moedasColetadas++;
    }

    public int ObterMoedasColetadas()
    {
        return moedasColetadas;
    }
}
