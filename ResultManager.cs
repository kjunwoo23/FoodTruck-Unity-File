using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public static ResultManager instance;
    public Text moneyText;
    public Text customerText;
    public int preMoney;
    public int metCustomer;
    public Text TipText;
    public List<string> Tips;
    public GameObject main;
    public GameObject Story;
    public GameObject[] story;
    public AudioSource bgsSource;
    public AudioSource bgmSource;
    public EffectManager bgs;
    public BgmManager bgm;
    public GameObject backgroundChange;
    public RawImage panel;
    float time = 0f;
    float F_time = 1f;

    public enum ResultOnOff
    {
        on,
        off
    }
    public enum StoryOnOff
    {
        on,
        off
    }
    public StoryOnOff playStory;
    public int page;

    public ResultOnOff now;

    public GameObject resultMsg;

    public int date;

    private void Awake()
    {
        instance = this;
        Tips.Add("숫자키와 백스페이스키를 이용하여 재료를 선택하실 수 있습니다.");
        Tips.Add("특수손님 중 연예인은 재료를 많이 요구하지만, 인기도를 많이 획득할 수 있습니다.");
        Tips.Add("플레이 중 손님 뒤에 나오는 도둑은 마우스 클릭 다섯 번으로 퇴치할 수 있습니다.");
        Tips.Add("플레이 중 도둑을 퇴치하지않으면, 쌓아놓은 재료 혹은 돈 일부를 가져갑니다.");
        Tips.Add("특수손님 중 양아치는 햄버거 판매 시 돈을 획득할 수 없습니다.");
        Tips.Add("특수손님 중 단체손님은 같은 종류의 햄버거를 여러개 만들어 줘야합니다.");
        Tips.Add("특수손님 중 취객은 일부 재료를 말하지 않습니다.");
        Tips.Add("후반에 갈수록 나오는 손님이 증가하므로 초반에 인기도와 돈을 많이 획득하는 것이 중요합니다.");
        Tips.Add("저장기능이 없으니 게임종료 시에 주의하십시오.");
        Tips.Add("소지금이 2000이하가 될 시 최초 1회에 한하여 지원금이 지급됩니다.");
        Tips.Add("뒤에 나오는 배경화면은 실제 세종대를 배경으로 제작되었습니다.");
        Tips.Add("플레이 중 도둑을 퇴치하지않으면, 쌓아놓은 재료 혹은 돈의 일부를 가져갑니다.");
        Tips.Add("손님이 하는 주문을 꼭 끝까지 들으세요!");
        Tips.Add("저장기능이 없는 대신 ESC로 스토리 스킵, F9으로 일차 스킵이 가능합니다. 1회차 땐 쓰지마세요!");
        Tips.Add("대사가 넘어가 주문이 안보인다면, 말풍선을 눌러보세요.");
        Tips.Add("숫자 0번키로 쌓아놓은 재료를 전부 지울 수 있습니다.");
        Tips.Add("장사는 사장 맘대로 하는게 아닙니다!");
        Tips.Add("재료는 꼭! 순서에 맞춰서 쌓으세요!");
        Tips.Add("참깨빵 위에 순쇠고기 패티 두 장 특별한 소스에 양상추, 치즈피클 양파까아지 빠랍빱빱빱!");
    }

    private void Start()
    {
        now = ResultOnOff.off;
        playStory = StoryOnOff.off;
        preMoney = 10000;
        story = new GameObject[Story.transform.childCount];
        for (int i = 0; i < Story.transform.childCount; i++)
            story[i] = Story.transform.GetChild(i).gameObject;
        for (int i = 0; i < story.Length; i++)
            story[i].SetActive(false);
        resultMsg.SetActive(false);
        date = 0;
    }

    public void OnClickContinueButton()
    {
        if (!(9 <= date && date <= 15 || 25 <= date && date <= 26))
        {
            if (bgmSource.clip != bgm.bgmSounds[3].clip)
            {
                bgmSource.clip = bgm.bgmSounds[3].clip;
                bgsSource.Stop();
                bgmSource.Play();
            }
        }
        if (date == 3)
            if (bgsSource.clip != bgs.bgsSounds[3].clip)
            {
                bgsSource.clip = bgs.bgsSounds[3].clip;
                bgmSource.Stop();
                bgsSource.Play();
            }
        if (date == 6)
        {
            bgmSource.Stop();
            bgsSource.Stop();
        }
        if (date == 7 || date == 8)
        {
            bgmSource.time = 0;
        }
        if (date == 9)
        {
            if (bgsSource.clip != bgs.bgsSounds[3].clip)
            {
                bgsSource.clip = bgs.bgsSounds[3].clip;
                bgsSource.Play();
            }
            bgmSource.clip = bgm.bgmSounds[4].clip;
            bgmSource.Stop();
        }
        if (date == 11)
        {
            bgsSource.Pause();
        }
        if (date == 17)
        {
            bgmSource.Stop();
            bgsSource.Stop();
        }
        if (date == 20 || date == 21)
        {
            bgmSource.time = 0;
        }
        if (date == 27)
        {
            bgmSource.clip = bgm.bgmSounds[7].clip;
            bgsSource.Stop();
            bgmSource.volume *= 2;
            bgmSource.Play();
        }
        now = ResultOnOff.off;
        resultMsg.SetActive(false);
        page = 1;
        ShowStoryPage();
    }

    public void ShowStoryPage()
    {
        if (date-1 >= story.Length)
        {
            main.SetActive(true);
            GameObject tmp = GameObject.Find("ErrorMessages");
            for (int i = 0; i < tmp.transform.childCount; i++)
            {
                tmp.transform.GetChild(i).gameObject.SetActive(false);
            }
            playStory = StoryOnOff.off;
            Time.timeScale = 1.0f;
            backgroundChange.SetActive(true);
            return;
        }
        playStory = StoryOnOff.on;
        story[date - 1].SetActive(true);
        for (int i = 0; i < story[date - 1].transform.childCount; i++)
            story[date - 1].transform.GetChild(i).gameObject.SetActive(false);
        story[date - 1].transform.GetChild(0).gameObject.SetActive(true);
        
    }

    void EndPage()
    {
        Fade();
        if (date - 1 >= 26)
        {
            SceneManager.LoadScene("StartScene");
            return;
        }
        story[date - 1].SetActive(false);
        main.SetActive(true);
        GameObject tmp1 = GameObject.Find("ThiefLine1");
        GameObject tmp2 = GameObject.Find("ThiefLine2");
        GameObject tmp3 = GameObject.Find("ThiefLine3");
        for (int i = 0; i < tmp1.transform.childCount; i++)
            Destroy(tmp1.transform.GetChild(0).gameObject);
        for (int i = 0; i < tmp2.transform.childCount; i++)
            Destroy(tmp2.transform.GetChild(0).gameObject);
        for (int i = 0; i < tmp3.transform.childCount; i++)
            Destroy(tmp3.transform.GetChild(0).gameObject);
        GameObject tmp = GameObject.Find("ErrorMessages");
        for (int i = 0; i < tmp.transform.childCount; i++)
        {
            tmp.transform.GetChild(i).gameObject.SetActive(false);
        }
        playStory = StoryOnOff.off;
        Time.timeScale = 1.0f;
        backgroundChange.SetActive(true);
        if (!bgmSource.isPlaying)
            bgmSource.Play();
        if (date != 14 && date != 15)
            if (!bgsSource.isPlaying)
                bgsSource.Play();
        return;
    }
    

    public void NextPage()
    {
        if (playStory == StoryOnOff.off)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            if (page >= story[date - 1].transform.childCount)
            {
                EndPage();
                return;
            }
            story[date - 1].transform.GetChild(page - 1).gameObject.SetActive(false);
            story[date - 1].transform.GetChild(page).gameObject.SetActive(true);
            if (date == 9 && page == 49)
                bgmSource.Play();
            if (date == 11 && page == 14)
            {
                bgsSource.UnPause();
            }
            if (date == 25 && page == 22)
            {
                bgmSource.Play();
            }
            page++;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndPage();
        }
    }


    public void ShowMsg()
    {
        if (now == ResultOnOff.on)
            return;
        if (GameObject.Find("IngredientStack") != null)
            StartCoroutine(SellButton.Destroy_Menus(null, GameObject.Find("IngredientStack")));
        Destroy(GameManager.instance.customer1.obj);
        Destroy(GameManager.instance.customer2.obj);
        Destroy(GameManager.instance.customer3.obj);
        main.SetActive(false);
        Time.timeScale = 0.0f;
        bgs.effectSounds[14].source.Play();
        backgroundChange.SetActive(false);
        if (!(9 <= date && date <= 15 || date == 26))
        {
            bgmSource.Stop();
            bgsSource.Stop();
        }
        if (date == 1)
        {
            OnClickContinueButton();
            return;
        }
        resultMsg.SetActive(true);

        TipText.text = Tips[(int)Random.Range(0.0f, Tips.Count)];

        moneyText.text = (StatManager.instance.money.GetData() - preMoney) + "원";
        preMoney = StatManager.instance.money.GetData();

        customerText.text = metCustomer + "명";
        metCustomer = 0;

        GameManager.instance.customer1.timer = GameManager.instance.customer2.timer = GameManager.instance.customer3.timer = 0.0f;
        now = ResultOnOff.on;
    }
    private void Update()
    {
        if (date == (int)StatManager.instance.date.GetData())
            now = ResultOnOff.off;
        else if (now == ResultOnOff.off)
        {
            GameObject tmp1 = GameObject.Find("ThiefLine1");
            GameObject tmp2 = GameObject.Find("ThiefLine2");
            GameObject tmp3 = GameObject.Find("ThiefLine3");
            for (int i = 0; i < tmp1.transform.childCount; i++)
                Destroy(tmp1.transform.GetChild(0).gameObject);
            for (int i = 0; i < tmp2.transform.childCount; i++)
                Destroy(tmp2.transform.GetChild(0).gameObject);
            for (int i = 0; i < tmp3.transform.childCount; i++)
                Destroy(tmp3.transform.GetChild(0).gameObject);
            date = StatManager.instance.date.GetData();
            ShowMsg();
            now = ResultOnOff.on;
        }
        NextPage();
    }


    public void Fade()
    {
        time = 0;
        panel.gameObject.SetActive(true);
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        Color alpha = panel.color;
        /*while (alpha.a < 1f) //페이드 아웃
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
        }*/
        alpha.a = 1f;
        panel.color = alpha;
        time = 0;
        if (Input.GetKeyDown(KeyCode.F9))
        {
            alpha.a = 0;
            panel.color = alpha;
            panel.gameObject.SetActive(false);
            yield return null;
        }
        //yield return new WaitForSeconds(0.1f);
        while (alpha.a > 0f) //페이드 인
        {
            if (Input.GetKeyDown(KeyCode.F9))
            {
                alpha.a = 0;
                panel.color = alpha;
                break;
            }
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            panel.color = alpha;
            yield return null;
        }
        panel.gameObject.SetActive(false);
        yield return null;
    }
}
