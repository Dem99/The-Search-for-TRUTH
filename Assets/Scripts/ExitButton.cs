using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void Exit()
    {
        SceneManager.LoadScene(sceneName);
    }

}
