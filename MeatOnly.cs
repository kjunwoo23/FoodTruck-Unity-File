using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatOnly : CustomerParent
{
    int slicePrice;
    PriceManager PriceManager;

    private void Awake()
    {
        PriceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        type = "MeatOnly";
        orderState = OrderState.yet;
        timer = 0;
        payment = 0;
        plusPopular = 3;
        minPopular = 6;
        orderState = OrderState.yet;
        ExitTime = 60.0f;
        waitTime = 10.0f;
        GetOrder();

        SetTextBox();
    }

    private void GetOrder()
    {

        int rand = (int)Random.Range(0.0f, 3.0f);
        switch (rand)
        {
            case 0:
                order = new string[] { "Beef", "Beef", "Beef" };
                orderMsg = "전 고기가 제일좋아요! 소고기 3개주세요!";
                waitMsg = "소 냄새가 여기까지 나네요";
                exitMsg = "고기 안팔아요??";
                thankMsg = "업진살 살살 녹는다";
                wrongMsg = "하 이게 소고기로 보여요?";
                break;
            case 1:
                order = new string[] { "Beef", "Pork", "Chicken" };
                orderMsg = "고기주세요 고기! 메뉴에 순서대로 3개주세요~";
                waitMsg = "채소요? 고기가 먹겠죠";
                exitMsg = "평생 채소만 먹고살아라";
                thankMsg = "크 이게 음식이지";
                wrongMsg = "아니 고기를 달라니깐요";
                break;
            case 2:
                order = new string[] { "Pork", "Cheese" };
                orderMsg = "돼지고기에 치즈올려먹으면 맛있을거같지 않나요?";
                waitMsg = "네? 그걸로 달라고요";
                exitMsg = "해주기 싫으면 싫다고 하든가";
                thankMsg = "역시 예상대로 맛있네요";
                wrongMsg = "퉷 예상하던 맛이 아닌데";
                break;
        }

        for (int i = 0; i < order.Length; i++)
            if (PriceManager.cost.TryGetValue(order[i], out slicePrice))
                payment += slicePrice * 2;
            else Debug.Log("Error");
        if (PriceManager.cost.TryGetValue(sideMenu1, out slicePrice))
            payment += slicePrice * 2;
        if (PriceManager.cost.TryGetValue(sideMenu2, out slicePrice))
            payment += slicePrice * 2;
        if (PriceManager.cost.TryGetValue(beverage, out slicePrice))
            payment += slicePrice * 2;

    }

    private void Start()
    {
        SetLine();
    }



    public void Update()
    {
        ConditionSet();
    }
}
