using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopularBar : MonoBehaviour
{
    public GameObject Popular;
    public Sprite PopularTop;
    public Sprite PopularMiddle;
    public Sprite PopularBottom;

    private void Update()
    {

        int bar = (int)StatManager.instance.popular.GetData();

        gameObject.transform.localScale = new Vector3((int)StatManager.instance.popular.GetData() / 100.0f, 1, 1);
        if ( bar <= 0)
            SceneManager.LoadScene("GameoverScene");
        if (bar >= 70) Popular.GetComponent<Image>().sprite = PopularTop;
        else if (bar >= 30) Popular.GetComponent<Image>().sprite = PopularMiddle;
        else Popular.GetComponent<Image>().sprite = PopularBottom;
    }
}
