using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroyOnLoadSettings : MonoBehaviour
{
    private static DontDestroyOnLoadSettings dontDestroyOnLoadSettings;
    public static ManagerG4 manager;
    public Text sliderPercentage;
    public Text sliderSFX;
    public Text sliderMusic;
    public GameObject settingCanvas;
    private void Awake()
    {
        manager = FindObjectOfType<ManagerG4>();
        if (dontDestroyOnLoadSettings == null)
        {
            dontDestroyOnLoadSettings = this;
            DontDestroyOnLoad(this);
            manager.SetInitialSettings();

        }
        if (dontDestroyOnLoadSettings != this)
        {
            Destroy(this.gameObject);

        }
    }
    private void Start()
    {
        manager = FindObjectOfType<ManagerG4>();

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
        manager.SettingsActiveOrNotSettings();
    }
    public void SettingPer(float per)
    {
        manager.SettingsPercentage(per);
    }
    public void SettingsQuestionsCount(string count)
    {
        manager.SettingsQuestionsCount(count);
    }
    public void SettingsTimeLimit(string count)
    {
        manager.SettingsTimeLimit(count);
    }
    public void SettingSoundMusic(float count)
    {
        manager.SettingsSoundMusic(count);
    }
    public void SettingsSFX(float count)
    {
        manager.SettingsSFX(count);
    }
    public void GetDontDestroySettings()
    {
        //manager.requirementPercentage = 
    }
}
