using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float destroyinsec;
    private void Start()
    {
        Destroy(this.gameObject, destroyinsec);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.transform.tag == "player")
        {
            Destroy(this.gameObject);
            //add health damage for player
        }
        if (collision.collider != null)
        {
            Destroy(this.gameObject);
        }
    }
}
