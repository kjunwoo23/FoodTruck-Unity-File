using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKeyScript : MonoBehaviour
{
    public void IngredientHotkey() //재료 메뉴부분
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectMenu.instance.OnClickBreadButton();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectMenu.instance.OnClickPattyButton();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectMenu.instance.OnClickVegetableButton();

        if (Input.GetKeyDown(KeyCode.Alpha4))
            SelectMenu.instance.OnClickSourceButton();
    }

    public void MainHotKey() //메인 메뉴부분
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectMenu.instance.OnClickMainButton();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectMenu.instance.OnClickSideMenuButton();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectMenu.instance.OnClickBeverageButton();
    }

    public void BreadHoyKey() // 빵을 추가하는 부분
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AddBread.instance.OnClickHoneyOatButton();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            AddBread.instance.OnClickOregano();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            AddBread.instance.OnClickFlat();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            AddBread.instance.OnClickWhite();
        if (Input.GetKeyDown(KeyCode.Alpha5))
            AddBread.instance.OnClickWit();
        if (Input.GetKeyDown(KeyCode.Alpha6))
            AddBread.instance.OnClickSesame();
    }

    public void PattyHotKey() // 패티를 추가하는 부분
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AddPatty.instance.OnClickBeefButton();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            AddPatty.instance.OnClickPorkButton();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            AddPatty.instance.OnClickChickenButton();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            AddPatty.instance.OnClickTunaButton();
        if (Input.GetKeyDown(KeyCode.Alpha5))
            AddPatty.instance.OnClickEggButton();
        if (Input.GetKeyDown(KeyCode.Alpha6))
            AddPatty.instance.OnClickCheeseButton();
    }

    public void VegetableHotKey() // 야채를 추가하는 부분
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AddVegetable.instance.OnClickPotato();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            AddVegetable.instance.OnClickLettuce();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            AddVegetable.instance.OnClickTomato();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            AddVegetable.instance.OnClickPickle();
        if (Input.GetKeyDown(KeyCode.Alpha5))
            AddVegetable.instance.OnClickCucumber();
        if (Input.GetKeyDown(KeyCode.Alpha6))
            AddVegetable.instance.OnClickPepper();
    }

    void SourceHotKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AddSource.instance.OnClickMayo();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            AddSource.instance.OnClickKetchup();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            AddSource.instance.OnClickWrench();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            AddSource.instance.OnClickMustard();
        if (Input.GetKeyDown(KeyCode.Alpha5))
            AddSource.instance.OnClickHotchili();
        if (Input.GetKeyDown(KeyCode.Alpha6))
            AddSource.instance.OnClickSalt();
        if (Input.GetKeyDown(KeyCode.Alpha7))
            AddSource.instance.OnClickTeriyaki();
    }

    void SideMenuHotKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AddSideMenu.instance.OnClickFriedPotato();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            AddSideMenu.instance.OnClickSoup();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            AddSideMenu.instance.OnClickCookie();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            AddSideMenu.instance.OnClickNugget();
    }

    void BeverageHotKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AddBeverage.instance.OnClickCoffee();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            AddBeverage.instance.OnClickCola();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            AddBeverage.instance.OnClickCider();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            AddBeverage.instance.OnClickSmoothie();
    }

    void HotKeyFunc() // 함수 하나 내에서 이것들이 실행되도록 하지 않으면 하나의 키로 두개의 동작을 하는 경우가 생김. Update문에서 돌리기 때문에 생기는 문제임.
    {
        if (GameObject.Find("Patty") != null)
            PattyHotKey();
        if (GameObject.Find("Vegetable") != null)
            VegetableHotKey();
        if (GameObject.Find("Source") != null)
            SourceHotKey();
        if (GameObject.Find("Bread") != null)
            BreadHoyKey();
        if (GameObject.Find("Ingredient") != null)
            IngredientHotkey();
        if (GameObject.Find("SideMenu") != null)
            SideMenuHotKey();
        if (GameObject.Find("Beverage") != null)
            BeverageHotKey();
        if (GameObject.Find("Main") != null)
            MainHotKey();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
            BackButton.instance.OnClickBackButton();
        if (Input.GetKeyDown(KeyCode.Alpha0))
            UndoButton.instance.OnClickUndoButton();
        HotKeyFunc();

    }
}
