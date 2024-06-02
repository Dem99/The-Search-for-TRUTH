using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCController : MonoBehaviour, Interactable
{
    [SerializeField] private Transform playerTransform;

    public void Interact()
    {
        var gameController = FindObjectOfType<GameController>();
        if (gameController != null && GameManager.Instance.HasTalkToNpc1)
        {
            GameManager.Instance.PlayerPosition = playerTransform.position;
            GameManager.Instance.PlayerRotation = playerTransform.rotation;
            GameManager.Instance.ShouldReturnToMainScene = true;
            SceneManager.LoadScene("FakeNews");
        }
    }
}

