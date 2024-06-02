using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource musicSource;
    void Start()
    {
        musicSource.volume = GameManager.Instance.MusicVolume;
        musicSource.Play();                                             
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
