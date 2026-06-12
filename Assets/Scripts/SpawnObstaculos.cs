using UnityEngine;
using System.Collections;

public class SpawnObstaculos : MonoBehaviour
{
    public GameObject prefabObstaculo;
    public float distanciaSpawn = 25f;
    public float larguraPista = 2f;

    private float intervaloSpawn = 2f;

    void Start()
    {
        StartCoroutine(LoopSpawn());
    }

    IEnumerator LoopSpawn()
    {
        while (true)
        {
            if (GameManager.jogoAtivo)
            {
                SpawnarObstaculo();
                intervaloSpawn = Mathf.Max(0.5f, 2f - (GameManager.score / 50f));
            }
            yield return new WaitForSeconds(intervaloSpawn);
        }
    }

    void SpawnarObstaculo()
    {
        float posX = Random.Range(-larguraPista, larguraPista);
        Vector3 posicao = new Vector3(posX, 0.75f, distanciaSpawn);
        GameObject obs = Instantiate(prefabObstaculo, posicao, Quaternion.identity);

        MovimentoObstaculo mov = obs.GetComponent<MovimentoObstaculo>();
        if (mov != null)
            mov.velocidade = GameManager.velocidadeAtual;
    }
}