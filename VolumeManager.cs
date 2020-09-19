using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public static VolumeManager instance;
    public Slider bgmSlider;
    public Slider clickSlider;
    void Start()
    {
        instance = this;
        VolumeManager.instance.bgmSlider.value = SoundManager2.instance.ThemeSound.volume;
        VolumeManager.instance.clickSlider.value = SoundManager2.instance.ClickSound.volume;
    }
    public void OnValueChangedClickSound()
    {
        SoundManager2.instance.ClickSound.volume = clickSlider.value;
        EffectManager.instance.EffectSoundSliderManager();
    }
    public void OnValueChangedBgmSound()
    {
        SoundManager2.instance.ThemeSound.volume = bgmSlider.value;
        EffectManager.instance.BgsVolumeSliderManager();
    }
}
