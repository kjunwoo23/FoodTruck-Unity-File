using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MsgManager : MonoBehaviour
{
    public GameObject[] msg;
    public GameObject nameField;
    public GameObject msgField;
    public int page = 0;
    public bool msgNow = true;
    private void Awake()
    {
        msgField.SetActive(true);
        nameField.SetActive(false);
        msg = new GameObject[msgField.transform.childCount];
        for (int i = 0; i < msgField.transform.childCount; i++)
        {
            msg[i] = msgField.transform.GetChild(i).gameObject;
        }
        for (int i = 1; i < msgField.transform.childCount;i++)
        {
            msg[i].SetActive(false);
        }
        msg[0].SetActive(true);
    }

    public void OnClick()
    {
        msg[page].SetActive(false);
        if (page + 1 >= msgField.transform.childCount)
        {
            msgNow = false;
            nameField.SetActive(true);
            msgField.SetActive(false);
            return;
        }
        msg[++page].SetActive(true);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (msgNow == true)
            {
                msgNow = false;
                nameField.SetActive(true);
                msgField.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
            OnClick();
    }



}
