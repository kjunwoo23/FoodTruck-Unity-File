using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drunk : CustomerParent
{
    int slicePrice;
    PriceManager PriceManager;

    private void Awake()
    {
        PriceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        type = "Normal";
        orderState = OrderState.yet;
        timer = 0;
        payment = 0;
        plusPopular = 3;
        minPopular = 6;
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
                order = new string[] { "Flat", "Beef", "Lettuce", "Pickle", "Mayo", "Flat" };
                orderMsg = "플룻,,,쇠괴기,,,흐끅!,랑 양, 양상추,,,랑, 거,,,ㅍ,,,야채,,,뭐였ㅈ,,,!@#!@ 으억,,,마요,,, 플룻!";
                waitMsg = "빨,,리,, 토할거같아,,,";
                exitMsg = "너,,, ㄷ,,두고봐!!";
                thankMsg = "감사합ㄴㅣㄷㅏ,,,,";
                wrongMsg = "구웨에에엑";
                break;
            case 1:
                order = new string[] { "White", "Chicken", "Pork", "Lettuce", "HotChili", "White" };
                orderMsg = "빵은 화이트에.. 치킨이랑 돼지고기.. 야채는 양상추 소스는 핫ㅊ..ㄹ로 주세요";
                waitMsg = "빨리주세요....";
                exitMsg = "다른데 가야지,,,";
                thankMsg = "감사해요";
                wrongMsg = "뭐야 이거";
                break;
            case 2:
                order = new string[] { "Oregano", "Pork", "Cheese", "Egg", "HotChili", "Oregano" };
                orderMsg = "빵은 오레가노랑 패티는 돼지고기, 치ㅈ 계란.. 소스는 핫..(!@#)로 주세요";
                waitMsg = "이씨... 언제나오는거야";
                exitMsg = "에라이 안먹는다 안먹어";
                thankMsg = "(!@#)(!@#)";
                wrongMsg = "야! 이게아니잖아,,";
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
