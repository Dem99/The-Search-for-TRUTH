using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NPC2Controller : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    [SerializeField] string nextSceneName = "World";
    private bool isFirstDialogComplete = false;

    private void Start()
    {
        DialogManager.Instance.OnHideDialog += OnDialogComplete;
    }

    private void OnDestroy()
    {
        DialogManager.Instance.OnHideDialog -= OnDialogComplete;
    }

    public void Interact()
    {
        if (GameManager.Instance.HasWonFakeNewsHunter)
        {
            if (!isFirstDialogComplete)
            {
                StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
                isFirstDialogComplete = true; 
            }
            else
            {
                StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
            }
        }
    }

    private void OnDialogComplete()
    {
        if (isFirstDialogComplete)
        {
            var gameController = FindObjectOfType<GameController>();
            gameController.CompleteTask(2);
            StartCoroutine(TeleportToNextScene());
        }
    }

    private IEnumerator TeleportToNextScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextSceneName);
    }
}


