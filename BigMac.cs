using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMac : CustomerParent
{
    int slicePrice;
    PriceManager PriceManager;

    private void Awake()
    {
        PriceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        type = "BigMac";
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

        int rand = (int)Random.Range(0.0f, 2.0f);

        switch (rand)
        {
            case 0:
                order = new string[] { "Sesame", "Beef", "Beef", "Teriyaki", "Lettuce", "Cheese", "Pickle", "Sesame" };
                orderMsg = "참깨빵 위에~ 순쇠고기 패티 두 장, 특별한 소스에 양상추~ 치즈, 피클, 양파까아지~ 빠라 빠빠빠!";
                waitMsg = "네? 양파가 없다구요...? 그럼 걍 빼고 주세요 소스는 데리야끼가 좋아요!";
                exitMsg = "아 여기 아니구나";
                thankMsg = "음 제가 원하던 맛이네요!";
                wrongMsg = "당신은 빅맥의 철학을 무시한거야";
                break;
            case 1:
                order = new string[] { "Sesame", "Beef", "Beef", "Teriyaki", "Lettuce", "Cheese", "Pickle", "Sesame" };
                orderMsg = "빅맥하나주세요!! 빅맥!!";
                waitMsg = "레시피요? 검색해보세여 양파는 빼주세여! 그리고 비밀인데 빅맥소스는 사실 데리야끼소스래요";
                exitMsg = "여기 맥도날드 아닌가?";
                thankMsg = "역시 햄버거는 빅맥이지!";
                wrongMsg = "퉷퉷 이게 아니잖아";
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
