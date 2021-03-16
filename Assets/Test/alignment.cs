using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alignment : MonoBehaviour
{
    public Text text;
    public Image image;
   float textboxheight;
    float textboxpreviousheight;
    float imageheight;
    float imagewidth;
    float textboxwidth;
    float text_posx;
    float text_posy;

    public Button imagebutton1;
    public Button imagebutton2;
   // public Image imagebutton3;
    float offset;
    float x1;
    float y1;
    float x2;
    float y2;
    float x3;
    float y3;
    Rect rectangle;


    void Start()
    {
        // stores the width,height and pos of text and image
       textboxheight = text.rectTransform.rect.height;
       imageheight = image.rectTransform.rect.height;
        textboxwidth = text.rectTransform.rect.width;
        imagewidth = image.rectTransform.rect.width;
        text_posx = text.transform.localPosition.x;
        text_posy = text.transform.localPosition.y;

         x1 = imagebutton1.transform.localPosition.x;
         y1 = imagebutton1.transform.localPosition.y;
        x2 = imagebutton2.transform.localPosition.x;
        y2 = imagebutton2.transform.localPosition.y;
        //x3 = imagebutton3.transform.localPosition.x;
        //y3 = imagebutton3.transform.localPosition.y;*/

        


    }

    // Update is called once per frame
    void Update()
    {
        //updating changes  in the height of image and text
        textboxpreviousheight = textboxheight;
        textboxheight = text.rectTransform.rect.height;
        
        imageheight = text.rectTransform.rect.height;
        float imagesize = imageheight + 100;

        //used to move buttons based on textbox height
        if (textboxheight > textboxpreviousheight)
        {
            imagebutton1.transform.localPosition = new Vector3(x1, y1 - imageheight/5);
            imagebutton2.transform.localPosition = new Vector3(x2, y2 - imageheight / 5);
            //imagebutton3.transform.localPosition = new Vector3(x3, y3 - imageheight / 10);
        }
        if(textboxheight<textboxpreviousheight)
        {
            imagebutton1.transform.localPosition = new Vector3(x1, y1 + imageheight / 5);
            imagebutton2.transform.localPosition = new Vector3(x2, y2 + imageheight / 5);
           // imagebutton3.transform.localPosition = new Vector3(x3, y3 + imageheight / 10);
        }
        //stores the new pos of buttons
        x1 = imagebutton1.transform.localPosition.x;
        y1 = imagebutton1.transform.localPosition.y;
        x2 = imagebutton2.transform.localPosition.x;
        y2 = imagebutton2.transform.localPosition.y;
       // x3 = imagebutton3.transform.localPosition.x;
       // y3 = imagebutton3.transform.localPosition.y;*/

        //it is used to change the size of image based on the textboxsize
        image.rectTransform.sizeDelta = new Vector2(imagewidth, imagesize);

        //it is used to fix position of the textbox while changing its size based on the postion we fix
        text.transform.localPosition = new Vector3(text_posx, text_posy);


        






    }
   
}
