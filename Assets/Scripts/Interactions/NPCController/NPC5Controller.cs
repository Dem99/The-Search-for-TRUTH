using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC5Controller : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    [SerializeField] string nextSceneName = "Final";

    private void Start()
    {
        if (DialogManager.Instance != null)
        {
            DialogManager.Instance.OnHideDialog += OnDialogComplete;
        }
        else
        {
            Debug.LogError("DialogManager instance not found");
        }
    }

    private void OnDestroy()
    {
        if (DialogManager.Instance != null)
        {
            DialogManager.Instance.OnHideDialog -= OnDialogComplete;
        }
    }

    public void Interact()
    {
        if (DialogManager.Instance != null && GameManager.Instance.HasWonHoaxNews)
        {
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
        else
        {
            Debug.LogError("DialogManager instance not found");
        }
    }

    private void OnDialogComplete()
    {
        var gameController = FindObjectOfType<GameController>();
        if (gameController != null)
        {
            gameController.CompleteTask(0);
            gameController.ShowNextTask();
        }
        else
        {
            Debug.LogError("GameController instance not found");
        }
        StartCoroutine(TeleportToNextScene());

    }

    private IEnumerator TeleportToNextScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextSceneName);
    }
}
