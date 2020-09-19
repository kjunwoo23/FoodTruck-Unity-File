using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingExit : MonoBehaviour
{
    public void OnClick()
    {
        SoundManager.instance.StartClickSound();
        //SoundManager.instance.Setting = false;
        SoundManager.instance.SettingMenu.SetActive(false);
    }
}
