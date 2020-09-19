using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBeverage : MonoBehaviour
{
    public static AddBeverage instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject errorMessage;
    public GameObject coffee;
    public GameObject cider;
    public GameObject cola;
    public GameObject smoothie;
    public int CoffeeCost;
    public int CiderCost;
    public int ColaCost;
    public int SmoothieCost;

    public void OnClickCoffee()
    {
        if (StatManager.instance.money.GetData() < CoffeeCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        SoundManager2.instance.PlayClickSound();
        if (Stack.instance.beverage == null)
            EffectManager.instance.effectSounds[3].source.Play();
        Stack.instance.AddBeverage(Instantiate(coffee), CoffeeCost);
        
    }
    public void OnClickCider()
    {
        if (StatManager.instance.money.GetData() < CiderCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        SoundManager2.instance.PlayClickSound();
        if (Stack.instance.beverage == null)
            EffectManager.instance.effectSounds[4].source.Play();
        Stack.instance.AddBeverage(Instantiate(cider), CiderCost);
    }
    public void OnClickCola()
    {
        if (StatManager.instance.money.GetData() < ColaCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        SoundManager2.instance.PlayClickSound();
        if (Stack.instance.beverage == null)
            EffectManager.instance.effectSounds[4].source.Play();
        Stack.instance.AddBeverage(Instantiate(cola), ColaCost);
    }
    public void OnClickSmoothie()
    {
        if (StatManager.instance.money.GetData() < SmoothieCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        SoundManager2.instance.PlayClickSound();
        if (Stack.instance.beverage == null)
            EffectManager.instance.effectSounds[3].source.Play();
        Stack.instance.AddBeverage(Instantiate(smoothie), SmoothieCost);
    }
}
