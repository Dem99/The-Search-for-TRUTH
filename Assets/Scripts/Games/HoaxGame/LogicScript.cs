using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text winText;
    public GameObject gameOverScreen;
    public NewspaperScript newspaperScript;

    [SerializeField]
    private Button quitButton;


    [ContextMenu("Increase Score")]
    public void addScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        if (score >= 10)
        {
            newspaperScript.playerDied = true;
            gameOverScreen.SetActive(false);
            winText.text = "Congratulations, you won!";
            winText.gameObject.SetActive(true);
            GameManager.Instance.HasWonHoaxNews = true;
            quitButton.gameObject.SetActive(true);
            quitButton.onClick.AddListener(quitGame);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void gameOver()
    {
        if(!GameManager.Instance.HasWonHoaxNews)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void winGame()
    {
        newspaperScript.playerDied = true;
        gameOverScreen.SetActive(false);
        winText.text = "Congratulations, you won!";
        winText.gameObject.SetActive(true);
        GameManager.Instance.HasWonHoaxNews = true;
        quitButton.gameObject.SetActive(true);
        quitButton.onClick.AddListener(quitGame);
    }

    public void quitGame()
    {
        SceneManager.LoadScene("World");
    }
}
