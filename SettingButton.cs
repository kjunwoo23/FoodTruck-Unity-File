using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    public void OnClick()
    {
        SoundManager.instance.StartClickSound();
        //SoundManager.instance.Setting = true;
        SoundManager.instance.SettingMenu.SetActive(true);
    }
}
