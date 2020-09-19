using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal3 : CustomerParent
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
        waitTime = 20.0f;
        GetOrder();

        SetTextBox();
    }
    private void GetOrder()
    {
        int rand = (int)Random.Range(0.0f, 5.0f);
        switch (rand)
        {
            case 0:
                order = new string[] { "Sesame", "Pork", "Mustard", "Ketchup", "Lettuce", "Sesame" };
                orderMsg = "참깨빵, 돼지고기, 머스타드, 케찹, 양상추, 참깨빵...";
                waitMsg = "...";
                exitMsg = "...";
                thankMsg = "...";
                wrongMsg = "...";
                break;
            case 1:
                order = new string[] { "White", "Cucumber", "Cucumber", "Cucumber", "Pepper", "Egg", "Egg", "White" };
                orderMsg = "화이트 빵에 오이 세 개, 피망에 계란 두 개, 화이트 빵으로 주세요.";
                waitMsg = "(대충 기다린다는 내용)";
                exitMsg = "(대충 화난다는 내용)";
                thankMsg = "(대충 고맙다는 내용)";
                wrongMsg = "(대충 잘못됐다는 내용)";
                break;
            case 2:
                order = new string[] { "Wit", "Pork", "Pork", "Tomato", "Tomato", "Wit" };
                orderMsg = "위트 빵, 돼지고기 두 개, 토마토 두 개, 위트 빵으로 주세요.";
                waitMsg = "언제나오죠?";
                exitMsg = "하.. 그냥 갈게요";
                thankMsg = "고마워요";
                wrongMsg = "됐어요 그냥 먹을게요.";
                break;
            case 3:
                order = new string[] { "Flat", "Chicken", "Mustard", "Tomato", "Pickle", "Chicken", "Flat" };
                orderMsg = "플랫에 치킨, 머스타드, 토마토,\n 피클, 치킨, 플랫 순으로 해주세요.";
                waitMsg = "얼마나 걸리죠?";
                exitMsg = "바쁘면 바쁘다고 해주시지...";
                thankMsg = "잘먹을게요";
                wrongMsg = "저 요거 주문이 잘못됐네요";
                break;
            case 4:
                order = new string[] { "HoneyOat", "Potato", "Potato", "Potato", "Tomato", "Pork", "Wrench", "HoneyOat" };
                orderMsg = "허니오트 빵에 으깬 감자 3번, 토마토, 돼지고기, 랜치소스에 허니오트 주세요.";
                waitMsg = "금방 나오는거죠?";
                exitMsg = "됐으니까 가볼게요";
                thankMsg = "다음엔 회사 동료도 데려올게요";
                wrongMsg = "제가 말한거랑 일치하지가 않는데...";
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
