using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] Menus;
    public GameObject SettingMenu;
    public class customer
    {
        public GameObject obj;
        public float spawnTime;
        public float timer;
        public CustomerParent me;
        public customer()
        {
            timer = 0.0f;
            spawnTime = Random.Range(3.0f, 5.0f);
        }
        public void Destroy_data()
        {
            timer = 0.0f;
            spawnTime = Random.Range(1.0f, 6.0f);
            Destroy(obj);
        }
    }
    public customer customer1;
    public customer customer2;
    public customer customer3;

    public void ActiveMenu(string name)
    {
        foreach (GameObject tmp in Menus)
        {
            if (tmp.gameObject.name == name)
                tmp.SetActive(true);
            else tmp.SetActive(false);
        }
    }
    private void Awake()
    {
        instance = this;
        Menus = GameObject.FindGameObjectsWithTag("Menu");
        ActiveMenu("Main");
        customer1 = new customer();
        customer2 = new customer();
        customer3 = new customer();
        SettingMenu.SetActive(false);
    }

    void Start()
    {
    }

    void Update()
    {
        
    }
}
