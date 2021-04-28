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
        if( goldvalue_text !=null)goldvalue_text.text = "you got  "+ gold.ToString() + " gold";
        if (item_recieved != null)
        {
            if (items.Count != 0) item_recieved.text = "you recieved" + items[items.Count - 1];
            if (items.Count == 0) item_recieved.text = "you recieved nothing";
        }
    }
}