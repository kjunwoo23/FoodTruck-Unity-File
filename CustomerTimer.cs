using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTimer : MonoBehaviour
{
    public CustomerParent customer;
    private void Start()
    {
    }
    private void Update()
    {
        if (customer.timer < customer.ExitTime)
            gameObject.transform.localScale = new Vector3(1 - customer.timer / customer.ExitTime, 1);
        if (gameObject.transform.localScale.x < 0)
            gameObject.transform.localScale = new Vector3(0, 1);
    }
}
