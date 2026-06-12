using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI textoHighscore;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        if (textoHighscore != null)
            textoHighscore.text = "Recorde: " + highscore;
    }

    public void Jogar()
    {
        SceneManager.LoadScene("Jogo");
    }
}