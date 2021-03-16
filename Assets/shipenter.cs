using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipenter : MonoBehaviour
{
    public Animator shipanimator;
    public Transform player;
    public Transform ship;
    public Transform landingport;
    public static int shipstate;
    float time=0;

    // Start is called before the first frame update
    void Start()
    {
        shipstate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (shipstate)
        {
            case  1:
                player.transform.GetComponent<SpriteRenderer>().enabled = false;
                player.position = ship.position;
                shipanimator.SetBool("moveship", true);
                break;
            case  2:
                
                time = time +   1* Time.deltaTime;
                Debug.Log(time);
                if (time >= 3f)
                {   
                    player.position = landingport.position;
                    player.transform.GetComponent<SpriteRenderer>().enabled = true;

                    shipstate = 3;
                }
                
                break;
            case 3:
                this.gameObject.GetComponent<shipenter>().enabled = false;
                break;


        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yuo,working bro");
        if (collision.tag == "Player") { Debug.Log("on ship enter"); ;
            shipenter.shipstate = 1; }
                
        
    }
}
