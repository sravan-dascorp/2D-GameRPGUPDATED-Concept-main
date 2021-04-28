using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static List<results>  result = new List<results>();
    public static int  question_no = 0;
    
    public static float gametimer;
    public bool intial_time;
    public float intial_timein_second;
    public float maximum_gold;
    public float depletion_Per_SECOND;
    float timer = 500f;

    int totalrightanswers, totalwronganswer;
    float percentage;
    float totaltimeanswering;

    [Header("References Analytics_UI")]
    public GameObject analytics_canvas;

    public Text no_of_questions, right_answers, wrong_answers, total_timeSpendans, totalgameTime, marks_percentage;

    [Header("___References__")]
    public Text gold_value;


    [Header("Others")]
    public GameObject quit_popup;


    public bool not_analytics;

    // Start is called before the first frame update
    void Start()
    {
        if(!not_analytics)analytics_canvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!not_analytics)
        {
            analytics_canvas.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
            gametimer += Time.unscaledDeltaTime * 1f;
            if (intial_time)
            {
                if (intial_timein_second > 1f)
                { intial_timein_second -= Time.deltaTime * 1; }
                if (intial_timein_second <= 1f)
                {
                    timer -= Time.deltaTime * depletion_Per_SECOND;
                }




            }
            else if (!intial_time)
            {
                timer -= Time.deltaTime * depletion_Per_SECOND;
            }
            if (Input.GetKeyDown("p"))
            {
                for (int i = 0; i < result.Count; i++)
                {
                    Debug.Log(result[i].Question_no + " : " + result[i].result + " : " + result[i].time_taken);
                }
            }


            if (analytics_canvas.activeSelf)
            {
                totalgameTime.text = "Total game time    : " + Mathf.Round(gametimer);
            }

            if (gold_value != null)
                gold_value.text = InventorySimple.gold.ToString();

        }
    }

    public void activateAnalytics()
    {
        if (!analytics_canvas.activeSelf)
        {
            Time.timeScale = 0;
            runanalysis();
            analytics_canvas.SetActive(true);
        }

        else if (analytics_canvas.activeSelf)
        {
            Time.timeScale = 1;
            analytics_canvas.SetActive(false);

        }
    }
    public void runanalysis()
    {
        totalrightanswers = 0;
        totalwronganswer = 0;
        totaltimeanswering = 0;

        foreach (var item in result)
        {
            if (item.result == "WrongAnswer")
            {
                totalwronganswer++;
            }
            if (item.result == "RightAnswer")
            {
                totalrightanswers++;
            }
            totaltimeanswering += item.time_taken;

        }
      
        no_of_questions.text ="No of questions attempted" +  question_no.ToString();
        
        wrong_answers.text ="Total - Wrong Answers  : " + totalwronganswer.ToString();
        right_answers.text = "Total - Right Answers : " + totalrightanswers.ToString();

        total_timeSpendans.text = "Total time spend on questions  :  " + totaltimeanswering + " seconds";
        float val = (float)question_no;
       if(totalrightanswers>0) percentage =( totalrightanswers /   val )* 100f;
        marks_percentage.text = "Marks percentage  :   "+ percentage;
        Debug.Log(totalrightanswers + " " +  val+ "  "  + percentage);
    }


    public void quit_application()
    {
        Application.Quit();
    }
    public void lauchQuit_popup()
    {
        if (quit_popup.activeSelf) quit_popup.SetActive(false);
        else if (!quit_popup.activeSelf) quit_popup.SetActive(true); }


    public void Nextlevel()
    {
        Debug.Log("nextlevel clkickjed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void gotolevel(int level_index)
    {
        
        SceneManager.LoadScene(level_index);
    }
}









[System.Serializable]
public class results
{
    public int Question_no;
    public string question;

    public string result;

    public float time_taken;




}
