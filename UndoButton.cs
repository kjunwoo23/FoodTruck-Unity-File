using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoButton : MonoBehaviour
{
    public static UndoButton instance;
    public EffectManager effect;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        effect = GameObject.Find("EffectManager").GetComponent<EffectManager>();
    }
    public void OnClickUndoButton()
    {
        StartCoroutine(SellButton.Destroy_Menus(null, GameObject.Find("IngredientStack")));
        effect.effectSounds[11].source.Play();
    }
}
