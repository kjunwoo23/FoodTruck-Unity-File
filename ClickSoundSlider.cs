using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSoundSlider : MonoBehaviour
{
    public Slider slider;
    private void Awake()
    {
        if (SoundManager.instance == null || SoundManager.instance.ClickSound == null)
            slider.value = 0.5f;
        else slider.value = SoundManager.instance.ClickSound.volume;

    }
    void Update()
    {
        SoundManager.instance.ClickSound.volume = slider.value;
    }
}
