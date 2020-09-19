using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVegetable : AddIngredient
{
    public static AddVegetable instance;

    private void Awake()
    {
        instance = this;
    }

    //야채 프리팹
    public GameObject Potato;
    public GameObject Lettuce;
    public GameObject Tomato;
    public GameObject Pickle;
    public GameObject Cucumber;
    public GameObject Pepper;
    public int PotatoCost;
    public int LettuceCost;
    public int TomatoCost;
    public int PickleCost;
    public int CucumberCost;
    public int PepperCost;

    public void OnClickPotato()
    {
        if (StatManager.instance.money.GetData() < PotatoCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[2].source.Play();
        if (!IngredientSet(Instantiate(Potato)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -PotatoCost);
    }
    public void OnClickLettuce()
    {
        if (StatManager.instance.money.GetData() < LettuceCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[2].source.Play();
        if (!IngredientSet(Instantiate(Lettuce)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -LettuceCost);
    }
    public void OnClickTomato()
    {
        if (StatManager.instance.money.GetData() < TomatoCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[2].source.Play();
        if (!IngredientSet(Instantiate(Tomato)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -TomatoCost);
    }
    public void OnClickPickle()
    {
        if (StatManager.instance.money.GetData() < PickleCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[2].source.Play();
        if (!IngredientSet(Instantiate(Pickle)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -PickleCost);
    }
    public void OnClickCucumber()
    {
        if (StatManager.instance.money.GetData() < CucumberCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[2].source.Play();
        if (!IngredientSet(Instantiate(Cucumber)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -CucumberCost);
    }
    public void OnClickPepper()
    {
        if (StatManager.instance.money.GetData() < PepperCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[2].source.Play();
        if (!IngredientSet(Instantiate(Pepper)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -PepperCost);
    }
}
