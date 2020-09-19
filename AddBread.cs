using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBread : AddIngredient
{
    public static AddBread instance;
    private void Awake()
    {
        instance = this;
    }
    //빵 프리팹
    public GameObject HoneyOatTop;
    public GameObject HoneyOatBottom;
    public Sprite HoneyOatMiddle;
    public GameObject OreganoTop;
    public GameObject OreganoBottom;
    public Sprite OreganoMiddle;
    public GameObject WhiteTop;
    public GameObject WhiteBottom;
    public Sprite WhiteMiddle;
    public GameObject FlatTop;
    public GameObject FlatBottom;
    public Sprite FlatMiddle;
    public GameObject WitTop;
    public GameObject WitBottom;
    public Sprite WitMiddle;
    public GameObject SesameTop;
    public GameObject SesameBottom;
    public Sprite SesameMiddle;
    public int BreadCost;

    //아래쪽 빵이 생성됐는지 확인
    public bool FindBottom()
    {
        if (GameObject.Find("HoneyOatBottom(Clone)") == true) return false;
        else if (GameObject.Find("OreganoBottom(Clone)") == true) return false;
        else if (GameObject.Find("WhiteBottom(Clone)") == true) return false;
        else if (GameObject.Find("FlatBottom(Clone)") == true) return false;
        else if (GameObject.Find("WitBottom(Clone)") == true) return false;
        else if (GameObject.Find("SesameBottom(Clone)") == true) return false;

        return true;
    }

    //중간에 빵이 생성됐는지 확인
    public void FindTop()
    {
        if (GameObject.Find("HoneyOatTop(Clone)") == true)
        {
            GameObject Middle = GameObject.Find("HoneyOatTop(Clone)");
            Middle.GetComponent<SpriteRenderer>().sprite = HoneyOatMiddle;
            Middle.name = "HoneyOatMiddle(Clone)";
        }
        else if (GameObject.Find("OreganoTop(Clone)") == true)
        {
            GameObject Middle = GameObject.Find("OreganoTop(Clone)");
            Middle.GetComponent<SpriteRenderer>().sprite = OreganoMiddle;
            Middle.name = "OreganoMiddle(Clone)";
        }
        else if (GameObject.Find("WhiteTop(Clone)") == true)
        {
            GameObject Middle = GameObject.Find("WhiteTop(Clone)");
            Middle.GetComponent<SpriteRenderer>().sprite = WhiteMiddle;
            Middle.name = "WhiteMiddle(Clone)";
        }
        else if (GameObject.Find("FlatTop(Clone)") == true)
        {
            GameObject Middle = GameObject.Find("FlatTop(Clone)");
            Middle.GetComponent<SpriteRenderer>().sprite = FlatMiddle;
            Middle.GetComponent<BoxCollider2D>().size = new Vector2(8.2f, 0.45f);
            Middle.name = "FlatMiddle(Clone)";
        }
        else if (GameObject.Find("WitTop(Clone)") == true)
        {
            GameObject Middle = GameObject.Find("WitTop(Clone)");
            Middle.GetComponent<SpriteRenderer>().sprite = WitMiddle;
            Middle.name = "WitMiddle(Clone)";
        }
        else if (GameObject.Find("SesameTop(Clone)") == true)
        {
            GameObject Middle = GameObject.Find("SesameTop(Clone)");
            Middle.GetComponent<SpriteRenderer>().sprite = SesameMiddle;
            Middle.name = "SesameMiddle(Clone)";
        }
    }

    public void OnClickHoneyOatButton()
    {
        if (Stack.instance.stack.Count < 10)
        {
            EffectManager.instance.effectSounds[0].source.Play();

            if (StatManager.instance.money.GetData() < BreadCost)
            {
                EffectManager.instance.effectSounds[9].source.Play();
                return;
            }

            if (FindBottom())
            {
                if (!IngredientSet(Instantiate(HoneyOatBottom)))
                    return;
            }
            else
            {
                FindTop();
                if (!IngredientSet(Instantiate(HoneyOatTop)))
                    return;
            }

            StatManager.instance.StatPlus(StatManager.instance.money, -BreadCost);
        }

        
    }

    public void OnClickOregano()
    {
        if (Stack.instance.stack.Count < 10)
        {
            EffectManager.instance.effectSounds[0].source.Play();

            if (StatManager.instance.money.GetData() < BreadCost)
            {
                EffectManager.instance.effectSounds[9].source.Play();
                return;
            }

            if (FindBottom())
            {
                if (!IngredientSet(Instantiate(OreganoBottom)))
                    return;
            }
            else
            {
                FindTop();
                if (!IngredientSet(Instantiate(OreganoTop)))
                    return;
            }

            StatManager.instance.StatPlus(StatManager.instance.money, -BreadCost);
        }

        
    }

    public void OnClickWhite()
    {
        if (Stack.instance.stack.Count < 10)
        {
            EffectManager.instance.effectSounds[0].source.Play();

            if (StatManager.instance.money.GetData() < BreadCost)
            {
                EffectManager.instance.effectSounds[9].source.Play();
                return;
            }

            if (FindBottom())
            {
                if (!IngredientSet(Instantiate(WhiteBottom)))
                    return;
            }
            else
            {
                FindTop();
                if (!IngredientSet(Instantiate(WhiteTop)))
                    return;
            }

            StatManager.instance.StatPlus(StatManager.instance.money, -BreadCost);
        }
    }

    public void OnClickWit()
    {
        if (Stack.instance.stack.Count < 10)
        {
            EffectManager.instance.effectSounds[0].source.Play();

            if (StatManager.instance.money.GetData() < BreadCost)
            {
                EffectManager.instance.effectSounds[9].source.Play();
                return;
            }

            if (FindBottom())
            {
                if (!IngredientSet(Instantiate(WitBottom)))
                    return;
            }
            else
            {
                FindTop();
                if (!IngredientSet(Instantiate(WitTop)))
                    return;
            }

            StatManager.instance.StatPlus(StatManager.instance.money, -BreadCost);
        }
    }

    public void OnClickSesame()
    {
        if (Stack.instance.stack.Count < 10)
        {
            EffectManager.instance.effectSounds[0].source.Play();

            if (StatManager.instance.money.GetData() < BreadCost)
            {
                EffectManager.instance.effectSounds[9].source.Play();
                return;
            }

            if (FindBottom())
            {
                if (!IngredientSet(Instantiate(SesameBottom)))
                    return;
            }
            else
            {
                FindTop();
                if (!IngredientSet(Instantiate(SesameTop)))
                    return;
            }

            StatManager.instance.StatPlus(StatManager.instance.money, -BreadCost);
        }
    }

    public void OnClickFlat()
    {
        if (Stack.instance.stack.Count < 10)
        {
            EffectManager.instance.effectSounds[0].source.Play();

            if (StatManager.instance.money.GetData() < BreadCost)
            {
                EffectManager.instance.effectSounds[9].source.Play();
                return;
            }

            if (FindBottom())
            {
                if (!IngredientSet(Instantiate(FlatBottom)))
                    return;
            }
            else
            {
                FindTop();
                if (!IngredientSet(Instantiate(FlatTop)))
                    return;
            }

            StatManager.instance.StatPlus(StatManager.instance.money, -BreadCost);
        }
        }
}
