using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celeb : CustomerParent
{
    int slicePrice;
    PriceManager PriceManager;

    private void Awake()
    {
        PriceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        type = "Celeb";
        orderState = OrderState.yet;
        timer = 0;
        payment = 0;
        plusPopular = 10;
        minPopular = 10;
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
                order = new string[] { "Flat", "Tuna", "Tuna", "Tuna", "Cucumber", "Cucumber", "Mayo", "Wrench", "Tomato", "Flat" };
                orderMsg = "안녕하세요~ 빵은 플랫브레드로 해주시고 참치3스쿱에 오이 2장올려주시고 마요네즈랑 랜치소스 넣어주시고 토마토 올려주세요!";
                waitMsg = "네? TV요? 아 맞아요 알아봐주셔서 감사합니다 ㅎㅎ";
                exitMsg = "음.. 바쁘신가 보네요. 가볼게요";
                thankMsg = "감사합니다! 애들한테 소개해줘야지";
                wrongMsg = "괜찮아요 ㅎㅎ 실수할수도 있죠.";
                break;
            case 1:
                order = new string[] { "HoneyOat", "Beef", "Pork", "Chicken", "Teriyaki", "Lettuce", "Tomato", "Tomato", "Pickle", "White" };
                orderMsg = "그 허니오트에 소고기 돼지고기 닭고기 순서로 올리고 데리야끼소스에 야채는 양상추 토마토2장 피클넣어주고 화이트빵으로 마무리 해서 줘요. 음료는 콜라인거 알죠?";
                waitMsg = "제가 유명인사라 자꾸 쳐다보는건 알겠는데 불쾌하거든요?";
                exitMsg = "뭐야 완전재수없어 소문내버릴거야";
                thankMsg = "생각보다 괜찮은데요?";
                wrongMsg = "지금 SNS에 올려서 망하게 해드려요??";
                beverage = "Cola";
                break;
            case 2:
                order = new string[] { "White", "Pork", "Lettuce", "Cheese", "Ketchup", "White", "Tuna", "Lettuce", "Mayo", "White" };
                orderMsg = "맞아요~ OOO에 출연한사람 근데 주문부터 받아주시죠! 빵은 화이트에 돼지고기, 양상추, 치즈, 케찹 순으로 올린뒤 가운데 빵하나 추가해주시고 참치, 양상추, 마요네즈 넣어주세요! 사이드메뉴는 콘스프랑 너겟으로 주시고요.";
                waitMsg = "흠.. 언제까지 기다려야하나요?";
                exitMsg = "후.. 이미지 때문에 봐주는겁니다.";
                thankMsg = "고마워요! 잘먹을게요!";
                wrongMsg = "제가 말한게 아닌거같은데...";
                sideMenu1 = "Soup";
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
