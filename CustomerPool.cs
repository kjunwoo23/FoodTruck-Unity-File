using UnityEngine;

public class CustomerPool : MonoBehaviour
{
    class CustomerType
    {
        public enum HeadType
        {
            normal,
            special
        }
        public enum Normal
        {
            normalType1,
            normalType2,
            normalType3,
            normalType4,
            normalType5,
            normalType6,
            normalType7,
            normalType8,
            normalType9,
            normalType10
        }
        public enum NormalEx
        {
            normalType1,
            normalType2,
            normalType3,
            normalType4,
            normalType6,
            normalType7,
            normalType8,
            normalType10
        }
        public enum Special
        {
            vegeType,
            meatonlyType,
            nobreadType,
            breadonlyType,
            chickenonlyType,
            bigmacType,
            celebType,
            beggarType,
            groupType,
            drunkType
        }
        public enum SpecialEx
        {
            vegeType,
            meatonlyType,
            nobreadType,
            breadonlyType,
            chickenonlyType,
            bigmacType,
            beggarType,
            groupType
        }
    }

    //손님 종류마다 프리팹 나열
    public GameObject normal1;
    public GameObject normal2;
    public GameObject normal3;
    public GameObject normal4;
    public GameObject normal5;
    public GameObject normal6;
    public GameObject normal7;
    public GameObject normal8;
    public GameObject normal9;
    public GameObject normal10;
    public GameObject vege;
    public GameObject meatonly;
    public GameObject nobread;
    public GameObject breadonly;
    public GameObject chickenonly;
    public GameObject bigmac;
    public GameObject celeb;
    public GameObject beggar;
    public GameObject group;
    public GameObject drunk;

    public GameObject thief;
    public float spawnTimeThief = 20;
    public float thiefTimer = 0.0f;
    public GameObject[] thiefLine;
    private void Awake()
    {
        spawnTimeThief = 20.0f;
        thiefTimer = 0.0f;
        thiefLine = new GameObject[GameObject.Find("ThiefLine").transform.childCount];
        for (int i = 0; i < GameObject.Find("ThiefLine").transform.childCount; i++)
            thiefLine[i] = GameObject.Find("ThiefLine").transform.GetChild(i).gameObject;
    }

    public GameObject line1;
    public GameObject line2;
    public GameObject line3;

    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        return V;
    }

    CustomerType.HeadType GetRandomEnumHeadCutomerType()
    {
        CustomerType.HeadType type;
        float fRand = Random.Range(0.0f, 100.0f);
        if (fRand <= 30.0f)
        {
            type = CustomerType.HeadType.special;
        }
        else
        {
            type = CustomerType.HeadType.normal;
        }
        return type;
    }

    CustomerType.Normal GetRandomEnumNormalCustomerType()
    {
        return GetRandomEnum<CustomerType.Normal>();
    }

    CustomerType.Special GetRandomEnumSpecialCustomerType()
    {
        return GetRandomEnum<CustomerType.Special>();
    }

    void SpawnNormalCustomer(GameManager.customer customer)
    {
        CustomerType.Normal type = GetRandomEnumNormalCustomerType();
        if (StatManager.instance.date.GetData() >= 9 && StatManager.instance.date.GetData() <= 15)
        {
            if (type == CustomerType.Normal.normalType5 || type == CustomerType.Normal.normalType9)
            {
                SpawnNormalCustomer(customer);
                return;
            }
        }
        switch (type)
        {
            case CustomerType.Normal.normalType1: customer.obj = Instantiate(normal1); break;
            case CustomerType.Normal.normalType2: customer.obj = Instantiate(normal2); break;
            case CustomerType.Normal.normalType3: customer.obj = Instantiate(normal3); break;
            case CustomerType.Normal.normalType4: customer.obj = Instantiate(normal4); break;
            case CustomerType.Normal.normalType5: customer.obj = Instantiate(normal5); break;
            case CustomerType.Normal.normalType6: customer.obj = Instantiate(normal6); break;
            case CustomerType.Normal.normalType7: customer.obj = Instantiate(normal7); break;
            case CustomerType.Normal.normalType8: customer.obj = Instantiate(normal8); break;
            case CustomerType.Normal.normalType9: customer.obj = Instantiate(normal9); break;
            case CustomerType.Normal.normalType10: customer.obj = Instantiate(normal10); break;
        }
    }

    void SpawnSpecialCustomer(GameManager.customer customer)
    {
        CustomerType.Special type = GetRandomEnumSpecialCustomerType();
        if (StatManager.instance.date.GetData() >= 9 && StatManager.instance.date.GetData() <= 15)
        {
            if (type == CustomerType.Special.drunkType || type == CustomerType.Special.celebType)
            {
                SpawnSpecialCustomer(customer);
                return;
            }
        }
        switch (type)
        {
            case CustomerType.Special.vegeType: customer.obj = Instantiate(vege); break;
            case CustomerType.Special.meatonlyType: customer.obj = Instantiate(meatonly); break;
            case CustomerType.Special.nobreadType: customer.obj = Instantiate(nobread); break;
            case CustomerType.Special.breadonlyType: customer.obj = Instantiate(breadonly); break;
            case CustomerType.Special.chickenonlyType: customer.obj = Instantiate(chickenonly); break;
            case CustomerType.Special.bigmacType: customer.obj = Instantiate(bigmac); break;
            case CustomerType.Special.celebType: customer.obj = Instantiate(celeb); break;
            case CustomerType.Special.beggarType: customer.obj = Instantiate(beggar); break;
            case CustomerType.Special.groupType: customer.obj = Instantiate(group); break;
            case CustomerType.Special.drunkType: customer.obj = Instantiate(drunk); break;
        }
    }

    // 손님 생성 메소드
    public void Spawn_Customer(GameManager.customer customer, GameObject line)
    {
        if (customer.obj == null)
        {
            customer.timer += Time.deltaTime;
            if (customer.timer >= customer.spawnTime)
            {
                ResultManager.instance.metCustomer++;

                CustomerType.HeadType headType = GetRandomEnumHeadCutomerType();
                switch (headType)
                {
                    case CustomerType.HeadType.normal:
                        {
                            SpawnNormalCustomer(customer);
                            break;
                        }
                    case CustomerType.HeadType.special:
                        {
                            SpawnSpecialCustomer(customer);
                            break;
                        }
                }
                //지우지 말아주세요
                //customer.obj = Instantiate(drunk);
                customer.obj.transform.SetParent(line.transform);
                customer.obj.transform.localPosition = new Vector2(0, -55);
                if (customer.obj.name.Contains("Normal3"))
                {
                    customer.obj.transform.localPosition = new Vector2(0, -83);
                }
                customer.timer = 0;
                EffectManager.instance.effectSounds[12].source.Play();
            }
        }
    }

    void CustomnerSpawnDate()
    {
        int date = StatManager.instance.date.GetData();

        Spawn_Customer(GameManager.instance.customer2, line2);

        if (date >= 4 && date <= 8)
            Spawn_Customer(GameManager.instance.customer1, line1);

        if (date >= 7 && date <= 8)
            Spawn_Customer(GameManager.instance.customer3, line3);

        if (date >= 14 && date <= 15)
            Spawn_Customer(GameManager.instance.customer1, line1);

        if (date >= 17)
            Spawn_Customer(GameManager.instance.customer1, line1);

        if (date >= 18)
            Spawn_Customer(GameManager.instance.customer3, line3);
    }
    void SpawnThief()
    {
        thiefTimer += Time.deltaTime;
        if (thiefTimer >= spawnTimeThief)
        {
            thiefTimer = 0.0f;
            spawnTimeThief = Random.Range(40.0f, 80.0f);
            
            if (StatManager.instance.date.GetData() == 7 || StatManager.instance.date.GetData() == 8 || StatManager.instance.date.GetData() >= 18)
            {
                GameObject pref = Instantiate(thief);
                int rand = Random.Range(0, 3);
                if (thiefLine[rand].transform.childCount >= 1)
                {
                    Destroy(pref);
                    return;
                }
                pref.transform.position = thiefLine[rand].transform.position;
                pref.transform.SetParent(thiefLine[rand].transform);
                pref.transform.localPosition =  new Vector3(-50, -50, 0);
                pref.transform.localScale = new Vector3(1, 5);
            }
        }
    }

    private void Update()
    {
        CustomnerSpawnDate();
        SpawnThief();
        if (Input.GetKeyDown(KeyCode.F10))
        {
            Time.timeScale = 10.0f;
            StatManager.instance.popular.SetData(100);
        }
        if (Input.GetKeyDown(KeyCode.F11))
        {
            Time.timeScale = 1.0f;
        }
    }
}
