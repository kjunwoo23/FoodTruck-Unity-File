using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager2 : MonoBehaviour
{
    public static SoundManager2 instance;
    public AudioSource ClickSound;
    public AudioSource ThemeSound;
    public void PlayClickSound()
    {
        ClickSound.Play();
    } 
    private void Awake()
    {
        instance = this;
        if (InputName.instance != null)
        {
            ThemeSound.volume = InputName.instance.bgmVolume;
            ClickSound.volume = InputName.instance.clickVolume;
            Destroy(InputName.instance.gameObject);
        }
        else
        {
            ThemeSound.volume = ClickSound.volume = 0.5f;
        }
    }
    private void Update()
    {
    }
}


