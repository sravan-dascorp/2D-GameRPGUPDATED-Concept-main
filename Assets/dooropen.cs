using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour
{
    // Start is called before the first frame update
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponent<Booltrigger>().execute)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
