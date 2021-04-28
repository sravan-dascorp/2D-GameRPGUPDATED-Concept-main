using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class QuestionrGlobalManager : MonoBehaviour
{
    public List<questionclass> SingletonQuestionclass = new List<questionclass>();

    bool stoploop= false;
    static int i = 0;
    public float rrandomvalue;

    // Start is called before the first frame update
    void Awake()
    {


        // var questionManagerLocals = FindObjectsOfType<QuestionManagerLocal>();
        GameObject [] questionManagerLocalsobjects = GameObject.FindGameObjectsWithTag("questionbank");
        List<QuestionManagerLocal> questionManagerLocals = new List<QuestionManagerLocal>();

        randomise(SingletonQuestionclass);



        foreach (var item in questionManagerLocalsobjects)
        {
            GameObject q = item;
            var i = q.GetComponent<QuestionManagerLocal>();
            Debug.Log(q.name); 

            questionManagerLocals.Add(i);

           
        }

            foreach (var questionManager in questionManagerLocals)
            {
            if (!stoploop)
                if (i >= jassssss.questionlist.data.Count) stoploop = true;
            foreach (var item in questionManager.questions)
                {
                    if (!stoploop) 
                    {

                    item.QuestionText = jassssss.questionlist.data[i].question;
                    Debug.Log(LoadSprite(Application.persistentDataPath + "/" + jassssss.image_PathList[i].option_1 + ".png").name);
                   Texture2D temp1 =  LoadSprite(Application.persistentDataPath + "/" + jassssss.image_PathList[i].option_1 + ".png") as Texture2D;
                    item.imageoption1 = temp1;
                    Texture2D temp2 = LoadSprite(Application.persistentDataPath + "/" + jassssss.image_PathList[i].option_2 + ".png") as Texture2D;

                    item.imageoption2 = temp2;
                    Texture2D temp3 = LoadSprite(Application.persistentDataPath + "/" + jassssss.image_PathList[i].option_3 + ".png") as Texture2D;
                    item.imageoption3 = temp3;
                    item.correct_answer = ConvertToEnum(jassssss.questionlist.data[i].answer);
                    i += 1;
                        if (i >= SingletonQuestionclass.Count) {stoploop = true;
                       // Debug.Log("stopped loop"+ i);
                        }
                    }
                }

            }
        foreach(var item in SingletonQuestionclass)
        {
            Debug.Log(item.QuestionText);
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
   void randomise(List<questionclass> alpha) 
    {
        for (int i = 0; i < alpha.Count; i++)
        {
            questionclass temp = alpha[i];
            int randomIndex = Random.Range(i, alpha.Count);
            alpha[i] = alpha[randomIndex];
            alpha[randomIndex] = temp;
        }

    }
    private Texture2D LoadSprite(string path)
    {
        if (string.IsNullOrEmpty(path)) { print("erro"); return null; }
        if (System.IO.File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(900, 900, TextureFormat.RGB24, false);
            texture.filterMode = FilterMode.Trilinear;
            texture.LoadImage(bytes);
            return texture;
        }
        else return null;
    }
    questionclass.correct_answerenum ConvertToEnum(string option) 
    {
        if (option == "A") return questionclass.correct_answerenum.option1;
        else if (option == "B") return questionclass.correct_answerenum.option2;
        else if (option == "C") return questionclass.correct_answerenum.option3;
        else return questionclass.correct_answerenum.option1;

    }

}
