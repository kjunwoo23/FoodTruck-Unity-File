using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal10 : CustomerParent
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
                order = new string[] { "Sesame", "Pork", "Lettuce", "Sesame", "Mustard", "Pork", "Sesame" };
                orderMsg = "참깨빵에 돼지고기, 양상추 사이에 빵하나 추가해주시고 머스타드소스랑 돼지고기로 정할게요!";
                waitMsg = "네? 손이요? 옷소매안에있어요";
                exitMsg = "갑자기 먹기 싫어졌어요";
                thankMsg = "장사 잘되게 홍보할게요!";
                wrongMsg = "뭐야.. 잘못주셨어요";
                break;
            case 1:
                order = new string[] { "White", "Chicken", "Pepper", "HotChili", "HotChili", "HotChili", "White" };
                orderMsg = "화이트빵에 닭고기랑 피망에 핫칠리3번 뿌려주세요! 아 스무디도 땡기네요..";
                waitMsg = "요즘따라 매운게 땡겨요";
                exitMsg = "여기는 사장 성질이 맵네";
                thankMsg = "스트레스엔 매운게 최고지";
                wrongMsg = "덜맵잖아요!!";
                beverage = "Smoothie";
                break;
            case 2:
                order = new string[] { "Chicken", "Wit", "Pepper", "Pickle", "Ketchup", "Wit", "Chicken" };
                orderMsg = "치킨 패티에 위트, 피망, 피클, 케찹에 위트 빵, 다시 위에 치킨 주세요. 커피도 같이.";
                waitMsg = "손에 기름은 묻지만 이게 맛있어요!";
                exitMsg = "지금 이상하게 먹는다고 안주는거에요?";
                thankMsg = "역시 치킨이 최고지!!";
                wrongMsg = "잘못주셨잖아요..";
                beverage = "Coffee";
                break;
            case 3:
                order = new string[] { "Sesame", "Pork", "Teriyaki", "Sesame" };
                orderMsg = "아무거나 주세요! 네? 없다고요? 그러면 간단하게 참깨빵에 돼지고기랑 데리야끼 올려주시고 쿠키두개 주문할게요";
                waitMsg = "그냥 대충 아무거나 주셔도 되는데..";
                exitMsg = "간단한거 하나 하기도 힘드나..";
                thankMsg = "롯데리아 데X버거 맛인데??";
                wrongMsg = "그렇다고 너무 대충하시는거 아니에요?";
                sideMenu1 = "Cookie";
                sideMenu2 = "Cookie";
                break;
            case 4:
                order = new string[] { "Sesame", "Lettuce", "Cheese", "Beef", "Sesame", "Lettuce", "Cheese", "Beef", "Teriyaki", "Sesame" };
                orderMsg = "잘 기억해요. 참깨빵, 양상추, 치즈, 소고기, 참깨빵, 양상추, 치즈, 소고기, 데리야끼소스, 참깨빵 이 순서대로 주시고 감튀랑 너겟에다 커피한잔 부탁드려요";
                waitMsg = "역시 사람은 푸짐하게 먹어야지~";
                exitMsg = "재료 얼마 되지도 않구만 이걸 안해주네";
                thankMsg = "햄버거가 이정도는 되야지!!";
                wrongMsg = "그거 하나 기억못해요?";
                beverage = "Coffee";
                sideMenu1 = "FriedPotato";
                sideMenu2 = "Nugget";
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
