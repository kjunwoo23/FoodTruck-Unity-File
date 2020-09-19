using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour
{
    public string userName;
    public static InputName instance;
    public InputField nameField;
    public AudioSource click;
    public float bgmVolume;
    public float clickVolume;
    public GameObject load;
    private void Awake()
    {
        instance = this;
        click.volume = SoundManager.instance.ClickSound.volume;
        clickVolume = SoundManager.instance.volumeClick;
        bgmVolume = SoundManager.instance.volumeBgm;
        Destroy(SoundManager.instance.gameObject);
    }
    private void Start()
    {
        if (SoundManager.instance != null)
            click.volume = SoundManager.instance.volumeClick;
        else click.volume = 0.5f;
    }
    public void SetName()
    {
        click.Play();
        instance.userName = nameField.text;
    }
    public void NextScene()
    {
        load.SetActive(true);
        click.Play();
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        DontDestroyOnLoad(instance.gameObject);
        yield return null;
        AsyncOperation Load = SceneManager.LoadSceneAsync("MainScene");
        Load.allowSceneActivation = false;
        while (!Load.isDone)
        {
            if (Load.progress >= 0.9f)
            {
                Load.allowSceneActivation = true;
                break;
            }
        }
        Load.allowSceneActivation = true;
    }
}