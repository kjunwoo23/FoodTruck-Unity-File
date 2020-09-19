using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal9 : CustomerParent
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
        List<string[]> list = new List<string[]>();
        list.Add(new string[] { "Sesame", "Pork", "Tomato", "Cheese", "Cheese", "Sesame" });
        list.Add(new string[] { "White", "Chicken", "Beef", "Beef", "Tuna", "White" });
        list.Add(new string[] { "HoneyOat", "Lettuce", "Cheese", "Tuna", "Mayo", "HoneyOat" });
        list.Add(new string[] { "Oregano", "Cucumber", "Egg", "Pork", "Cheese", "Teriyaki", "Wit" });
        list.Add(new string[] { "Flat", "Pork", "Pork", "Beef", "Beef", "Lettuce", "Egg", "Egg", "Egg", "Flat" });

        int rand = (int)Random.Range(0.0f, 5.0f);
        order = list[rand];

        switch (list[rand][0])
        {
            case "Sesame":
                orderMsg = "참깨빵에 돼지고기, 미니언 세 마리 대포 얹어서 토마토에 용 먹고 치즈 두 장에 바론 ㄱㄱ여. 그럼 참깨빵 엔딩에 서렌ㅈㅈ. 서폿 자리에 치킨너겟도. 못 알아듣겠는건 걍 빼셈 세대차이 ㅈㅈ요";
                waitMsg = "님 뭐하셈? 갑자기 탈주하네 리폿 ㅈㅈ요";
                exitMsg = "기분 나쁘게하네 명예훼손죄로 고소할거임 ㅅㄱ";
                thankMsg = "ㄱㅅㄱㅅ";
                wrongMsg = "능 지 차 이";
                sideMenu1 = "Nugget";
                break;
            case "White":
                orderMsg = "본인 방금 알리스타로 게임 캐리하는 상상함ㅋㅋㅋ 화이트랑 치킨 갈리오 듀오 보내고 미드에 풀템 알리스타 소고기 미러전에ㅋㅋㅋ 갑자기 정글에서 참치 피즈가 튀어나오는거임ㅋㅋㅋ";
                waitMsg = "하지만 어림도 없지ㅋㅋㅋ 바로 알리 쿵쾅에 포탑 갱승ㅋㅋㅋ 탑은 비어있음ㅋㅋㅋ";
                exitMsg = "엌ㅋㅋㅋ 이게 안 웃김?ㅋㅋㅋ";
                thankMsg = "아 매드무비 보고 자야지ㅋㅋㅋ";
                wrongMsg = "가게 수준ㅋㅋㅋㅋㅋㅋㅋ";
                break;
            case "HoneyOat":
                orderMsg = "엄마가 게임 너무 많이한다고 쫓아냈어요. 이해가 안 가네. 허니오트에 양상추, 치즈, 참치, 마요에 허니오트. 스무디도 같이. 여기 메소로 결제해도 되나요?";
                waitMsg = "<Zㅣ존병식> 친추걸면 바로 1억메소 쏴드립니다. 안된다구요? 왜요.";
                exitMsg = "저 지금 보스 돌아야되서 이만 ㅂㅂ";
                thankMsg = "ㄲㅂ 현금 얼마 안 남았는데...";
                wrongMsg = "아 님 인기도 내릴거임 ㅅㄱ";
                beverage = "Smoothie";
                break;
            case "Oregano":
                orderMsg = "아 집 언제 들어가지. 얼마 전에 집에서 쫓겨났는데 거점 비비듯이 들어가볼까요? 아빠가 윈스턴 궁만 안 키면ㅋㅋㅋ 오레가노에 오이, 계란, 돼지고기, 치즈에 데리야끼 다시 위트에 쿠키 ㄱㄱ";
                waitMsg = "아 그때 내가 루시우였으면 속도 키고 집안에서 슉슉하고 도망다닐 수 있었을텐데";
                exitMsg = "햄버거 하나가지고 쥰내 비비네 거점도 아니고...";
                thankMsg = "대리 필요하면 부르셈ㅋ";
                wrongMsg = "ㅋ브론즈냐?";
                sideMenu1 = "Cookie";
                break;
            case "Flat":
                orderMsg = "님 60초라는 게임 알아요? 핵전쟁나는거. 제가 지금 집에서 쫓겨나고 딱 그 꼴이거든요? 죽을거같으니까 플랫빵에 돼지고기 두 개, 소고기 두 개에 양상추, 계란 세 개 플랫빵, 콜라로 스겜부탁";
                waitMsg = "지금 굶어 디지겄는데 뭐하는거예요.";
                exitMsg = "아 나 죽는다 당신이 죽였어";
                thankMsg = "휴 이제 좀 살았네";
                wrongMsg = "엑 님 이거 방사능 오염됨?";
                beverage = "Cola";
                break;
        }

        for (int i = 0; i < list[rand].Length; i++)
            if (PriceManager.cost.TryGetValue(list[rand][i], out slicePrice))
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