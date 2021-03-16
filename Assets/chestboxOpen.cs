using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestboxOpen : MonoBehaviour
{
    string teststring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Booltrigger>().execute)
        {
            this.gameObject.GetComponent<Animator>().enabled = true;
        }
        
        
    }
}
