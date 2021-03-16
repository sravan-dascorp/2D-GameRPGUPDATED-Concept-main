using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletegameobject : MonoBehaviour
{
    public string required_item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {  if(collision.collider.CompareTag("Player"))
        if(InventorySimple.items.Contains(required_item))
        {
                InventorySimple.items.Remove(required_item);
                GameObject.Destroy(this.gameObject);
                
        }

    }
}
