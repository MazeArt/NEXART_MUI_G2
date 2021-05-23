using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsG4 : MonoBehaviour
{
    private static SettingsG4 dontDestroyOnLoadSettings;
    public ManagerG4 manager;


    public Text textSliderPercentage;
    public Text textSliderMusic;
    public Text textSliderSFX;
    public GameObject settingsCanvas;
    public Slider sliderPercentage, sliderMusica, sliderSFX;
    public InputField inputQuestionCount, inputTimeLimit;

    private void Awake()
    {
        manager = FindObjectOfType<ManagerG4>();
        if (dontDestroyOnLoadSettings == null)
        {
            dontDestroyOnLoadSettings = this;
            DontDestroyOnLoad(this);
            SetInitialSettings();

        }
        if (dontDestroyOnLoadSettings != this)
        {
            Destroy(this.gameObject);

        }
    }
    public void StartGameButton()
    {
        manager.GameIntroduction();
    }
    public void PlaySFX(AudioClip audioClip)
    {
        manager.PlaySFXSound(audioClip);
    }
    public void SetActiveOrNotSettings()
    {
        if (settingsCanvas.active == true)
        {
            settingsCanvas.SetActive(false);
        }
        else
        {
            settingsCanvas.SetActive(true);
        }
    }
    public void SettingPer(float percentage)
    {
        float porc = Mathf.Round(percentage);
        manager.requirementPercentage = percentage;

        textSliderPercentage.text = porc.ToString() + '%';
    }
    public void SettingsQuestionsCount(string count)
    {
        int.TryParse(count, out manager.questionsInGameCount);
    }
    public void SettingsTimeLimit(string count)
    {
        int.TryParse(count, out manager.timeLimit);
    }
    public void SettingsSoundMusic(float count)
    {
        manager.audioSourceMusic.volume = count;
        float text = Mathf.Round(manager.audioSourceMusic.volume * 100);
        textSliderMusic.text = text.ToString();
    }
    public void SettingsSFX(float count)
    {
        manager.audioSourceSFX.volume = count;
        float text = Mathf.Round(manager.audioSourceSFX.volume * 100);
        textSliderSFX.text = text.ToString();
    }
    public void GetStartSettings()
    {
        settingsCanvas.SetActive(false);
        manager.requirementPercentage = sliderPercentage.value;
        manager.audioSourceMusic.volume = sliderMusica.value;
        manager.audioSourceSFX.volume = sliderSFX.value;
        int.TryParse(inputQuestionCount.text, out manager.questionsInGameCount);
        int.TryParse(inputTimeLimit.text, out manager.timeLimit);

    }
    public void SetInitialSettings()
    { 
        SettingPer(manager.requirementPercentage);
        inputQuestionCount.text = manager.questionsInGameCount.ToString();
        inputTimeLimit.text = manager.timeLimit.ToString();
        SettingsSoundMusic(manager.audioSourceMusic.volume);
        SettingsSFX(manager.audioSourceSFX.volume);
        sliderMusica.value = manager.audioSourceMusic.volume;
        sliderSFX.value = manager.audioSourceSFX.volume;
        sliderPercentage.value = manager.requirementPercentage;
    }
}
