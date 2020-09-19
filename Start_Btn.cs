using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_Btn : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        slider.gameObject.SetActive(false);
    }
    private void Update()
    {
        
    }
    public void OnClick()
    {
        SoundManager.instance.volumeBgm = SoundManager.instance.ThemeSound.volume;
        SoundManager.instance.volumeClick = SoundManager.instance.ClickSound.volume;
        SoundManager.instance.ClickSound.Play();
        SoundManager.instance.ThemeSound.Stop();
        StartCoroutine(LoadStartScene());
    }
    IEnumerator LoadStartScene()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        slider.gameObject.SetActive(true);
        AsyncOperation Load = SceneManager.LoadSceneAsync("Tutorial");
        Load.allowSceneActivation = false;
        while (!Load.isDone)
        {
            if (Load.progress >= 0.9f)
            {
                slider.value = 1.0f;
                Load.allowSceneActivation = true;
                break;
            }
            slider.value = Load.progress;
        }
        Load.allowSceneActivation = true;
    }
}
