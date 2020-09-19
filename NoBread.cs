using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBread : CustomerParent
{
    int slicePrice;
    PriceManager PriceManager;

    private void Awake()
    {
        PriceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        type = "NoBread";
        orderState = OrderState.yet;
        timer = 0;
        payment = 0;
        plusPopular = 3;
        minPopular = 6;
        orderState = OrderState.yet;
        ExitTime = 60.0f;
        waitTime = 15.0f;
        GetOrder();

        SetTextBox();
    }

    private void GetOrder()
    {

        int rand = (int)Random.Range(0.0f, 3.0f);
        switch (rand)
        {
            case 0:
                order = new string[] { "Lettuce", "Beef", "Ketchup", "Lettuce" };
                orderMsg = "빵대신 양상추써주시고 소고기랑 케찹 올려서주시고 스무디하나 추가할게요";
                waitMsg = "빵은 저희 주방장이 해주신거 아니면 안먹어요";
                exitMsg = "바쁘시나 보네요 다음에 맛볼게요";
                thankMsg = "다음엔 빵도 도전해봐야겠네요!";
                wrongMsg = "저 제가 말한대로 주신거 맞나요?";
                beverage = "Smoothie";
                break;
            case 1:
                order = new string[] { "Lettuce", "Tomato", "Cucumber", "Tuna", "Mayo", "Lettuce" };
                orderMsg = "빵은 고급진게 아니면 안먹어서 빼주시고 빵 대신 위 아래로 양상추에 토마토랑 오이 올려주시고 참치에 마요네즈 뿌려주세요!";
                waitMsg = "얼마나 기다려야하나요?";
                exitMsg = "실력도 예의도 정말 없어보이네여!";
                thankMsg = "실력이 좀 괜찮네요?";
                wrongMsg = "맛이 저희 주방장 발톱때만도 못하네요";
                break;
            case 2:
                order = new string[] { "Lettuce", "Egg", "Cheese", "Lettuce", "Tuna", "Mayo", "Lettuce" };
                orderMsg = "빵빼고는 맛있어보이는데 양상추에 계란하고 치즈 올린다음에 안에 또 양상추 다시 올리고 참치에 마요네즈소스 뿌려서 위에는 다시 양상추로 주세요!";
                waitMsg = "제가 외국에서 고급진빵만 먹어서 입맛이 고급져졌어요~";
                exitMsg = "됐어요 재수없어서 못먹겠네";
                thankMsg = "집에있는 고급빵이랑 싸먹어야지!";
                wrongMsg = "길거리 음식이 그렇지 뭐";
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
