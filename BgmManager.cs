using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Bgms
{
    public string soundName;
    public AudioClip clip;
}
public class BgmManager : MonoBehaviour
{
    public static BgmManager instance;
    public AudioSource ThemeSound;
    [Header("배경음 등록")]
    [SerializeField]
    public Bgms[] bgmSounds;
    // Start is called before the first frame update
    void Awake()
    {
        ThemeSound.clip = this.bgmSounds[2].clip;
        ThemeSound.Play();
    }
}
