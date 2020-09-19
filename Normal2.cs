using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal2 : CustomerParent
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
                order = new string[] { "Sesame", "Beef", "Mustard", "Lettuce", "Pickle", "Sesame" };
                orderMsg = "참깨빵에 소고기 패티, 머스타드,\n 양상추, 피클, 참깨빵 순으로 해주세요.";
                waitMsg = "언제주시나요?";
                exitMsg = "아니 안주시는 이유가 뭐죠?";
                thankMsg = "안녕히계세요!";
                wrongMsg = "저 주문 틀리신거같은데...";
                break;
            case 1:
                order = new string[] { "White", "Egg", "Potato", "Pepper", "Mustard", "Mustard", "White" };
                orderMsg = "화이트 빵에 달걀, 매쉬드 포테이토, 피망, 머스타드 두 번, 화이트 빵으로 주세요.";
                waitMsg = "고기는 국내산인가요?";
                exitMsg = "지금 저랑 장난하는건가요?";
                thankMsg = "수고하세요! 사장님";
                wrongMsg = "이거 맛이 이상해요";
                break;
            case 2:
                order = new string[] { "Wit", "Pickle", "Pickle", "HotChili", "Cheese", "Cheese", "Wit" };
                orderMsg = "위트 빵에 피클 두 개, 핫칠리, 치즈 두 개, 위트 빵 순으로 주세요. 사이다도 있으면 주세요!";
                waitMsg = "빨리주세요 현기증나요~";
                exitMsg = "주문 안받아요? 화나네?";
                thankMsg = "야무지게 먹어야지~";
                wrongMsg = "어? 화나네?";
                beverage = "Cider";
                break;
            case 3:
                order = new string[] { "Flat", "Pork", "Ketchup", "Mustard", "Cheese", "Flat" };
                orderMsg = "플랫빵에 돼지고기, 케찹, 머스타드, 치즈, 플랫으로 주세요.";
                waitMsg = "저 급해서 그런데 빨리주세요!";
                exitMsg = "아니 안줄거면 처음부터 말을하던가";
                thankMsg = "주문 엄청 빠르시네여ㄷㄷ";
                wrongMsg = "아 이거 잘못주신거같은데;; 시간도 없는데";
                break;
            case 4:
                order = new string[] { "Oregano", "Beef", "Cheese", "Cheese", "Potato", "Ketchup", "Oregano" };
                orderMsg = "빵은 파마산오레가노에 소고기, 치즈 두 장, 매쉬드 포테이토, 케찹 줘요. 빵은 위아래로 다 주는거 알죠?";
                waitMsg = "지금보니 빵은 다른게 맛있을거같은데...";
                exitMsg = "주문 안받을거면 장사 왜하는겁니까?";
                thankMsg = "음.. 빵 안바꾸길 잘한거같네여";
                wrongMsg = "잘못주셨는데요?";
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
