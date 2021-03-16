using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool patrol = true;
    [SerializeField]
    private bool attack;
    private bool moveright = true;
  

    public float speed = 2;
    public float attackspeed = 2;
    public float distance;
    public float Raydistance = 1;
    private float attacktimer;
    public float waitforattack = 1;
   

    private float startposx;
    private float endposx;
    private float startposy;
    private float endposy;
    private float playerdistance;

    public Transform player;
    private Vector3 dummy;

    RaycastHit2D hit;

    void Start()
    {
        startposx = transform.position.x;
        endposx = transform.position.x + distance;
        startposy = transform.position.y - 1;
        endposy = transform.position.y + 1;

    }

    // Update is called once per frame
    void Update()
    {
        dummy = player.position;
        dummy.y = this.transform.position.y;
        attacktimer += Time.deltaTime * 1;
       

        playerdistance = Vector2.Distance(transform.position, dummy);
        hit = Physics2D.Raycast(transform.position + transform.right, transform.right, Raydistance);
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
        if ((((player.position.x > endposx) && (player.position.x > startposx)) || (player.position.x < startposx)) ||
            (((player.position.y > endposy) && (player.position.y > startposy)) || (player.position.y < startposy)))
        {
            patrol = true;
            attack = false;

        }



        if (patrol == true)
        {
            patroling();
        }
        if (attack == true)
        {
            attacking();
        }

    }
    void patroling()
    {    //to move and flip based on direction
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
        //to move towards player
        if ((player.position.x < endposx) && (player.position.x > startposx))
        {
            //to look towards enemy
            Vector2 direction = (Vector2)player.position - (Vector2)transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.up * angle);

            //when in raydistance to attack player
            if (playerdistance <= Raydistance)
            {
                
                if (attacktimer >= waitforattack)
                {
                    Vector3 offsettoplayer = dummy - new Vector3(this.transform.right.x * 1, 0, 0);
                    transform.position = Vector2.MoveTowards(transform.position, offsettoplayer, attackspeed * Time.deltaTime);
                   
                    Invoke("deactivateattack", 1);
                }
             
            }
            // when not in ray distance to follow player
            if (playerdistance > Raydistance)
            {
                Vector3 offsettoplayer = dummy - new Vector3(1, 0, 0); ;
                transform.position = Vector2.MoveTowards(transform.position, offsettoplayer, speed * Time.deltaTime);
              

            }
        }
       

    }
    void deactivateattack()
    {
        attacktimer = 0;
    }
   
}
