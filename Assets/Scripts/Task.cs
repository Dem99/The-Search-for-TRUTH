[System.Serializable]
public class Task
{
    public string description; 
    public bool isCompleted;
    public bool isVisible;

    public Task(string description)
    {
        this.description = description;
        isCompleted = false;
        isVisible = false;
    }
}
