using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vege : CustomerParent
{
    int slicePrice;
    PriceManager PriceManager;

    private void Awake()
    {
        PriceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        type = "Vege";
        orderState = OrderState.yet;
        timer = 0;
        payment = 0;
        plusPopular = 3;
        minPopular = 6;
        orderState = OrderState.yet;
        ExitTime = 60.0f;
        waitTime = 20.0f;
        GetOrder();

        SetTextBox();
    }

    private void GetOrder()
    {
        int rand = (int)Random.Range(0.0f, 3.0f);
        switch (rand)
        {
            case 0:
                order = new string[] { "Lettuce", "Lettuce", "Lettuce", "Cucumber", "Wrench" };
                orderMsg = "제 꿈은 토끼가 되는거에요! 양상추 3개에 오이 올려주고 렌치소스 뿌려주세요!";
                waitMsg = "언제쯤 토끼가 될 수 있을까요?";
                exitMsg = "됐어요 당근이나 사러가야지";
                thankMsg = "토끼처럼 깡총깡총 뛰고싶어요!";
                wrongMsg = "우웩 뭘 먹인거에요?";
                break;
            case 1:
                order = new string[] { "White", "Lettuce", "Egg", "Cheese", "Mustard", "White"};
                orderMsg = "저는 동물들이 불쌍해서 고기는 못먹어요 화이트빵에 양상추랑 계란에 치즈올리고 머스타드소스 뿌려주세요! 커피도 하나주세요";
                waitMsg = "계란이요? 전 계란은 먹거든요?!";
                exitMsg = "고기 아니면 안판다는건가요?";
                thankMsg = "냠냠 역시 계란이 꿀맛이야";
                wrongMsg = "지금 저한테 이상한걸 먹이려고 한거에요?";
                beverage = "Coffee";
                break;
            case 2:
                order = new string[] { "HoneyOat", "Tomato", "Pepper", "Cucumber", "HotChili", "Salt", "HoneyOat"};
                orderMsg = "고기는 정말 맛없는거같아요! 허니오트에 토마토랑 피망 오이 올려주고 핫칠리랑 소금뿌려서 주세요!";
                waitMsg = "고기 냄새만 맡아도 토할거같아요";
                exitMsg = "고기 못먹는 절 이해못하나요?";
                thankMsg = "고마워요!";
                wrongMsg = "우웩 응급차좀 불러줘요";
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
