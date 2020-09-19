using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beggar : CustomerParent
{
    //손님 이름 거지 아니고 양아치로 수정
    //코드 상에서는 Beggar로 유지
    private void Awake()
    {
        type = "Normal";
        orderState = OrderState.yet;
        timer = 0;
        payment = 0;
        plusPopular = 3;
        minPopular = 6;
        orderState = OrderState.yet;
        ExitTime = 60.0f;
        waitTime = 20.0f;
        GetOrder();

        SetTextBox();
    }

    private void GetOrder()
    {

        int rand = (int)Random.Range(0.0f, 2.0f);
        switch (rand)
        {
            case 0:
                order = new string[] { "Sesame", "Pork", "Teriyaki", "Sesame" };
                orderMsg = "쓰읍... 배가 고파서 그런데 참깨빵 하고 돼지고기 패티에 데리야끼소스 올려서 간단하게 하나 해봐요";
                waitMsg = "돈은 없는데. 괜찮죠?";
                exitMsg = "안주셔도 괜찮아요.. 내가 굶으면 되는거죠 그쵸?";
                thankMsg = "정말! 감사합니다!!";
                wrongMsg = "음식물 쓰레기를 먹으라는건가요?";
                break;
            case 1:
                order = new string[] { "White", "Beef", "Pork", "Tomato", "Wrench", "White" };
                orderMsg = "거 빵은 화이트로 소고기랑 돼지고기,토마토 올리고 랜치소스 뿌려서 줘바";
                waitMsg = "나때는 서로 나누며 살았다 이말이야~";
                exitMsg = "어린노무자슥이 그깟거 얼마한다고 유세떨어?!";
                thankMsg = "거 다음에 한번더 맛보러오지";
                wrongMsg = "쯧... 음식가지고 장난치는거 아니야";
                break;
            case 2:
                order = new string[] { "Oregano", "Egg", "Lettuce", "Ketchup", "Oregano" };
                orderMsg = "저기! 빵은 파마산오레가노에 계란위에 양상추랑 케찹뿌려서 주세요!";
                waitMsg = "언제쯤 되나요?";
                exitMsg = "지금 장난하나요? 장사망하고 싶으시나";
                thankMsg = "돈은 가불로 할께요!";
                wrongMsg = "아니 그런식으로 장사하지 마세요.";
                break;
        }
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
