using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManagerLocal : MonoBehaviour
{
    public List<questionclass> questions = new List<questionclass>();

    GameObject dialogBox;
    GameObject Questioncanvas;
    Text questiontextbox;
    
    GameObject button1,button2,button3;
    Button  button1button, button2button, button3button;
    Text button1text, button2text, button3text ;

    float Timer = 0;


    bool time_updated;




     int i= 0;

    private void Awake()
    {
        dialogBox= this.transform.GetChild(0).gameObject;
        //questioncanvas // the main canvas for questions display
        Questioncanvas = this.transform.GetChild(1).gameObject;
        questiontextbox= Questioncanvas.transform.GetChild(0).GetComponent<Text>();

        //buttons
        button1button = Questioncanvas.transform.GetChild(1).GetComponent<Button>();
        button2button = Questioncanvas.transform.GetChild(2).GetComponent<Button>();
        button3button = Questioncanvas.transform.GetChild(3).GetComponent<Button>();
        
        //button_texts
        button1text = button1button.gameObject.transform.GetChild(0).GetComponent<Text>();
        button2text = button2button.gameObject.transform.GetChild(0).GetComponent<Text>();
        button3text = button3button.gameObject.transform.GetChild(0).GetComponent<Text>();
        


    }
    private void Start() 
    {
        Timer = 0;
        button1button.onClick.AddListener(delegate{optionclick(1); });
        button2button.onClick.AddListener(delegate{optionclick(2); });
        button3button.onClick.AddListener(delegate{optionclick(3); });
        i=0;
    }


    private void Update()
    {
        if(time_updated)
       {
            Timer = 0;
            time_updated = false;
       }
        if (Questioncanvas.gameObject.activeSelf) { Timer += Time.deltaTime * 1f; }

        questiontextbox.text = questions[i].QuestionText;
        var button1image = button1button.GetComponent<RawImage>();
        button1image.texture = questions[i].imageoption1;
        var button2image = button2button.GetComponent<RawImage>();
        button2image.texture = questions[i].imageoption2;
        var button3image = button3button.GetComponent<RawImage>();
           button3image .texture= questions[i].imageoption3;

    }

    void optionclick(int option_no)
    {
        int correctanswervalue = (int)questions[i].correct_answer;
        if(option_no == correctanswervalue)
        {
            Right_Answer();

        }
        else if (option_no != correctanswervalue)
        {
            Wrong_Answer();

        }

    }

    void Right_Answer()
    {
        Gamemanager.question_no++;
        Gamemanager.result.Add(new results() {Question_no = Gamemanager.question_no,result = "RightAnswer" , time_taken = Mathf.Round(Timer) });
        
       // Debug.Log(Timer);
        time_updated = true;
        if (!questions[i].gotoconversation )
    {
            if (questions[i].reward_player)
            {
                addReward();
            }
            i =i+1; // if (i+1 <= questions.count) later add this to avoid errors?
      //  Debug.Log("right answer");
    }
    else if (questions[i].gotoconversation )
    {
            this.gameObject.GetComponent<triggerScript>().i = questions[i].gotoindexRightAnswer;
            this.gameObject.GetComponent<triggerScript>().questionCompleted = true;
            if (questions[i].reward_player)
            {
                addReward();
            }
        Questioncanvas.SetActive(false);
        dialogBox.SetActive(true);

    }

    }
     void Wrong_Answer()
    {
        Gamemanager.question_no++;
        Gamemanager.result.Add(new results() { Question_no = Gamemanager.question_no,question= questions[i].QuestionText, result = "WrongAnswer" ,time_taken = Mathf.Round(Timer)});
        // Gamemanager.result[i].time_taken = Timer;
        
        time_updated = true;
        if (!questions[i].gotoconversation)
        {
            if (questions[i].reward_player)
            {
                addReward();
            }
            i = i + 1; // if (i+1 <= questions.count) later add this to avoid errors?
          //  Debug.Log("right answer");
        }
        else if (questions[i].gotoconversation)
        {
            this.gameObject.GetComponent<triggerScript>().i = questions[i].gotoindexWrongAnswer;
            if (questions[i].reward_player)
            {
                addReward();
            }
            Questioncanvas.SetActive(false);
            dialogBox.SetActive(true);

        }

    }

   void addReward()
    {
       
            if (questions[i].rewarditem != null)
                InventorySimple.items.Add(questions[i].rewarditem);
            if (questions[i].gold_value != 0)
                InventorySimple.gold += questions[i].gold_value;
        
    }

   

}














[System.Serializable]
public class questionclass
{
    public int indexnumber;
    public int question_no;
    public string QuestionText;
    //public int option1, option2, option3, option4;
    public enum correct_answerenum { option1 = 1,option2 =2,option3 =3}
    public correct_answerenum correct_answer;

    public Texture2D imageoption1, imageoption2, imageoption3;
    

    public bool gotoconversation;
    public int gotoindexRightAnswer;
    public int gotoindexWrongAnswer;

    public bool reward_player;
    public string rewarditem;
    public float gold_value;

    


}
