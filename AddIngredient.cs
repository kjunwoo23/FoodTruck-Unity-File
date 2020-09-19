using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddIngredient : MonoBehaviour
{
    //메인메뉴의 재료 추가 메소드
    public bool IngredientSet(GameObject prefab)
    {
        SoundManager2.instance.PlayClickSound();
        if (Stack.instance.AddStack(prefab) == true)
        {
            prefab.transform.SetParent(GameObject.Find("IngredientStack").transform);
            prefab.transform.localPosition = new Vector3(0, 13.0f, 0);
            prefab.GetComponent<Rigidbody2D>().freezeRotation = true;
            return true;
        }
        else
        {
            Destroy(prefab);
            return false;
        }
    }
}
