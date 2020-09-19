using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{
    public EffectManager effect;
    void Start()
    {
        effect = GameObject.Find("EffectManager").GetComponent<EffectManager>();
    }

    void CheckBeverage(GameManager.customer customer)
    {
        GameObject beverageParent = GameObject.Find("BeverageField");
        if (customer.me.beverage == "") // 주문이 없는데 주는 경우
        {
            if (beverageParent.transform.childCount > 0)
                customer.me.orderState = CustomerParent.OrderState.wrong;
        }
        else // 주문이 있는 경우
        {
            if (beverageParent.transform.childCount == 0 || // 주문은 있는데, 안 주는 경우
                !beverageParent.transform.GetChild(0).name.Contains(customer.me.beverage)) // 주문과 다른 음료를 주는 경우.
            {
                customer.me.orderState = CustomerParent.OrderState.wrong;
            }
        }
    }

    void CheckSideMenu(GameManager.customer customer)
    {
        GameObject sideParent1 = GameObject.Find("SideMenuField1");
        GameObject sideParent2 = GameObject.Find("SideMenuField2");

        if (customer.me.sideMenu1 == "") // 주문이 없는 경우.
        {
            if (sideParent1.transform.childCount > 0) // 주문이 없는데 주는 경우.
                customer.me.orderState = CustomerParent.OrderState.wrong;
        }
        else
        {
            if (sideParent1.transform.childCount == 0 || !sideParent1.transform.GetChild(0).name.Contains(customer.me.sideMenu1)) // 사이드 메뉴 1번이 틀린 경우.
            {
                customer.me.orderState = CustomerParent.OrderState.wrong;
            }

            if (customer.me.sideMenu2 == "") // 사이드 주문이 1개인 경우.
            {
                if (sideParent2.transform.childCount > 0) // 사이드 주문이 1개인데, 두개를 주는 경우.
                    customer.me.orderState = CustomerParent.OrderState.wrong;
            }
            else // 사이드 주문이 2개인 경우
            {
                if (sideParent2.transform.childCount == 0) // 사이드 주문이 2개인데 한개를 주는 경우.
                    customer.me.orderState = CustomerParent.OrderState.wrong;
                else if (!sideParent2.transform.GetChild(0).name.Contains(customer.me.sideMenu2)) // 사이드 주문 2번을 틀린 경우.
                    customer.me.orderState = CustomerParent.OrderState.wrong;
            }

            if (customer.me.sideMenu1 != "" && customer.me.sideMenu2 != "" && sideParent2.transform.childCount == 0 && sideParent1.transform.childCount == 0)
            {
                if (sideParent1.transform.GetChild(0).name.Contains(customer.me.sideMenu2) && sideParent2.transform.GetChild(0).name.Contains(customer.me.sideMenu1))
                    customer.me.orderState = CustomerParent.OrderState.yet;
            }
        }
    }

    void CheckSideMenus(GameManager.customer customer)
    {
        if (customer.me.orderState != CustomerParent.OrderState.wrong)
            CheckBeverage(customer);
        if (customer.me.orderState != CustomerParent.OrderState.wrong)
            CheckSideMenu(customer);
    }

    void CheckMainMenus(GameManager.customer customer)
    {
        GameObject parent = GameObject.Find("IngredientStack");

        if (parent.transform.childCount == 0)
            customer.me.orderState = CustomerParent.OrderState.wrong;

        switch (customer.me.type)
        {
            case ("BreadOnly"):
                {
                    for (int i = 0; i < parent.transform.childCount; i++)
                    {
                        if (!(parent.transform.GetChild(i).name.Contains("Flat") ||
                            parent.transform.GetChild(i).name.Contains("HoneyOat") ||
                            parent.transform.GetChild(i).name.Contains("Oregano") ||
                            parent.transform.GetChild(i).name.Contains("Sesame") ||
                            parent.transform.GetChild(i).name.Contains("White") ||
                            parent.transform.GetChild(i).name.Contains("Wit")))
                        {
                            customer.me.orderState = CustomerParent.OrderState.wrong;
                        }
                    }
                    break;
                }
            case ("Group"):
                {
                    if (parent.transform.childCount != customer.me.order.Length)
                        customer.me.orderState = CustomerParent.OrderState.wrong;
                    else
                    {
                        for (int i = 0; i < customer.me.order.Length; i++)
                        {
                            if (!parent.transform.GetChild(i).name.Contains(customer.me.order[i]))
                            {
                                customer.me.orderState = CustomerParent.OrderState.wrong;
                                break;
                            }
                            if (i == customer.me.order.Length - 1)
                            {
                                customer.me.groupStack--;
                            }
                        }
                    }
                    break;
                }
            default:
                {
                    if (parent.transform.childCount != customer.me.order.Length)
                        customer.me.orderState = CustomerParent.OrderState.wrong;
                    else
                    {
                        for (int i = 0; i < customer.me.order.Length; i++)
                        {
                            if (!parent.transform.GetChild(i).name.Contains(customer.me.order[i]))
                            {
                                customer.me.orderState = CustomerParent.OrderState.wrong;
                            }
                        }
                    }
                    break;
                }
        }
    }

    void SellMethod(GameManager.customer customer)
    {
        if (customer.me == null || customer.me.orderState != CustomerParent.OrderState.yet) // 손님이 없는 상태에서 누르는 경우, 
            return;
        
        CheckSideMenus(customer);
        if (customer.me.orderState == CustomerParent.OrderState.wrong)
            Debug.Log("!");
        if (customer.me.orderState != CustomerParent.OrderState.wrong)
            CheckMainMenus(customer);

        if (customer.me.groupStack != 0) //단체 손님인 경우
        {
            StartCoroutine(Destroy_Menus(null, GameObject.Find("IngredientStack")));
            if (customer.me.orderState != CustomerParent.OrderState.wrong)
            {
                effect.effectSounds[13].source.Play();
                customer.me.orderState = CustomerParent.OrderState.yet;
                return;
            }
        }

        if (customer.me.orderState == CustomerParent.OrderState.yet) // 주문을 받았기에 틀린 경우가 아니면 아직 yet이기에 proper로 전환
            customer.me.orderState = CustomerParent.OrderState.proper;

        if (customer.me.orderState == CustomerParent.OrderState.proper)
        {
            effect.effectSounds[6].source.Play();
            customer.me.textbox.text = customer.me.thankMsg;
            if (StatManager.instance.date.GetData() >= 12)
                StatManager.instance.StatPlus(StatManager.instance.money, (int)(customer.me.payment * 0.8f));
            else StatManager.instance.StatPlus(StatManager.instance.money, customer.me.payment);
            StatManager.instance.StatPlus(StatManager.instance.popular, customer.me.plusPopular);
        }
        else
        {
            effect.effectSounds[5].source.Play();
            customer.me.textbox.text = customer.me.wrongMsg;
            StatManager.instance.StatPlus(StatManager.instance.popular, -customer.me.minPopular);
        }
        if (StatManager.instance.popular.GetData() > 100)
            StatManager.instance.popular.SetData(100);
        StartCoroutine(Destroy_Menus(customer, GameObject.Find("IngredientStack")));
        
    }
    public static IEnumerator Destroy_Menus(GameManager.customer customer, GameObject parent)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
            Destroy(parent.transform.GetChild(i).gameObject);
        if (GameObject.Find("BeverageField").transform.childCount > 0)
            Destroy(GameObject.Find("BeverageField").transform.GetChild(0).gameObject);
        if (GameObject.Find("SideMenuField1").transform.childCount > 0)
            Destroy(GameObject.Find("SideMenuField1").transform.GetChild(0).gameObject);
        if (GameObject.Find("SideMenuField2").transform.childCount > 0)
            Destroy(GameObject.Find("SideMenuField2").transform.GetChild(0).gameObject);
        Stack.instance.stack.Clear();
        Stack.instance.sideMenu.Clear();
        Destroy(Stack.instance.beverage);
        yield return new WaitForSecondsRealtime(1.0f);
        if (customer != null)
            Destroy(customer.obj);
    }

    public void OnClickSellButton1()
    {
        SellMethod(GameManager.instance.customer1);
    }
    public void OnClickSellButton2()
    {
        SellMethod(GameManager.instance.customer2);
    }
    public void OnClickSellButton3()
    {
        SellMethod(GameManager.instance.customer3);
    }
}
