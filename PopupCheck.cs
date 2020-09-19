using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCheck : MonoBehaviour
{
    private void Update()
    {
        if (PopupMenuName.instance.hitname == gameObject.transform.name)
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        else gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
