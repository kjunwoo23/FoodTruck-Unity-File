using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource ClickSound;
    public AudioSource ThemeSound;
    public GameObject SettingMenu;
    public float volumeClick;
    public float volumeBgm;
    public void StartClickSound()
    {
        ClickSound.Play();
    }
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "StartScene")
            ThemeSound.Stop();
        ThemeSound.Play();
        DontDestroyOnLoad(this);
        instance = this;
        ThemeSound.volume = ClickSound.volume = 0.5f;
        SettingMenu.SetActive(false);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "StartScene")
            ThemeSound.Stop();
    }
}
