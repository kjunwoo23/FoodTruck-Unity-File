using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerParent : MonoBehaviour
{
    public enum Line
    {
        first,
        second,
        third
    }
    public enum OrderState
    {
        wrong,
        proper,
        yet
    }
    public string type; // 손님의 유형을 나타냄 (Normal, Vege 등등)
    public Text textbox; // 손님의 텍스트 박스
    public string orderMsg; // 주문을 보여주는 텍스트
    public string waitMsg; // 너무 기다려서 불평하는 텍스트
    public string exitMsg; // 기다리다가 나가버리는 텍스트
    public string thankMsg; // 옳은 주문을 받는 경우의 텍스트
    public string wrongMsg; // 잘못된 주문을 받는 경우의 텍스트
    public int plusPopular; // 옳은 주문 시 추가로 받게 되는 수치
    public int minPopular; // 틀린 주문 시 추가로 받게 되는 수치
    public Line line; // 어느 라인에 있는가를 저장해두는 변수
    public float timer; // 손님이 기다리는 동안의 타이머
    public int groupStack = 0; // 단체손님일 경우 손님 수 (아닐 경우 0)
    public string[] order;  // 실제로 주문 텍스트 (프리팹의 이름들을 순서대로 넣어주자)
    public string sideMenu1;
    public string sideMenu2;
    public string beverage;
    public int payment; // 올바른 주문 받는 경우 주는 돈 수치
    public OrderState orderState; // 주문을 받았는가 받았다면 옳은가 틀린가 알려주는 변수
    public float waitTime; // 기다리다가 텍스트가 바뀌는데 까지 걸리는 시간
    public float ExitTime; // 기다리다가 나가는 시간
   
    public void OnClickText()
    {
        if (textbox.text == orderMsg)
            return;
        if (textbox.text == waitMsg)
            waitMsg = orderMsg;
    }

    protected void SetTextBox()
    {// 꼭 하위 클래스에서 Update에서 이 함수를 실행할 것.
        textbox = gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        textbox.horizontalOverflow = HorizontalWrapMode.Wrap;
        textbox.verticalOverflow = VerticalWrapMode.Truncate;
        textbox.text = orderMsg;
    }

    protected IEnumerator ExceedWaitTime()
    {// 주문이 밀려 지나가는 경우를 의미함
        textbox.text = exitMsg;
        yield return new WaitForSecondsRealtime(1.0f);
        EffectManager.instance.effectSounds[5].source.Play();
        switch (line)
        {
            case Line.first: GameManager.instance.customer1.Destroy_data(); break;
            case Line.second: GameManager.instance.customer2.Destroy_data(); break;
            case Line.third: GameManager.instance.customer3.Destroy_data(); break;
        }
        StatManager.instance.StatPlus(StatManager.instance.popular, -minPopular);
        Destroy(this);
    }

    protected void ConditionSet()
    {// 손님의 상태를 시간에 따라 구현
        timer += Time.deltaTime;
        if (timer >= waitTime && timer < ExitTime && orderState == OrderState.yet)
        {
            textbox.text = waitMsg;
        }
        if (timer >= ExitTime && orderState == OrderState.yet)
        {
            if (orderState == OrderState.yet)
                StartCoroutine(ExceedWaitTime());
        }
    }

    protected void SetLine() // GameManager에 있는 customer의 CustomerParent 멤버 중 어느 라인 손님의 객체인지 알려주는 용도
    {
        SetTimer();
        switch (gameObject.transform.parent.name)
        {
            case "CustomerLine1":
                {
                    line = Line.first;
                    GameManager.instance.customer1.me = this;
                    break;
                }
            case "CustomerLine2":
                {
                    line = Line.second;
                    GameManager.instance.customer2.me = this;
                    break;
                }
            case "CustomerLine3":
                {
                    line = Line.third;
                    GameManager.instance.customer3.me = this;
                    break;
                }
        }
    }

    protected void SetTimer()
    {
        if (gameObject.transform.childCount > 1)
            gameObject.transform.GetChild(1).GetChild(0).GetComponent<CustomerTimer>().customer = (CustomerParent)this;
    }
}
