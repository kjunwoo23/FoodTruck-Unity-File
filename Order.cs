using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    [System.Serializable]
    public class Dialogue
    {
        public string name;
        public int size;
        [TextArea(3, 10)]
        public string[] sentences;
    }
    public Dialogue dialogue;
    int i = 0;
    string line;

    void Start()
    {
        line = dialogue.sentences[i];
    }
    
    void Update()
    {
        GameObject.Find("order").GetComponent<Text>().text = line;
    }
}
