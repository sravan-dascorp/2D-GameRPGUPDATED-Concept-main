using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movementto2d = new Vector3(movement.x,0, movement.y);
        // transform.Translate(transform.position + movementto2d);
        transform.position = transform.position + movementto2d * Time.deltaTime;
        
    }
}
