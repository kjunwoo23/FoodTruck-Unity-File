using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal8 : CustomerParent
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
                order = new string[] { "Oregano", "Beef", "Cheese", "Cheese", "Potato", "Ketchup", "Oregano" };
                orderMsg = "빵은 오레가노에 소고기에 치즈 두장 올려주고 매쉬드포테이토에 케첩뿌려주세요!";
                waitMsg = "SNS에 올리게 이쁘게 만들어주세요!";
                exitMsg = "SNS에 소문내버려야지 ㅡㅡ";
                thankMsg = "우와! 빨리 사진찍어야지";
                wrongMsg = "아 안먹을래";
                break;
            case 1:
                order = new string[] { "White", "Chicken", "Tomato", "Tomato", "Salt", "Teriyaki", "White" };
                orderMsg = "화이트빵에 치킨이랑 토마토두장에 소금이랑 데리야끼 소스 이렇게 주세요!!! 아참! 쿠키2개 추가요!";
                waitMsg = "아ㅠㅠ 다이어트 해야하는데 또 먹고있네";
                exitMsg = "하.. 그냥 다이어트나 해야지";
                thankMsg = "다이어트는 내일부터지!!";
                wrongMsg = "제가 주문한게 아닌데요?";
                sideMenu1 = "Cookie";
                sideMenu2 = "Cookie";
                break;
            case 2:
                order = new string[] { "Wit", "Cucumber", "Cucumber", "Cucumber", "Tuna", "Mayo", "Lettuce", "Lettuce", "Wit" };
                orderMsg = "위트빵에 오이세장에 참치마요 주시고 양상추 두장올려주고 커피도 한잔 부탁해요";
                waitMsg = "아.. 1교시 진짜짜증나 ㅠㅠ";
                exitMsg = "안그래도 짜증나는데 더 짜증나게 만드네..";
                thankMsg = "이거라도 먹고 공부하러가야지";
                wrongMsg = "나참.. 이거 잘못줬어요";
                beverage = "Coffee";
                break;
            case 3:
                order = new string[] { "Flat", "Pork", "Cheese", "Ketchup", "Pickle", "Pepper", "Flat" };
                orderMsg = "플랫하고 돼지고기에 치즈올리고 케찹이랑 피클에 피망올려서 부탁할게요";
                waitMsg = "이 좋은날씨에 수업이나 가야하다니ㅠㅠ";
                exitMsg = "수업가야해서 그냥 갈게요..";
                thankMsg = "하.. 출튀하고 그냥 샌드위치나 먹어야지";
                wrongMsg = "아.. 이거 잘못주셨어요;;";
                break;
            case 4:
                order = new string[] { "HoneyOat", "Tomato", "Potato", "HotChili", "HoneyOat", "Egg", "Pickle", "Beef", "Sesame" };
                orderMsg = "늘 먹던걸로요! 네? 허니오트에 토마토랑 감자위에 핫칠리 뿌리고 가운데 빵 하나 추가해주시고 계란이랑 피클로 덮은다음 소고기 올려서 달라구요! 맨 위에빵은 참깨빵인거 알죠?";
                waitMsg = "예? 장난좀 쳐본거에요";
                exitMsg = "아 왜이리 오래걸려요 그냥 갈래요!!";
                thankMsg = "완죤 마시써 >_<";
                wrongMsg = "저랑 장난하자는거에요?";
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
