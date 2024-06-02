using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangScript1 : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

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
        if (DialogManager.Instance != null)
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
        GameManager.Instance.HasTalkToGang1 = true;
    }
}
