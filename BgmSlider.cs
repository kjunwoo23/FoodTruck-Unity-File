using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSlider : MonoBehaviour
{
    public Slider slider;
    private void Awake()
    {
        if (SoundManager.instance == null || SoundManager.instance.ThemeSound == null)
            slider.value = 0.5f;
        else slider.value = SoundManager.instance.ThemeSound.volume;
    }
    void Update()
    {
        SoundManager.instance.ThemeSound.volume = slider.value;
    }
}
