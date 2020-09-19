using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sounds
{
    public string soundName;
    public AudioClip clip;
    public AudioSource source;
}
public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;
    public AudioSource bgs;
    [Header("배경음 등록")]
    [SerializeField]
    public Bgms[] bgsSounds;

    [Header("효과음 등록")]
    [SerializeField]
    public Sounds[] effectSounds;

    void Start()
    {
        instance = this;
        //bgm이랑 bgs랑 다름!!!

        bgs.clip = this.bgsSounds[2].clip;
        if (SoundManager2.instance != null)
        {
            bgs.volume = SoundManager2.instance.ThemeSound.volume;
        }
        else
        {
            bgs.volume = 0.5f;
        }
        bgs.Play();

        for (int i = 0; i < effectSounds.Length; i++)
        {
            effectSounds[i].source = gameObject.AddComponent<AudioSource>();
            effectSounds[i].source.clip = effectSounds[i].clip;
            effectSounds[i].source.loop = false;
            if (SoundManager2.instance != null)
            {
                effectSounds[i].source.volume = SoundManager2.instance.ClickSound.volume;
                if (i == 1)
                    this.effectSounds[i].source.volume = SoundManager2.instance.ClickSound.volume * 0.5f;
            }
            else
            {
                effectSounds[i].source.volume = 0.5f;
                if (i == 1)
                    this.effectSounds[i].source.volume = 0.25f;
            }
            
        }
    }
    public void BgsVolumeSliderManager()
    {
        //배경음 볼륨 조절 (일단 BGM이랑 같이 한번에 조절하게 만듬)
        bgs.volume = SoundManager2.instance.ThemeSound.volume;
        if (bgs.clip == bgsSounds[3].clip)
            bgs.volume = SoundManager2.instance.ThemeSound.volume * 0.5f;
    }
    public void EffectSoundSliderManager()
    {
        //효과음 볼륨 조절 (CLICK이랑 같이 조절하게 만듬)
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if (i == 1)
                effectSounds[i].source.volume = SoundManager2.instance.ClickSound.volume / 2.0f;
            else
                effectSounds[i].source.volume = SoundManager2.instance.ClickSound.volume;
        }
    }
}
