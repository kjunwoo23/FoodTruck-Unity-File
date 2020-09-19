using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal5 : CustomerParent
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
                order = new string[] { "HoneyOat", "Beef", "Lettuce", "Pickle", "HotChili", "HotChili", "HotChili", "HotChili", "HotChili", "HoneyOat" };
                orderMsg = "얼큰-하게 해주세요 얼큰-하게. 허니오트 빵 두 개 사이 소고기, 양상추, 피클에 핫칠리 5번 팍팍. 알겠어요 내 열정을? 알겠으면 감튀추가";
                waitMsg = "대체 뭔 조합이냐는 눈빛인데, 취향이거든? 누군 메뉴 생각하기 쉬운 줄 알아?";
                exitMsg = "아 안먹어";
                thankMsg = "으어- 얼큰하다";
                wrongMsg = "총각 이게 얼큰해요? 열받네?";
                sideMenu1 = "FriedPotato";
                break;
            case 1:
                order = new string[] { "Wit", "Chicken", "Chicken", "Beef", "Potato", "Wit" };
                orderMsg = "갑자기 텁텁한게 너무 먹고싶네. 위트 빵에 닭고기 2개, 소고기, 그 머쉬드 포테이토?랑 사이드는 쿠키 2개. ";
                waitMsg = "촉촉한거 넣기만 해봐";
                exitMsg = "다음에 또 온다";
                thankMsg = "아 너무 행복해";
                wrongMsg = "아 맛이 이상하잖아 기분 나쁘게 어쩔거야";
                sideMenu1 = "Cookie";
                sideMenu2 = "Cookie";

                break;
            case 2:
                order = new string[] { "White", "Egg", "Lettuce", "Wrench", "Cheese", "Sesame" };
                orderMsg = "천천히 해요 천천히~ 맨밑에는 화이트 빵에 계란, 양상추, 랜치소스에 치즈, 맨 위는 참깨빵으로 마무리해주세요~";
                waitMsg = "천천히 하라고했지 느긋하게 하라곤 안했어~";
                exitMsg = "장사를 하는거야 안하는거야~";
                thankMsg = "어휴 그렇다고 진짜 천천히 만드네~";
                wrongMsg = "아 버거 그렇게 만드는거 아닌데";
                break;
            case 3:
                order = new string[] { "Sesame", "Beef", "Lettuce", "Sesame" };
                orderMsg = "아유, 세상이 편해지니까, 햄버거를 길거리에서도 파네~ 하나 줘 봐요. 뭐? 패티? 그건 또 뭐야. 참깨빵 사이에 소고기 양상추 들어가면 다 햄버거 아냐~?";
                waitMsg = "이야~ 이런데서 장사하면 월세도 안내도 되고, 사는게 편해졌어? 응?";
                exitMsg = "이런... 마누라 기다리겠네.";
                thankMsg = "음~ 그저 그렇네.";
                wrongMsg = "엑엑 대체 뭐가 들어간거야?";
                break;
            case 4:
                order = new string[] { "Flat", "Pork", "Lettuce", "Lettuce", "Egg", "Flat" };
                orderMsg = "이런 날 시원-한 냉수에 깍두기있는 뜨끈-한 국밥집을 가지 왜 미쳤다고 햄버거를 먹는거야? 거 총각, 얇은 빵에 돼지고기, 이파리 두 장에 달걀, 빵 또 얹으면 얼마요? 과자도 주시고.";
                waitMsg = "이 시간이면 국밥 싹싹 비우고 깍두기 국물까지 다 마셨어~ 햄버거 먹는 놈들 다 철퇴로 인중을 후려버릴라.";
                exitMsg = "에잉~ 근처 국밥집이나 가야겠다";
                thankMsg = "국밥이랑 같이먹으면 맛있겠는데?";
                wrongMsg = "에라이 차라리 국밥을 먹고말지";
                sideMenu1 = "Cookie";
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
