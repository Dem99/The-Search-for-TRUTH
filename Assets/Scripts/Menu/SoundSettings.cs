using System.Collections;

using System.Collections.Generic;

using TMPro;

using UnityEngine;

using UnityEngine.Audio;

using UnityEngine.UI;

public class SoundSettings : MonoBehaviour

{

    [SerializeField] private AudioMixer mixer;

    [SerializeField] private Slider musicSlider;

    [SerializeField] private Slider volumeSlider;

    [SerializeField] private TextMeshProUGUI musicValueText;

    [SerializeField] private TextMeshProUGUI volumeValueText;

    private void Start()

    {

        SetInitialVolume("music", musicSlider, musicValueText);

        SetInitialVolume("master", volumeSlider, volumeValueText);

    }

    public void SetMusicVolume()

    {

        SetVolume("music", musicSlider, musicValueText);

    }

    public void SetMasterVolume()

    {

        SetVolume("master", volumeSlider, volumeValueText);

    }

    private void SetInitialVolume(string parameterName, Slider slider, TextMeshProUGUI valueText)

    {

        float initialVolume;

        mixer.GetFloat(parameterName, out initialVolume);

        valueText.text = Mathf.RoundToInt(initialVolume).ToString();

        slider.value = 100f; // ���������� �������� �������� �� ����������� (100)

        SetVolume(parameterName, slider, valueText); // ��������� SetVolume ��� ���������� ������� � �����

    }

    private void SetVolume(string parameterName, Slider slider, TextMeshProUGUI valueText)

    {

        float volume = slider.value * 0.8f - 80f;

        valueText.text = Mathf.RoundToInt(slider.value).ToString();

        mixer.SetFloat(parameterName, volume);

    }

}