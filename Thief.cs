using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thief : MonoBehaviour
{
    private int cnt = 5;
    private float timer = 0.0f;

    public BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    public void OnClickThief()
    {
        cnt--;
        if (cnt == 4) EffectManager.instance.effectSounds[15].source.Play();
        else if (cnt == 3) EffectManager.instance.effectSounds[16].source.Play();
        else if (cnt == 2) EffectManager.instance.effectSounds[15].source.Play();
        else if (cnt == 1) EffectManager.instance.effectSounds[16].source.Play();
        else if (cnt == 0) EffectManager.instance.effectSounds[17].source.Play();
        if (cnt == 0)
            Destroy(gameObject);
    }
    private void ActThief()
    {
        int case_ = (int)Random.Range(1.0f, 3.0f);
        EffectManager.instance.effectSounds[18].source.Play();
        case_ = 2;
        if (case_ == 1)
            StatManager.instance.money.SetData(StatManager.instance.money.GetData() - (int)Random.Range(1000.0f, 5000.0f));
        else if (case_ == 2)
        {
            Transform stack = GameObject.Find("IngredientStack").transform;
            if (Stack.instance.stack.Count >= 1)
            {
                Stack.instance.stack.RemoveAt(Stack.instance.stack.Count - 1);
                Destroy(stack.GetChild(stack.childCount - 1).gameObject);
            }
            else StatManager.instance.money.SetData(StatManager.instance.money.GetData() - (int)Random.Range(1000.0f, 5000.0f));
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Input.mousePosition;
            Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            point = cam.ScreenToWorldPoint(point);

            RaycastHit2D hit = Physics2D.Raycast(point, cam.transform.forward, 10);
            if (hit)
            {
                if (hit.transform.gameObject == gameObject)
                    OnClickThief();
            }
        }

        if (timer >= 10)
            ActThief();
    }
}
