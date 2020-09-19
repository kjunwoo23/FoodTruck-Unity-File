using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadOnly : CustomerParent
{
    int slicePrice;
    PriceManager PriceManager;

    private void Awake()
    {
        PriceManager = GameObject.Find("PriceManager").GetComponent<PriceManager>();
        type = "BreadOnly";
        orderState = OrderState.yet;
        timer = 0;
        payment = 0;
        plusPopular = 3;
        minPopular = 6;
        orderState = OrderState.yet;
        ExitTime = 60.0f;
        waitTime = 10.0f;
        GetOrder();

        SetTextBox();
    }

    private void GetOrder()
    {

        int rand = (int)Random.Range(0.0f, 2.0f);

        switch (rand)
        {
            case 0:
                orderMsg = "안녕하세요! 저쪽에서 빵집을 운영하는데 빵좀 맛보려고 왔어요. 빵 주세요.";
                waitMsg = "미리 준비된 빵 아닌가요? 왤케 오래걸리죠";
                exitMsg = "뭐야? 빵 수준도 떨어져보이는구만";
                thankMsg = "음.. 먹을만 하네요^^";
                wrongMsg = "이게 빵이 맞나요?? 빵수준이 참..";
                break;
            case 1:
                orderMsg = "제가 파리바게트 정직원이라 빵좀 잘 아는데 빵 하나좀 주세요!";
                waitMsg = "흠.. 파리바게트는 빨리나오는데";
                exitMsg = "서비스 수준도 떨어지네요!";
                thankMsg = "역시 갓구운 빵이 맛있는거 같아요";
                wrongMsg = "그쪽은 이게 빵이라고 생각해요?";
                break;
            case 2:
                orderMsg = "제가 빵을 공부중인데 빵이 맛있어보이네요. 한번 보고싶네요";
                waitMsg = "저 공부하러 가봐야하는데..";
                exitMsg = "이가게 완전 재수없네";
                thankMsg = "덕분에 공부가 됐어요!";
                wrongMsg = "제가 아는바로는 이게 빵이 아닌데?..";
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
