using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : CustomerParent
{
    int slicePrice;
    PriceManager PriceManager;

    private void Awake()
    {
        PriceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        type = "Group";
        orderState = OrderState.yet;
        timer = 0;
        payment = 0;
        plusPopular = 10;
        minPopular = 6;
        orderState = OrderState.yet;
        ExitTime = 120.0f;
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
                order = new string[] { "Sesame", "Pork", "Teriyaki", "Sesame" };
                orderMsg = "안녕하세요! 친구들이랑 먹을건데 참깨빵에 돼지고기, 데리야끼소스 순으로 총 버거 5개주세요!!";
                waitMsg = "여러개라 오래걸리는건가..";
                exitMsg = "주문이 왜이리 느려요";
                thankMsg = "잘먹을게요!";
                wrongMsg = "하나가 잘못된거같은데??";
                groupStack = 5;
                break;
            case 1:
                order = new string[] { "White", "Beef", "Ketchup", "Lettuce", "Tomato", "White" };
                orderMsg = "화이트빵에 소고기랑 케찹 양상추 토마토이렇게 구성해서 2개주문할게요! 콜라도 2개주세요!";
                waitMsg = "우와~ 맛있겠다!";
                exitMsg = "저.. 시간이 부족해서 가볼게요";
                thankMsg = "잘먹을게요!!";
                wrongMsg = "이거 맛이 이상해요";
                beverage = "Cola";
                groupStack = 2;
                break;
            case 2:
                order = new string[] { "White", "Tuna", "Mayo", "Lettuce", "Cheese", "White" };
                orderMsg = "화이트빵에다가 참치에 마요네즈뿌려서 양상추랑 치즈올려서 주세요! 친구들 것까지 한 3개 정도?";
                waitMsg = "언제 되나요??";
                exitMsg = "너무 많이 주문했나?";
                thankMsg = "우와 디게 맛있어보인다";
                wrongMsg = "제가 원하던 맛이아니에요";
                groupStack = 3;
                break;
        }

        for (int i = 0; i < order.Length; i++)
            if (PriceManager.cost.TryGetValue(order[i], out slicePrice))
                payment += slicePrice * 2 * groupStack;
            else Debug.Log("Error");
        if (PriceManager.cost.TryGetValue(sideMenu1, out slicePrice))
            payment += slicePrice * 2 * groupStack;
        if (PriceManager.cost.TryGetValue(sideMenu2, out slicePrice))
            payment += slicePrice * 2 * groupStack;
        if (PriceManager.cost.TryGetValue(beverage, out slicePrice))
            payment += slicePrice * 2 * groupStack;
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
