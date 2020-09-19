using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal6 : CustomerParent
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
                order = new string[] { "Sesame", "Beef", "Mustard", "Lettuce", "Sesame" };
                orderMsg = "총각 참깨빵에 소고기, 머스타드, 양상추, 참깨빵 순으로 주이소. 쿠키랑 스무디도.";
                waitMsg = "아유~ 젊은총각이 열심히네";
                exitMsg = "에잉 노인네를 얼마나 기다리게 하는거야?";
                thankMsg = "고마우이 잘먹을게";
                wrongMsg = "총각 이거 잘못준거같은데?";
                beverage = "Smoothie";
                sideMenu1 = "Cookie";
                break;
            case 1:
                order = new string[] { "White", "Tuna", "Mayo", "Lettuce", "Cheese", "White" };
                orderMsg = "학생 빵은 화이트로 해줘, 그 사이에 참치, 마요네즈, 양상추, 치즈 넣어주고.";
                waitMsg = "요즘것들은 머이리 비싼지..";
                exitMsg = "다리아파 죽겄구만 ㅡㅡ";
                thankMsg = "학생이 해줘서 더 맛있겠네";
                wrongMsg = "학생 재료 잘못넣어줬어..";
                break;
            case 2:
                order = new string[] { "Wit", "Tomato", "Tuna", "Mayo", "Egg", "Lettuce", "Pepper", "Wit" };
                orderMsg = "손주랑 같이먹게 위트 빵에 토마토, 참치..마요?랑 계란, 양상추, 피망이랑 스프도 하나 주세요";
                waitMsg = "울 손주가 좋아하겠지?";
                exitMsg = "편의점 샌드위치라도 사다줘야하나...";
                thankMsg = "잘먹을게요 고마우이";
                wrongMsg = "이게 제가말한게 맞아요?";
                sideMenu1 = "Soup";
                break;
            case 3:
                order = new string[] { "Oregano", "Beef", "Pork", "Lettuce", "Lettuce", "Mustard", "Salt", "Wit" };
                orderMsg = "저기 아저씨 파마산 오레가노, 소고기, 돼지고기, 양상추 2개에 머스타드, 소금, 위에빵은 위트로 줘.";
                waitMsg = "내가 딱딱한건 잘 못먹어서 잘 구워줘~";
                exitMsg = "그렇다고 아예 안주는건 너무하잖아 ";
                thankMsg = "어우~ 잘먹을게";
                wrongMsg = "아저씨 이거 잘못됐어 안먹을게";
                break;
            case 4:
                order = new string[] { "HoneyOat", "Potato", "Ketchup", "Pork", "Pickle", "HoneyOat" };
                orderMsg = "후..니오트? 빵에 으깬 감자, 케찹, 돼지고기, 피클로 주세요.";
                waitMsg = "요샌 영어가 왤케많은지..";
                exitMsg = "지금 노인네라고 무시하는거야?";
                thankMsg = "요게 수제 햄버거인가 뭔가인가 보네~";
                wrongMsg = "요게 제대로 준거 맞는거지?";
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
