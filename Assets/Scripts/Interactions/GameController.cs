using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameState {FreeRoam, Dialog, Battle}
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    public GameState state;

    [SerializeField] public List<Task> tasks;
    [SerializeField] public GameObject tasksBox;
    [SerializeField] public Text tasksText;

    private void Start()
    {
        tasks = new List<Task>
        {
        };

        if (tasks.Count > 0)
        {
            tasks[0].isVisible = true;
        }

        UpdateTasksDisplay();

        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if(state == GameState.Dialog)
                state = GameState.FreeRoam;
        };
    }

    private void Update()
    {
        if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();

        } else if (state == GameState.Battle)
        {

        } else if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
    }

    public void CompleteTask(int taskIndex)
    {
        if (taskIndex >= 0 && taskIndex < tasks.Count)
        {
            tasks[taskIndex].isCompleted = true; 
            ShowNextTask(); 
        }
    }

    public void ShowNextTask()
    {
        // Make all tasks invisible first
        tasks.ForEach(task => task.isVisible = false);

        // Find the first uncompleted task and make it visible
        Task nextTask = tasks.Find(task => !task.isCompleted);
        if (nextTask != null)
        {
            nextTask.isVisible = true;
        }
        UpdateTasksDisplay();
    }


    public bool IsTaskCompleted(int taskIndex)
    {
        if (taskIndex >= 0 && taskIndex < tasks.Count)
        {
            return tasks[taskIndex].isCompleted;
        }
        return false;
    }

    private void UpdateTasksDisplay()
    {
        tasksText.text = string.Empty;
        // Find the first task that is not completed and set it to visible
        Task nextTask = tasks.Find(task => !task.isCompleted);
        if (nextTask != null)
        {
            tasksText.text = nextTask.description + "\n";
        }

        // Update the visibility of the task box
        tasksBox.SetActive(!string.IsNullOrEmpty(tasksText.text));
    }

}
