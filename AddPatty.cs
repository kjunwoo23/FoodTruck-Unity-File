using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPatty : AddIngredient
{
    public static AddPatty instance;
    private void Awake()
    {
        instance = this;
    }

    //패티 프리팹
    public GameObject Beef;
    public GameObject Pork;
    public GameObject Chicken;
    public GameObject Egg;
    public GameObject Cheese;
    public GameObject Tuna;
    public int BeefCost;
    public int PorkCost;
    public int ChickenCost;
    public int EggCost;
    public int CheeseCost;
    public int TunaCost;

    public void OnClickBeefButton()
    {
        if (StatManager.instance.money.GetData() < BeefCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[1].source.Play();
        if (!IngredientSet(Instantiate(Beef)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -BeefCost);
    }
    public void OnClickPorkButton()
    {
        if (StatManager.instance.money.GetData() < PorkCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[1].source.Play();
        if (!IngredientSet(Instantiate(Pork)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -PorkCost);
    }
    public void OnClickChickenButton()
    {
        if (StatManager.instance.money.GetData() < ChickenCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[1].source.Play();
        if (!IngredientSet(Instantiate(Chicken)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -ChickenCost);
    }
    public void OnClickEggButton()
    {
        if (StatManager.instance.money.GetData() < EggCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[1].source.Play();
        if (!IngredientSet(Instantiate(Egg)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -EggCost);
    }
    public void OnClickCheeseButton()
    {
        if (StatManager.instance.money.GetData() < CheeseCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[1].source.Play();
        if (!IngredientSet(Instantiate(Cheese)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -CheeseCost);
    }
    public void OnClickTunaButton()
    {
        if (StatManager.instance.money.GetData() < TunaCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.stack.Count < 10)
            EffectManager.instance.effectSounds[1].source.Play();
        if (!IngredientSet(Instantiate(Tuna)))
            return;
        StatManager.instance.StatPlus(StatManager.instance.money, -TunaCost);
    }
}
