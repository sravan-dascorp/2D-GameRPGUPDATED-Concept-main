using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using RPGM.Gameplay;

public class ontransitionpointtrigger : MonoBehaviour
{///
    //this is just a quick hack
    public GameObject fadingcanvas;
    public GameObject cameraa;
    public float upheight;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            {
            fadingcanvas.SetActive(true);
            Invoke("delay", 2.2f);
            Invoke("deactivate_canvas", 6f);
        }
        
    }
    void delay()
    {
       
        cameraa.transform.GetComponent<PixelPerfectCamera>().refResolutionX = 1920;
        cameraa.transform.GetComponent<PixelPerfectCamera>().refResolutionY = 1080;
        cameraa.GetComponent<Camera>().sensorSize = new Vector2(0, 10);
        // cameraa.transform.GetComponent<PixelPerfectCamera>().assetsPPU = 64;
        // cameraa.GetComponent<CameraController>().smoothTime = 0.5f;

        // Vector3 tempposition = cameraa.transform.position + Vector3.up * upheight;
        //cameraa.transform.GetComponent<CameraController>().offset.y = cameraa.transform.GetComponent<CameraController>().offset.y + upheight;
    }
    void deactivate_canvas()
    {
        fadingcanvas.SetActive(false);
    }
}
