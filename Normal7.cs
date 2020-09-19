using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal7 : CustomerParent
{

    int slicePrice;
    PriceManager PriceManager;

    private void Awake()
    {
        PriceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        type = "Normal";
        orderState = OrderState.yet;
        timer = 0;
        payment = 5000;
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
                order = new string[] { "Sesame", "Tomato", "Lettuce", "Pepper", "Mustard", "Mayo", "Sesame" };
                orderMsg = "빵은 위아래에 참깨빵으로 해주시구요, 토마토, 양상추, 피망, 머스타드, 마요네즈로 주세요. 음료는 사이다로.";
                waitMsg = "세종냥이가 뭘 좋아할까요?";
                exitMsg = "얼굴에 손톱자국 남겨드려요?";
                thankMsg = "얼른 냥이들 보러가야지~";
                wrongMsg = "왜 잘못된걸 주시나요";
                beverage = "Cider";
                break;
            case 1:
                order = new string[] { "Flat", "Pork", "Cheese", "Lettuce", "Egg", "Cucumber", "Flat" };
                orderMsg = "플랫빵에 돼지고기, 치즈, 양상추, 계란, 오이 위에 다시 플랫빵으로 주세요.";
                waitMsg = "고양이 너무귀여어ㅓㅓㅓㅓㅓㅓ";
                exitMsg = "ㅠㅠㅠㅠㅠㅠㅠ 슬퍼";
                thankMsg = "고마어ㅓㅓㅓㅓㅓ";
                wrongMsg = "이거 잘못줘써ㅓㅓㅓㅓㅓ";
                break;
            case 2:
                order = new string[] { "Wit", "Beef", "Beef", "Beef", "Beef", "Beef", "Pickle", "Lettuce", "HotChili", "Wit" };
                orderMsg = "위트 빵에 소고기 다섯 장, 피클, 양상추, 핫칠리, 위트 빵으로 주세요.";
                waitMsg = "세종냥이 우주뿌셔 지구뿌셔 ㅠㅠㅠㅠㅠㅠ";
                exitMsg = "사장 대가리 뿌셔 ㅠㅠㅠ";
                thankMsg = "기분 너무좋아 ㅠㅠㅠㅠㅠ";
                wrongMsg = "푸드트럭 뿌셔 ㅠㅠㅠ";
                break;
            case 3:
                order = new string[] { "Oregano", "Pork", "Egg", "Tomato", "HotChili", "Oregano" };
                orderMsg = "빵은 위아래로 파마산 오레가노, 그 사이에 소고기 말고 돼지고기, 계란, 토마토, 핫칠리 소스 주세요. 음료요? 콜라주세용!";
                waitMsg = "오늘 냥이들 밥주러 가야하는뎅..";
                exitMsg = "저 냥이들 밥주러가야해서 그냥 갈게요";
                thankMsg = "헤헤 냥이들 밥은 뭐줄까?";
                wrongMsg = "이거 아니잖아요..";
                beverage = "Cola";
                break;
            case 4:
                order = new string[] { "HoneyOat", "Cheese", "HotChili", "Egg", "Chicken", "Teriyaki", "HoneyOat" };
                orderMsg = "빵은 허니오트, 그 사이 맛있는 치즈에, 핫칠리 소스, 계란은 살짝 반숙으로, 치킨, 위에 데리야끼도 올려주세요. 감튀도 2개 주세요!";
                waitMsg = "고양이귀 후드티 구매하느라 힘들었어요";
                exitMsg = "밥한번 먹기 드럽게 힘드네";
                thankMsg = "헤헤 고마워요!";
                wrongMsg = "저 이거 안시켰어요";
                sideMenu1 = "FriedPotato";
                sideMenu2 = "FriedPotato";
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

