using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Normal : CustomerParent
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
                order = new string[] { "HoneyOat", "Beef", "Potato", "Lettuce", "Beef", "Mustard", "HoneyOat" };
                orderMsg = "허니 오트에 소고기 패티, 감자, 양상추, 소고기 패티, 머스타드, 허니 오트 순으로 해주시고, 음료는 콜라로 주세요.";
                waitMsg = "언제 나오는 건가요?..";
                exitMsg = "뭐야.. 내 햄버거 돌려줘요";
                thankMsg = "감사합니다";
                wrongMsg = "주문이랑 다른거 같아요..";
                beverage = "Cola";
                break;
            case 1:
                order = new string[] { "White", "Beef", "Pickle", "Lettuce", "Teriyaki", "Chicken", "White" };
                orderMsg = "화이트 빵에 소고기, 피클, 양상추, 데리야끼 소스, 치킨 패티에 화이트 빵 순으로 주세요. 커피랑 감자튀김도 주시고.";
                waitMsg = "네? 학교요? 저 앞에있는데 다녀요 ㅎㅎ";
                exitMsg = "애들한테 오지말라고해야지 나참";
                thankMsg = "다음엔 친구들도 불러올게요!";
                wrongMsg = "여기 맛이 원래 이런가요?";
                beverage = "Coffee";
                sideMenu1 = "FriedPotato";
                break;
            case 2:
                order = new string[] { "Wit", "Chicken", "Egg", "Cheese", "Cucumber", "Pepper", "Wit" };
                orderMsg = "위트 빵에 닭고기 패티 얇은거랑, 달걀, 치즈, 오이, 피망 다시 위트 빵으로 얹어주세요. 스무디랑요.";
                waitMsg = "하.. 다이어트 해야하는데 또먹고있네";
                exitMsg = "제 다이어트 도와주려는 큰그림인가요?";
                thankMsg = "역시 다이어트는 내일부터야!";
                wrongMsg = "입맛이 떨어지는 맛이네";
                beverage = "Smoothie";
                break;
            case 3:
                order = new string[] { "Sesame", "Cucumber", "Pork", "Flat" };
                orderMsg = "참깨 빵에 오이, 돼지고기에 플랫 빵으로 해주세요. 콘스프랑 쿠키도 주세요.";
                waitMsg = "사장님 서비스는 없나요~?";
                exitMsg = "네? 주문 받아놓고 안주는게 어딨어요?";
                thankMsg = "우와! 서비스도 왕창주시고 고마워요!!";
                wrongMsg = "저 이거 주문이 틀린거같아요";
                sideMenu1 = "Soup";
                sideMenu2 = "Cookie";
                break;
            case 4:
                order = new string[] { "Oregano", "Lettuce", "Tuna", "Cheese", "Mayo", "Ketchup", "Oregano" };
                orderMsg = "오레가노에 양상추 두 개, 아니 한 개, 참치, 치즈, 마요네즈, 케찹에 오레가노로 마무리요.";
                waitMsg = "참치마요는 제 최애픽이에요!";
                exitMsg = "참치마요 먹고싶은데 ㅠㅠ";
                thankMsg = "맛있을지 기대되네요!";
                wrongMsg = "뭐야 참치마요 어딨어요?";
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
