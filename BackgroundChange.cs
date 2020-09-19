using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    public RawImage spring;
    public RawImage rain;
    public RawImage autumn;
    public RawImage festival;
    public RawImage winter;
    public RawImage depress;
    public RawImage depress2;
    public GameObject particle;
    public GameObject particleSnow;
    private void Start()
    {
        particle.SetActive(false);
        particleSnow.SetActive(false);
    }

    public RawImage screen;

    public AudioSource bgsSource;
    public AudioSource bgmSource;
    public EffectManager bgs;
    public BgmManager bgm;
    void Update()
    {
        if (StatManager.instance.date.GetData() <= 6)
        {
            if (bgmSource.clip != bgm.bgmSounds[0].clip)
            {
                screen.texture = spring.texture;
                bgsSource.clip = bgs.bgsSounds[0].clip;
                bgmSource.clip = bgm.bgmSounds[0].clip;
                bgsSource.Play();
                bgmSource.Play();
            }
        }

        else if (StatManager.instance.date.GetData() <= 7)
        {
            if (bgmSource.clip != bgm.bgmSounds[1].clip)
            {
                screen.texture = festival.texture;
                bgsSource.clip = bgs.bgsSounds[1].clip;
                bgmSource.clip = bgm.bgmSounds[1].clip;
                bgmSource.time = 28;
                bgsSource.Play();
                bgmSource.Play();
            }
        }
        else if (StatManager.instance.date.GetData() <= 8)
        {
            if (bgmSource.clip != bgm.bgmSounds[0].clip)
            {
                screen.texture = spring.texture;
                bgsSource.clip = bgs.bgsSounds[0].clip;
                bgmSource.clip = bgm.bgmSounds[0].clip;
                bgsSource.Play();
                bgmSource.Play();
            }
        }
        else if (StatManager.instance.date.GetData() <= 13)
        {
            if (bgmSource.clip != bgm.bgmSounds[4].clip)
            {
                particle.SetActive(true);
                screen.texture = depress.texture;
                bgsSource.clip = bgs.bgsSounds[3].clip;
                if (StatManager.instance.date.GetData() == 9)
                    bgsSource.volume *= 0.5f;
                bgmSource.clip = bgm.bgmSounds[4].clip;
                bgsSource.Play();
                if (StatManager.instance.date.GetData() != 9)
                    bgmSource.Play();
            }
        }
        else if (StatManager.instance.date.GetData() <= 15)
        {
            if (bgmSource.clip != bgm.bgmSounds[5].clip)
            {
                particle.SetActive(false);
                screen.texture = depress2.texture;
                bgsSource.Pause();
                bgmSource.clip = bgm.bgmSounds[5].clip;
                bgmSource.Play();
            }
        }
        else if (StatManager.instance.date.GetData() <= 18)
        {
            if (bgmSource.clip != bgm.bgmSounds[2].clip)
            {
                particle.SetActive(true);
                screen.texture = rain.texture;
                bgsSource.clip = bgs.bgsSounds[2].clip;
                bgmSource.clip = bgm.bgmSounds[2].clip;
                bgsSource.Play();
                bgmSource.Play();
            }
        }

        else if (StatManager.instance.date.GetData() <= 19)
        {
            if (bgmSource.clip != bgm.bgmSounds[8].clip)
            {
                particle.SetActive(false);
                screen.texture = autumn.texture;
                bgsSource.clip = bgs.bgsSounds[0].clip;
                if (StatManager.instance.date.GetData() == 19)
                {
                    bgsSource.volume *= 1.41421f;
                }
                bgmSource.clip = bgm.bgmSounds[8].clip;
                bgsSource.Play();
                bgmSource.Play();
            }
        }
        else if (StatManager.instance.date.GetData() <= 20)
        {
            if (bgmSource.clip != bgm.bgmSounds[1].clip)
            {
                screen.texture = festival.texture;
                bgsSource.clip = bgs.bgsSounds[1].clip;
                bgmSource.clip = bgm.bgmSounds[1].clip;
                bgmSource.time = 28;
                bgsSource.Play();
                bgmSource.Play();
            }
        }
        else if (StatManager.instance.date.GetData() <= 22)
        {
            if (bgmSource.clip != bgm.bgmSounds[8].clip)
            {
                screen.texture = autumn.texture;
                bgsSource.clip = bgs.bgsSounds[0].clip;
                bgmSource.clip = bgm.bgmSounds[8].clip;
                bgsSource.Play();
                bgmSource.Play();
            }
        }
        else if (StatManager.instance.date.GetData() <= 24)
        {
            if (bgmSource.clip != bgm.bgmSounds[8].clip)
            {
                particleSnow.SetActive(true);
                screen.texture = winter.texture;
                bgsSource.clip = bgs.bgsSounds[0].clip;
                bgmSource.clip = bgm.bgmSounds[8].clip;
                bgsSource.Play();
                bgmSource.Play();
            }
        }
        else if (StatManager.instance.date.GetData() <= 26)
        {
            if (bgmSource.clip != bgm.bgmSounds[6].clip)
            {
                particleSnow.SetActive(true);
                screen.texture = winter.texture;
                bgsSource.Pause();
                bgmSource.clip = bgm.bgmSounds[6].clip;
                //bgmSource.Play();
            }
        }
    }
}
