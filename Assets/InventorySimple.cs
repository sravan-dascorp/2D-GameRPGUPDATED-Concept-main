using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySimple : MonoBehaviour
{
    public static List<string> items = new List<string>();
    public static float gold;


    public Text goldvalue_text;
    public Text item_recieved;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        goldvalue_text.text = gold.ToString();
        if (items.Count != 0) item_recieved.text = "you recieved" + items[items.Count - 1];
        if (items.Count == 0) item_recieved.text = "you recieved nothing";
    }
}