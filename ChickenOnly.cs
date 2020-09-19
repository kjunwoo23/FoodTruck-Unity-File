using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenOnly : CustomerParent
{
    int slicePrice;
    PriceManager PriceManager;

    private void Awake()
    {
        PriceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        type = "ChickenOnly";
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
                order = new string[] { "Chicken" };
                orderMsg = "치킨 먹고싶은데 배달해먹기엔 기다리기 귀찮아요 치킨패티 하나 주세요";
                waitMsg = "아니 요즘 햄버거 집 다 치킨 팔잖아요 저 학관에 햄버거집도 그러던데";
                exitMsg = "배달보다 더 오래 걸리네...";
                thankMsg = "치킨 개꿀";
                wrongMsg = "아니 햄버거 말고 치킨이요 치킨";
                break;
            case 1:
                order = new string[] { "Chicken", "Chicken", "Chicken" };
                orderMsg = "무슨일인지 모르겠지만 주변치킨집이 문을 다 닫았어요. 치킨패티 3개만 주세요.";
                waitMsg = "왜 전부다 문을 닫은거지?";
                exitMsg = "아니 여기도 치킨을 안파네";
                thankMsg = "고마워요!";
                wrongMsg = "그쪽이 보기엔 이게 치킨인가요?";
                break;
            case 2:
                order = new string[] { "Chicken" };
                orderMsg = "치킨패티 하나하고 치킨 비스무리한거 하나주세요";
                waitMsg = "그 사이드메뉴에 있잖아여";
                exitMsg = "뭐야? 치킨집 아니였어?";
                thankMsg = "여기 치킨 맛집이구만";
                wrongMsg = "요즘 치킨은 이렇나요?";
                sideMenu1 = "Nugget";
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
