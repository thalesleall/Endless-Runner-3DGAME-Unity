using UnityEngine;

public class MovimentoObstaculo : MonoBehaviour
{
    public float velocidade = 8f;

    void Update()
    {
        if (!GameManager.jogoAtivo) return;

        transform.Translate(Vector3.back * velocidade * Time.deltaTime);

        if (transform.position.z < -10f)
            Destroy(gameObject);
    }
}