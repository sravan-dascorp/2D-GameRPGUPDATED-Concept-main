using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerScript : MonoBehaviour
{
    public bool questionCompleted = false;
    bool executed;
    public int loopConversation;
    public int after_execution_loop;
    

    //to use this script the hierarchy should be as the following info !
    // this script(triggerscript),conversation script,and the questionmanagerlocal script should be in a gaaeobject with a collider;
    //it should have 2 child objects , dialogue canvas as child (0) and question canvas as child(1)
    //dialogue canvas should have 3 childs, dialog textbox as child(0),button1 as child(1),button2 as child(2);
    // question canvas should have 4 child as following, question textbox as child(0),then 3 buttons each as child(1),child(2),child(3) respectively
    // well later realised it was much easier to use public variables and refereng it and then sving it as a prefaa; :(


    GameObject dialogbox;
    GameObject QuestionBox;


    Text con_textbox;
    Button Reply_button1;
    Button Reply_button2;
    Text Reply_buttontext1;
    Text Reply_buttontext2;




    ConversationScriptSimple conversationScript;
    public int i =0;


     bool conversationended;





    // Start is called before the first frame update
    void Awake()
    {
     
        dialogbox = this.transform.GetChild(0).transform.gameObject;
        QuestionBox = this.transform.GetChild(1).transform.gameObject;
        con_textbox = dialogbox.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
        Reply_button1 = dialogbox.transform.GetChild(1).GetComponent<Button>();
        Reply_button2 = dialogbox.transform.GetChild(2).GetComponent<Button>();
        Reply_buttontext1 = Reply_button1.gameObject.transform.GetChild(0).GetComponent<Text>();
        Reply_buttontext2 = Reply_button2.gameObject.transform.GetChild(0).GetComponent<Text>();





    }
    private void Start()
    {
        dialogbox.SetActive(false);
        QuestionBox.SetActive(false);
        conversationScript = this.GetComponent<ConversationScriptSimple>();

       Reply_button1.onClick.AddListener(delegate{option1_click();});
        Reply_button2.onClick.AddListener(delegate{option2_click();});

    }

    // Update is called once per frame
    void Update()
    {
        

        if (!conversationScript.conversations[i].endconversation)
        {
            con_textbox.text = conversationScript.conversations[i].Conversation_text;

            Reply_buttontext1.text = conversationScript.conversations[i].reply1;
            Reply_buttontext2.text = conversationScript.conversations[i].reply2;

        }
        else { conversationended = true; }

        if (conversationended )
        {
            dialogbox.SetActive(false);
           // i = i - 1;
            conversationended = false;
            

        }
        


    }

   
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (!questionCompleted)
            {
                i = 0;
            }
            
            if (questionCompleted && !executed)
            {
                i = loopConversation;
            }
            else if(questionCompleted && executed || executed)
            {
                i = after_execution_loop;
            }
            dialogbox.SetActive(true);
            

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        dialogbox.SetActive(false);
       
    }
    

    public void option1_click()
    {
        int nextindex = conversationScript.conversations[i].reply1conversation;
        if(!conversationScript.conversations[nextindex].gotoQuestion)
        {
            if (conversationScript.conversations[nextindex].changebooltrigger)
            {
                Debug.Log("this one has the bool trigger");
                conversationScript.conversations[nextindex].booltriggerscript.execute = true;
                executed = true;
                dialogbox.SetActive(false);
            }
            else if(!conversationScript.conversations[nextindex].changebooltrigger)
            i = conversationScript.conversations[i].reply1conversation;
        }
        else if(conversationScript.conversations[nextindex].gotoQuestion)
        {
             dialogbox.SetActive(false);
             QuestionBox.SetActive(true);
        }
        
    }
    public void option2_click()
    {
        int nextindex = conversationScript.conversations[i].reply2conversation;
        if(!conversationScript.conversations[nextindex].gotoQuestion)
        {
            if ((conversationScript.conversations[nextindex].changebooltrigger))
            {
                
                conversationScript.conversations[nextindex].booltriggerscript.execute = true;
                executed = true;
                dialogbox.SetActive(false);
            }
            
                i = conversationScript.conversations[i].reply2conversation;
            
            
        }
        else if(conversationScript.conversations[nextindex].gotoQuestion)
        {
             dialogbox.SetActive(false);
             QuestionBox.SetActive(true);
        }
    }
}
