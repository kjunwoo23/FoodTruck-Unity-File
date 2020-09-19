using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public static Stack instance;
    public List<GameObject> stack;
    public GameObject beverage;
    public List<GameObject> sideMenu;
    public GameObject errorMessageMain;
    public GameObject errorMessageSide;
    public GameObject errorMessageBeverage;
    Coroutine msgMain;
    Coroutine msgSide;
    Coroutine msgBeverage;
    public EffectManager effect;
    private void Awake()
    {
        effect = GameObject.Find("EffectManager").GetComponent<EffectManager>();
        errorMessageMain.SetActive(false);
        errorMessageSide.SetActive(false);
        errorMessageBeverage.SetActive(false);
        instance = this;
    }
    public bool AddStack(GameObject prefab)
    {
        if (stack.Count >= 10)
        {
            if (msgMain != null)
                StopCoroutine(msgMain);
            if (msgSide != null)
                StopCoroutine(msgSide);
            msgMain = StartCoroutine(ShowMessage(errorMessageMain));
            return false;
        }
        stack.Add(prefab);
        return true;
    }
    public void AddSideMenu(GameObject prefab, int cost)
    {
        if (sideMenu.Count >= 2)
        {
            if (msgMain != null)
                StopCoroutine(msgMain);
            if (msgSide != null)
                StopCoroutine(msgSide);
            msgSide = StartCoroutine(ShowMessage(errorMessageSide));
            Destroy(prefab);
            return;
        }
        else StatManager.instance.StatPlus(StatManager.instance.money, -cost);
        prefab.transform.parent = GameObject.Find("SideMenuField" + (sideMenu.Count + 1)).transform;
        prefab.transform.localPosition = new Vector3(0, 0, 0);
        sideMenu.Add(prefab);
    }
    public void AddBeverage(GameObject prefab, int cost)
    {
        if (beverage != null)
        {
            if (msgBeverage != null)
                StopCoroutine(msgBeverage);
            msgBeverage = StartCoroutine(ShowMessage(errorMessageBeverage));
            Destroy(prefab);
            return;
        }
        else StatManager.instance.StatPlus(StatManager.instance.money, -cost);
        prefab.transform.parent = GameObject.Find("BeverageField").transform;
        prefab.transform.localPosition = new Vector3(0, 0, 0);
        beverage = prefab;
    }
    public static IEnumerator ShowMessage(GameObject errorMessage)
    {
        EffectManager.instance.effectSounds[9].source.Play();
        errorMessage.SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);
        errorMessage.SetActive(false);
    }
}
