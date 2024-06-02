using UnityEngine;

public class NewsItem : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] private string author;
    [SerializeField] private string date;
    [SerializeField] private bool isTrue;

    public string Title { get { return title; } }
    public string Author { get { return author; } }
    public string Date { get { return date; } }
    public bool IsTrue { get { return isTrue; } }
}