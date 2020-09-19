using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverSceneButton : MonoBehaviour
{
    public void Restart()
    {
        StartCoroutine(Restart_());
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator Restart_()
    {
        yield return null;
        SceneManager.LoadScene("StartScene");
    }
}
