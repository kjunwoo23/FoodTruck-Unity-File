using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    public static SelectMenu instance;
    private void Awake()
    {
        instance = this;
    }
    //부모 메뉴 선택
    public void OnClickMainButton()
    {
        SoundManager2.instance.PlayClickSound();
        GameManager.instance.ActiveMenu("Ingredient");
    }
    public void OnClickSideMenuButton()
    {
        SoundManager2.instance.PlayClickSound();
        GameManager.instance.ActiveMenu("SideMenu");
    }
    public void OnClickBeverageButton()
    {
        SoundManager2.instance.PlayClickSound();
        GameManager.instance.ActiveMenu("Beverage");
    }
    // 메인메뉴의 세부 메뉴
    public void OnClickPattyButton()
    {
        SoundManager2.instance.PlayClickSound();
        GameManager.instance.ActiveMenu("Patty");
    }
    public void OnClickBreadButton()
    {
        SoundManager2.instance.PlayClickSound();
        GameManager.instance.ActiveMenu("Bread");
    }
    public void OnClickVegetableButton()
    {
        SoundManager2.instance.PlayClickSound();
        GameManager.instance.ActiveMenu("Vegetable");
    }
    public void OnClickSourceButton()
    {
        SoundManager2.instance.PlayClickSound();
        GameManager.instance.ActiveMenu("Source");
    }
    
}
