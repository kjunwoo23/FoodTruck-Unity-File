using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public static BackButton instance;
    private void Awake()
    {
        instance = this;
    }
    public void OnClickBackButton()
    {
        string activeName = "";
        SoundManager2.instance.PlayClickSound();
        foreach (GameObject tmp in GameManager.instance.Menus)
        {
            if (tmp.activeSelf == true)
                activeName = tmp.name;
        }
        
        if (activeName == "Ingredient" || activeName == "Beverage" || activeName == "SideMenu")
            GameManager.instance.ActiveMenu("Main");
        if (activeName == "Patty" || activeName == "Bread" || activeName == "Vegetable" || activeName == "Source")
            GameManager.instance.ActiveMenu("Ingredient");
            
    }
}
