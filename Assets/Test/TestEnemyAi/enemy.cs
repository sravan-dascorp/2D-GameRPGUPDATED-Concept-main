using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private bool patrol = true;
    [SerializeField]
    private bool attack;
    private bool moveright = true;
    private float firetimer;

    public float speed = 2;
    public float distance;
    public float Raydistance = 1;
    public float bulletspeed = 100;
    public float waitforfire = 1;
    public float starty = 1;
    public float endy =1;

    private float startposx;
    private float endposx;
    private float startposy;
    private float endposy;
    private float playerdistance;
    public float fromray;

    public GameObject bulletprefap;
    public Transform player;
    private Vector3 dummy;

    RaycastHit2D hit;

    void Start()
    {
        startposx = transform.position.x;
        endposx = transform.position.x + distance;
        startposy = transform.position.y-starty;
        endposy = transform.position.y + endy;

    }

    // Update is called once per frame
    void Update()
    {
        dummy = player.position;
        dummy.y = this.transform.position.y;
        firetimer += Time.deltaTime * 1f ;
       
        playerdistance = Vector2.Distance(transform.position, dummy);
         hit = Physics2D.Raycast(transform.position + transform.right,transform.right,Raydistance);
        // to activate attack when player is found
        if ((player.position.x < endposx) && (player.position.x > startposx))
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    patrol = false;
                    attack = true;

                }
            }
        }
        //to activate patrol when player was not in range
        if ((((player.position.x > endposx) && (player.position.x > startposx))|| (player.position.x < startposx)) ||
            (((player.position.y > endposy) && (player.position.y > startposy)) || (player.position.y < startposy)))
        {
            patrol = true;
            attack = false;
           
        }
       


        if (patrol == true)
        {
            patroling();
        }
        if(attack == true)
        {
            attacking();
        }
        
    }
    void patroling()
    {
            //to move and flip based on direction
            if (moveright == true)
            {
                float x = startposx + distance;
                Vector3 pos = new Vector3(x, transform.position.y);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
                if (transform.position == pos)
                {
                    moveright = false;
                }
            }
            if (moveright == false)
            {

                Vector3 pos1 = new Vector3(startposx, transform.position.y);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.position = Vector2.MoveTowards(transform.position, pos1, speed * Time.deltaTime);
                if (transform.position == pos1)
                {
                    moveright = true;
                }
            
            }
           
        
    }
    void attacking()
    {

        if ((player.position.x < endposx) && (player.position.x > startposx))
        {
            Vector2 direction1 = (Vector2)player.position - (Vector2)transform.position;
            direction1.Normalize();
            float angle1 = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.up * angle1);
            //to activate fire when in raydistance
            if (playerdistance <= Raydistance)
            {
              
                if (firetimer >= waitforfire)
                {
                    fire();
                    firetimer = 0;
                }
             

            }
            //to follow player when not in raydistance
            if (playerdistance > Raydistance)
            {
                Vector3 offsettoplayer = dummy - new Vector3(Raydistance, 0, 0);
                transform.position = Vector2.MoveTowards(transform.position, offsettoplayer, speed * Time.deltaTime);
                //to look towards enemy
                Vector2 direction = (Vector2)player.position - (Vector2)transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(Vector3.up * angle);


            }
        }
      
    }
    void fire()
    {

        GameObject obj = Instantiate(bulletprefap, transform.position+transform.right, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.right.x*bulletspeed,0));
       

    }
}
