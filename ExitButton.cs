using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        SoundManager.instance.StartClickSound();
        Stop();
    }
    private void Stop()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
