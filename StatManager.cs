using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Status<T>
{
    public GameObject obj;
    private T data;
    public Status<T> SetData(T val)
    {
        data = val;
        obj.GetComponent<Text>().text = "" + val;
        return this;
    }
    public Status<T> SetObj(GameObject val)
    {
        obj = val;
        return this;
    }
    public T GetData()
    {
        return data;
    }
}
public class StatManager : MonoBehaviour
{
    float tmp;
    public float timer = 0.0f;
    public float minute;
    public static StatManager instance;
    public Status<string> truckName;
    public Status<int> money;
    public Status<int> popular;
    public Status<int> date;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (InputName.instance != null)
            truckName = new Status<string>().SetObj(GameObject.Find("nameText")).SetData(InputName.instance.userName);
        money = new Status<int>().SetObj(GameObject.Find("moneyText")).SetData(10000);
        popular = new Status<int>().SetObj(GameObject.Find("popularText")).SetData(30);
        date = new Status<int>().SetObj(GameObject.Find("dateText")).SetData(1);
        Destroy(InputName.instance);
    }
    public void StatPlus(Status<int> stat, int val)
    {
        stat.SetData(stat.GetData() + val);
        if (stat.GetData() < 0)
        {
            stat.SetData(0);
            if (stat == popular)
                SceneManager.LoadScene("GameoverScene");
        }
    }

    public GameObject dateBar;
    public void DateManage()
    {
        timer += Time.deltaTime;
        if ((date.GetData() >= 1 && date.GetData() <= 3) || (date.GetData() >= 10 && date.GetData() <= 11))
        {
            dateBar.transform.localScale = new Vector3(timer / 80.0f, 1, 0);
            if (timer >= 80)
            {
                timer = 0;
                date.SetData(date.GetData() + 1);
            }
        }
        else if (date.GetData() == 7 || date.GetData() == 20)
        {
            dateBar.transform.localScale = new Vector3(timer / 150.0f, 1, 0);
            if (timer >= 150)
            {
                date.SetData(1 + date.GetData());
                timer = 0;
            }
        }
        else
        {
            dateBar.transform.localScale = new Vector3(timer / 125.0f, 1, 0);
            if (timer >= 125)
            {
                date.SetData(1 + date.GetData());
                timer = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.F9))
            timer += 1000;
    }

    private bool support = true;
    public GameObject SupportMsg;
    void Update()
    {
        DateManage();
        if (money.GetData() <= 2000)
        {
            if (support == true)
            {
                StatManager.instance.money.SetData(StatManager.instance.money.GetData() + 10000);
                StartCoroutine(Stack.ShowMessage(SupportMsg));
                support = false;
            }
            else
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
        GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
    
}
