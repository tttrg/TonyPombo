using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float jumpForce = 5f; // Força do pulo
    private Rigidbody rb; // Referência ao Rigidbody
    private bool isGrounded; // Verificar se está no chão

    void Start()
    {
        // Pegando o componente Rigidbody do objeto
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }

        // Verificar se a tecla de espaço foi pressionada e o objeto está no chão
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpAction();
        }
    }

    // Função que aplica a força de pulo
    void JumpAction()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // Define como não estando no chão ao pular
    }

    // Detecta quando o objeto colide com o chão
    void OnCollisionEnter(Collision collision)
    {
        // Se o objeto colidir com algo, ele está no chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
