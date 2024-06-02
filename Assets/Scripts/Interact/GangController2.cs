using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GangController2 : MonoBehaviour, Interactable
{
    [SerializeField] private Transform playerTransform;
    public void Interact()
    {
        var gameController = FindObjectOfType<GameController>();
        if (gameController != null && GameManager.Instance.HasTalkToGang3)
        {
            GameManager.Instance.PlayerPosition = playerTransform.position;
            GameManager.Instance.PlayerRotation = playerTransform.rotation;
            GameManager.Instance.ShouldReturnToMainScene = true;
            SceneManager.LoadScene("StartPuzzleGame");
        }
        else
        {
            Debug.Log("You need to talk to the NPC first!");
        }
    }
}
