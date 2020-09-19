using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;

    public GameObject Setting;
    public GameObject Close;
    public GameObject Sound;
    public GameObject Exit;

    //설정 버튼을 누르는 경우
    public void OnClickSettingButton()
    {
        SoundManager2.instance.PlayClickSound();
        Setting.SetActive(false);
        Close.SetActive(true);
        Sound.SetActive(true);
        Exit.SetActive(true);
    }

    //설정 버튼 메뉴를 닫는 경우
    public void OnClickCloseButton()
    {
        SoundManager2.instance.PlayClickSound();
        Close.SetActive(false);
        Sound.SetActive(false);
        Exit.SetActive(false);
        Setting.SetActive(true);
    }

    // 소리 설정 버튼을 누른 경우
    public void OnClickSoundButton()
    {
        SoundManager2.instance.PlayClickSound();
        //SoundManager.instance.Setting = true;
        GameManager.instance.SettingMenu.SetActive(true);
    }

    //나가기(종료) 버튼을 누른 경우
    public void OnClickExitButton()
    {
        SoundManager2.instance.PlayClickSound();
        Stop();
    }

    private void Stop()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    //사운드 설정창을 닫는 경우
    public void OnClickSettingExitButton()
    {
        SoundManager2.instance.PlayClickSound();
        //SoundManager.instance.Setting = false;
        GameManager.instance.SettingMenu.SetActive(false);
    }

    // 테스트 버튼을 누르는 경우
    public void OnClickTest()
    {
        SoundManager2.instance.PlayClickSound();
    }

    //소리 설정 메뉴를 닫는 경우
    public void OnClickExitSetting()
    {
        SoundManager2.instance.PlayClickSound();
        GameManager.instance.SettingMenu.SetActive(false);
    }

}
