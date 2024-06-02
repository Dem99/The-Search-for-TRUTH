using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewsNinjaGameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 2.0f;
    private int score;
    public int lives;
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public bool isGameActive;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    private bool paused;
    [SerializeField] private Button exitButton;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        if (score >= 800)
        {
            GameManager.Instance.HasWonNewsNinjaGame = true;
            WinGame();
        }
    }

    public void UpdateLives(int livesToSub)
    {
        lives += livesToSub;
        livesText.text = "Lives: " + lives;

        if (lives == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void WinGame()
    {
        winText.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        UpdateLives(4);
        titleScreen.gameObject.SetActive(false);
    }

    public void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}