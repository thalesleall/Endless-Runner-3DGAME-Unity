using UnityEngine;

public class PistaInfinita : MonoBehaviour
{
    public GameObject prefabChunk;
    public int quantidadeInicial = 5;
    public float tamanhoChunk = 20f;

    private float zUltimoChunk = 0f;
    private float zLimiteDestrucao = -30f;

    void Start()
    {
        for (int i = 0; i < quantidadeInicial; i++)
        {
            SpawnarChunk();
        }
    }

    void Update()
    {
        if (!GameManager.jogoAtivo) return;

        // Spawna novo chunk quando o último estiver próximo
        if (zUltimoChunk - Camera.main.transform.position.z < 60f)
            SpawnarChunk();

        // Destroi chunks que ficaram pra trás
        foreach (var chunk in FindObjectsByType<ChunkPistaTag>(FindObjectsSortMode.None))
        {
            if (chunk.transform.position.z < zLimiteDestrucao)
                Destroy(chunk.gameObject);
        }
    }

    void SpawnarChunk()
    {
        Vector3 pos = new Vector3(0f, 0f, zUltimoChunk);
        GameObject chunk = Instantiate(prefabChunk, pos, Quaternion.identity);
        chunk.AddComponent<ChunkPistaTag>();
        zUltimoChunk += tamanhoChunk;
    }
}

// Classe marcadora para identificar os chunks
public class ChunkPistaTag : MonoBehaviour { }