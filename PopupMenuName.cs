using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMenuName : MonoBehaviour
{
    public static PopupMenuName instance;
    public string hitname;
    public Camera cam;
    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        Vector3 point = Input.mousePosition;
        point = cam.ScreenToWorldPoint(point);

        RaycastHit2D hit = Physics2D.Raycast(point, cam.transform.forward, 10);
        if (hit)
        {
            hitname = hit.transform.name;
        }
        else hitname = null;
    }
}
