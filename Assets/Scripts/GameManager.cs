using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public static bool jogoAtivo = false;
    public static float score = 0f;

    public TextMeshProUGUI textoScore;
    public TextMeshProUGUI textoHighscore;
    public GameObject painelGameOver;
    public float velocidadeBase = 8f;

    public static float velocidadeAtual = 8f;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        score = 0f;
        jogoAtivo = true;
        velocidadeAtual = velocidadeBase;
        painelGameOver.SetActive(false);

        int highscore = PlayerPrefs.GetInt("highscore", 0);
        textoHighscore.text = "Recorde: " + highscore;
    }

    void Update()
    {
        if (!jogoAtivo) return;

        score += Time.deltaTime;
        velocidadeAtual = velocidadeBase + (score / 10f * 0.5f);

        if (textoScore != null)
            textoScore.text = "Score: " + Mathf.FloorToInt(score);
    }

    public void GameOver()
    {
        jogoAtivo = false;
        painelGameOver.SetActive(true);

        int scoreAtual = Mathf.FloorToInt(score);
        int highscore = PlayerPrefs.GetInt("highscore", 0);

        if (scoreAtual > highscore)
        {
            PlayerPrefs.SetInt("highscore", scoreAtual);
            textoHighscore.text = "Novo recorde: " + scoreAtual;
        }
        else
        {
            textoHighscore.text = "Recorde: " + highscore;
        }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IrParaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}