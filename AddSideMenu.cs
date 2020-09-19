using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSideMenu : MonoBehaviour
{
    public static AddSideMenu instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject friedPotato;
    public GameObject soup;
    public GameObject nugget;
    public GameObject cookie;
    public int FriedPotatoCost;
    public int SoupCost;
    public int NuggetCost;
    public int CookieCost;
    
    public void OnClickFriedPotato()
    {
        if (StatManager.instance.money.GetData() < FriedPotatoCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.sideMenu.Count < 2)
            EffectManager.instance.effectSounds[7].source.Play();
        SoundManager2.instance.PlayClickSound();
        Stack.instance.AddSideMenu(Instantiate(friedPotato), FriedPotatoCost);
    }
    public void OnClickSoup()
    {
        if (StatManager.instance.money.GetData() < SoupCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.sideMenu.Count < 2)
            EffectManager.instance.effectSounds[7].source.Play();
        SoundManager2.instance.PlayClickSound();
        Stack.instance.AddSideMenu(Instantiate(soup), SoupCost);
    }
    public void OnClickNugget()
    {
        if (StatManager.instance.money.GetData() < NuggetCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.sideMenu.Count < 2)
            EffectManager.instance.effectSounds[7].source.Play();
        SoundManager2.instance.PlayClickSound();
        Stack.instance.AddSideMenu(Instantiate(nugget), NuggetCost);
    }
    public void OnClickCookie()
    {
        if (StatManager.instance.money.GetData() < CookieCost)
        {
            EffectManager.instance.effectSounds[9].source.Play();
            return;
        }
        if (Stack.instance.sideMenu.Count < 2)
            EffectManager.instance.effectSounds[7].source.Play();
        SoundManager2.instance.PlayClickSound();
        Stack.instance.AddSideMenu(Instantiate(cookie), CookieCost);
    }
}
