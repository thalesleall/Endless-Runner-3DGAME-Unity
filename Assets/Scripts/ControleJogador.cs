using UnityEngine;
using UnityEngine.InputSystem;

public class ControleJogador : MonoBehaviour
{
    public float velocidadeLateral = 5f;
    public float forcaPulo = 7f;
    public float limiteLateral = 2.5f;

    private Rigidbody rb;
    private bool noChao = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GameManager.jogoAtivo) return;

        // Movimento lateral
        float horizontal = 0f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            horizontal = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            horizontal = 1f;

        Vector3 pos = transform.position;
        pos.x += horizontal * velocidadeLateral * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -limiteLateral, limiteLateral);
        transform.position = pos;

        // Pulo
        if (Keyboard.current.spaceKey.wasPressedThisFrame && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
            noChao = true;

        if (collision.gameObject.CompareTag("Obstaculo"))
            GameManager.instancia.GameOver();
    }
}