using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSource : AddIngredient
{
    public static AddSource instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject Mayo;
    public GameObject Ketchup;
    public GameObject Wrench;
    public GameObject Mustard;
    public GameObject Hotchili;
    public GameObject Salt;
    public GameObject Teriyaki;
    public int SourceCost;

    public void OnClickMayo()
    {
        if (StatManager.instance.money.GetData() < SourceCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[8].source.Play();
        if (!IngredientSet(Instantiate(Mayo)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -SourceCost);
    }
    public void OnClickKetchup()
    {
        if (StatManager.instance.money.GetData() < SourceCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[8].source.Play();
        if (!IngredientSet(Instantiate(Ketchup)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -SourceCost);
    }
    public void OnClickWrench()
    {
        if (StatManager.instance.money.GetData() < SourceCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[8].source.Play();
        if (!IngredientSet(Instantiate(Wrench)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -SourceCost);
    }
    public void OnClickHotchili()
    {
        if (StatManager.instance.money.GetData() < SourceCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[8].source.Play();
        if (!IngredientSet(Instantiate(Hotchili)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -SourceCost);
    }
    public void OnClickMustard()
    {
        if (StatManager.instance.money.GetData() < SourceCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[8].source.Play();
        if (!IngredientSet(Instantiate(Mustard)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -SourceCost);
    }
    public void OnClickSalt()
    {
        if (StatManager.instance.money.GetData() < SourceCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[8].source.Play();
        if (!IngredientSet(Instantiate(Salt)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -SourceCost);
    }

    public void OnClickTeriyaki()
    {
        if (StatManager.instance.money.GetData() < SourceCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[8].source.Play();
        if (!IngredientSet(Instantiate(Teriyaki)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -SourceCost);
    }
}
