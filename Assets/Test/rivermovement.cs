using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rivermovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float distance;
    [SerializeField] private Vector2 axis;
    [SerializeField] private float speed=2;
    private float startpos;
    private bool onobject;
    public GameObject player;
    void Start()
    {
        if (axis.x == 1)
        {
            startpos = transform.position.x * axis.x;
        }
        if (axis.y == 1)
        {
            startpos = transform.position.y * axis.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (onobject)
        {
           player.transform.parent  = this.gameObject.transform;

        }
        else
        {
            player.transform.parent = null;
        }
    }
    void movement()
    {
        if (axis.x == 1)
        {
            float x = startpos + distance;
            Vector3 pos = new Vector3(x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            if(transform.position == pos)
            {
                transform.position= new Vector3(startpos,transform.position.y);
            }
            
        }
        if (axis.y == 1)
        {
            float y = startpos + distance;
            Vector3 pos = new Vector3( transform.position.x,y);
            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            if (transform.position == pos)
            {
                transform.position = new Vector3(transform.position.x, startpos);
            }
            
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        onobject =true;
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        onobject = false;
    }




}
