using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    public Dictionary <string, int> cost;
    // Start is called before the first frame update
    void Start()
    {
        cost = new Dictionary<string, int>();

        cost.Add("HoneyOat", 400);
        cost.Add("Oregano", 400);
        cost.Add("Flat", 400);
        cost.Add("White", 400);
        cost.Add("Wit", 400);
        cost.Add("Sesame", 400);

        cost.Add("Beef", 800);
        cost.Add("Pork", 700);
        cost.Add("Chicken", 600);
        cost.Add("Egg", 300);
        cost.Add("Cheese", 300);
        cost.Add("Tuna", 300);

        cost.Add("Potato", 270);
        cost.Add("Lettuce", 270);
        cost.Add("Tomato", 320);
        cost.Add("Pickle", 380);
        cost.Add("Cucumber", 370);
        cost.Add("Pepper", 390);

        cost.Add("Mayo", 200);
        cost.Add("Ketchup", 200);
        cost.Add("Wrench", 200);
        cost.Add("Mustard", 200);
        cost.Add("HotChili", 200);
        cost.Add("Salt", 200);
        cost.Add("Teriyaki", 200);

        cost.Add("FriedPotato", 1200);
        cost.Add("Soup", 500);
        cost.Add("Nugget", 1500);
        cost.Add("Cookie", 1000);

        cost.Add("Coffee", 1500);
        cost.Add("Cider", 1000);
        cost.Add("Cola", 1000);
        cost.Add("Smoothie", 1700);
    }

}
