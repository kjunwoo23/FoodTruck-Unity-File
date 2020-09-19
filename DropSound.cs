using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSound : MonoBehaviour
{
    public EffectManager effect;
    void Start()
    {
        effect = GameObject.Find("EffectManager").GetComponent<EffectManager>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Contents")
            effect.effectSounds[10].source.Play();
    }
}
