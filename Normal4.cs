using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal4 : CustomerParent
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
                order = new string[] { "Oregano", "Oregano", "Egg", "Cucumber", "Cheese", "Mustard", "Oregano", "Oregano" };
                orderMsg = "2분 전에 수업 시작했거든요... 파마산 오레가노 사이에 계란, 오이, 치즈, 머스타드로 빨리 해주세요. 빵은 두 겹으로 해주시고.";
                waitMsg = "음... 지금 수업 시작했거든요...?";
                exitMsg = "수업 땜에... 가볼게요.";
                thankMsg = "감사합니다!";
                wrongMsg = "아 급해죽겠는데 증말";
                break;
            case 1:
                order = new string[] { "White", "White", "Pork", "Potato", "Pepper", "Wrench", "White", "White" };
                orderMsg = "지금 수업인데 아침을 못 먹고 왔어요. 화이트에 돼지고기, 으깬감자, 피망, 랜치소스 위에 다시 화이트 빵으로 주세요. 빵은 두 겹으로.";
                waitMsg = "왜 공강이 없는거야.. ㅠ";
                exitMsg = "아 안그래도 수업도 늦었는데;";
                thankMsg = "잔돈은 괜찮아요!!";
                wrongMsg = "제가 주문한게 이게 아니잖아요";
                break;
            case 2:
                order = new string[] { "Wit", "Tuna", "Tuna", "Mayo", "Tomato", "Wit" };
                orderMsg = "위트 빵, 참치, 마요네즈, 토마토, 위트 빵만 주세요. 아 그리고 안에 참치는 두 번 주시고요.";
                waitMsg = "그날.. 교수님을 찾아가면 안됐었어...";
                exitMsg = "아.. 뭐라도 먹어야하는데;";
                thankMsg = "하.. 랩실가기 싫다";
                wrongMsg = "왜 다른걸 주시죠?";
                break;
            case 3:
                order = new string[] { "Flat", "Pork", "Cheese", "Cheese", "Ketchup", "Mustard", "Lettuce", "Flat" };
                orderMsg = "플랫에 돼지고기, 치즈, 케찹, 머스타드, 양상추, 플랫 순으로 해주세요. 치즈는 두 장 주실래요?";
                waitMsg = "하.. 대학원생이라 슬프다 ㅠㅠ";
                exitMsg = "지금 대학원생이라 무시하는건가요?";
                thankMsg = "감사합니다.. 덕분에 힘이나네요";
                wrongMsg = "대학원생은 아무거나 먹으라는건가요?";
                break;
            case 4:
                order =new string[] { "HoneyOat", "Potato", "Egg", "Cheese", "Cucumber", "Pork", "Pork", "Teriyaki", "HoneyOat" };
                orderMsg = "허니오트 빵에 매쉬드 포테이토, 달걀, 치즈, 오이, 돼지고기, 데리야끼 소스에 허니오트 주세요. 그리고 고기는 두 장 주세요";
                waitMsg = "하.. 이번학기는 망했어.. ";
                exitMsg = "학점도 망해서 짜증나는데...";
                thankMsg = "이거라도 먹고 힘내야지...";
                wrongMsg = "화낼 기운도 없다...";
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