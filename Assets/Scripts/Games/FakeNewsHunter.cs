using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FakeNewsHunter : MonoBehaviour
{
    [SerializeField] private List<NewsItem> newsItems;
    [SerializeField] private TextMeshProUGUI titleText, authorText, dateText;
    [SerializeField] private Button trueButton, falseButton, playButton, exitButton, leaveButton;
    [SerializeField] private TextMeshProUGUI scoreText, ruleText, timerText;

    private int score = 0;
    private float timer = 60f;
    private bool isGameOver = false;
    private bool hasWon = false;
    private List<int> usedIndices = new List<int>();

    void Start()
    {
        DisplayRules();
        playButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(QuitGame);
    }

    void DisplayRules()
    {
        ruleText.text = "Game rules: Determine whether the news is true or false. You have one minute.";
        playButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        trueButton.gameObject.SetActive(false);
        falseButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        authorText.gameObject.SetActive(false);
        dateText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
    }

    void StartGame()
    {
        GameManager.Instance.Score = 0;
        ruleText.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        trueButton.gameObject.SetActive(true);
        falseButton.gameObject.SetActive(true);
        titleText.gameObject.SetActive(true);
        authorText.gameObject.SetActive(true);
        dateText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);

        trueButton.onClick.AddListener(() => CheckAnswer(true));
        falseButton.onClick.AddListener(() => CheckAnswer(false));

        timer = 60f;
        score = 0;
        hasWon = false;
        isGameOver = false;
        usedIndices.Clear();

        DisplayRandomNews();
    }

    void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime;
            UpdateTimer();

            if (timer <= 0)
            {
                EndGame();
            }
        }
    }

    void DisplayRandomNews()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, newsItems.Count);
        } while (usedIndices.Contains(randomIndex));

        usedIndices.Add(randomIndex);
        NewsItem currentNews = newsItems[randomIndex];

        titleText.text = currentNews.Title;
        authorText.text = currentNews.Author;
        dateText.text = currentNews.Date;

        LayoutRebuilder.ForceRebuildLayoutImmediate(titleText.rectTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(authorText.rectTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(dateText.rectTransform);
    }

    void CheckAnswer(bool isButtonTrue)
    {
        NewsItem currentNews = newsItems[Random.Range(0, newsItems.Count)];
        bool isAnswerCorrect = (currentNews.IsTrue == isButtonTrue);

        if (isAnswerCorrect)
        {
            GameManager.Instance.Score++; 
        }

        scoreText.text = "Score: " + GameManager.Instance.Score; 

        if (GameManager.Instance.Score >= 10) 
        {
            hasWon = true;
            GameManager.Instance.HasWonFakeNewsHunter = true;
            EndGame();
        }
        else
        {
            DisplayRandomNews();
        }
    }

    void EndGame()
    {
        isGameOver = true;

        trueButton.gameObject.SetActive(false);
        falseButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        authorText.gameObject.SetActive(false);
        dateText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);

        playButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

        if (hasWon)
        {
            ruleText.gameObject.SetActive(true);
            ruleText.text = "Congratulations, you won!";
            playButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            leaveButton.gameObject.SetActive(true);
            leaveButton.onClick.AddListener(QuitGame);
        }
        else
        {
            ruleText.gameObject.SetActive(true);
            ruleText.text = "Time's up! Your score: " + score + ". Would you like to play again?";
            playButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(StartGame);
            exitButton.onClick.AddListener(QuitGame);
        }
    }

    void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    void QuitGame()
    {
        SceneManager.LoadScene("Office");
    }
}