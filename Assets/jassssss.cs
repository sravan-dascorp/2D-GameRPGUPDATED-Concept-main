using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
public class jassssss : MonoBehaviour
{
  public static QuestionList questionlist;
   // public List<QuestionsClass> qlist1 = new List<QuestionsClass>();
    string contents;
    List<int> coroutineCounter = new List<int>();
 public  static List<ImagePathList> image_PathList = new List<ImagePathList>();
  public static  List<LoadedImageTexture> ImageTextureList = new List<LoadedImageTexture>();
   // public RawImage box1, box2, box3;

    static int findex=0;
    static bool runDisplay;
    public  Text textbox;
   // public Text questiontext;
   bool run =false;
    bool jsonCoroutineFinished = false;
    public Button continueButton;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(GetJson("https://myairschool.com/api/code-api/index.php/api/Questions"));
        

    }

    private void parsestuff()
    {
        jsonCoroutineFinished = true;

        if (jsonCoroutineFinished)
        {
            jsonCoroutineFinished = false;
            Debug.Log(contents);
            //string path = contents;
            //Debug.Log(path);
           
            //string temp = "{\"Questions\":" + contents+"}";
           // Debug.Log(temp);
            questionlist = CreateFromJSON(contents);
          
            textbox.text = "QuestionList Created";
           
                if (questionlist.data.Count > 0 && questionlist.data != null)
                {
                    Debug.Log("testing running");
                    jsonCoroutineFinished = true;
                    Start();
                    run = true;
                }
            
        }
    }

    private void Start()
    {
        if (jsonCoroutineFinished)
        {
            Debug.Log("started forLoop");
            int b = 0;

            foreach (var item in questionlist.data)
            {
                textbox.text = "Getting Images...:" + b/questionlist.data.Count;
                StartCoroutine(GetPlayerImage(item.optiona, item.optionb, item.optionc, "Q" + item.id + " "));

                b++;

            }
        }
       
    }

    private void Update()
    {
        if (run && questionlist.data.Count == coroutineCounter.Count)  
        {
            Debug.Log("coroutine:" + coroutineCounter.Count);
            //CreateNewList();
            textbox.text = "Press Continue";
            continueButton.gameObject.SetActive(true);
            run = false;
        }


    }

    /* private void Update()
     {
        Debug.Log(questionlist.data.Count);
         if (coroutineCounter.Count == questionlist.data.Count && run)
         {
             Debug.Log("done downloading");
             textbox.text = "done Downloading";
             runDisplay = CreateNewList();
             Debug.Log("couroutinecounter:" + coroutineCounter.Count);


             run = false;
             textbox.text = "Current Selected Subject : " + questionlist.subject;

         }*/

    // Debug.Log(temptext);
    //Debug.Log(Application.dataPath);
    // Debug.Log(Application.persistentDataPath);


    //   if (runDisplay)
    // {

    //questiontext.text = questionlist.data[findex].question;
    // box1.texture = ImageTextureList[findex].Option1;
    // box2.texture = ImageTextureList[findex].Option2;
    //box3.texture = ImageTextureList[findex].Option3;
    // }


    // goood





    //if (donedownload)
    //{
    //    donedownload = false;
    //    //if (a < questions.Count)
    //    if ( WriteImageOnDisk(a+"cat.png", picture: playerImage)) 
    //    {
    //        if (a + 1 < questions.Count) { a++; Start(); }

    //    }





    //       // if (a + 1 < questions.Count) { a++; Start(); }




    //}

    // }
    public void createListButton()
    {
        if (coroutineCounter.Count == questionlist.data.Count)
        {
            Debug.Log("done downloading");
            runDisplay = CreateNewList();

        }
    }
    private bool CreateNewList()
    {



        foreach (var item in image_PathList)
        {
            LoadedImageTexture temptextList = new LoadedImageTexture();

            temptextList.Option1 = LoadSprite(Application.persistentDataPath + "/" + item.option_1 + ".png") as Texture2D;

            temptextList.Option2 = LoadSprite(Application.persistentDataPath + "/" + item.option_2 + ".png") as Texture2D;

            temptextList.Option3 = LoadSprite(Application.persistentDataPath + "/" + item.option_3 + ".png") as Texture2D;

            ImageTextureList.Add(temptextList);

        }
        Debug.Log("created list");
        textbox.text = "created List";

        return true;

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

    public static QuestionList CreateFromJSON(string jsonString)
    {
        
        return JsonUtility.FromJson<QuestionList>(jsonString);
        
    }
    private IEnumerator GetJson(string url)
    {

        //request First image;
        UnityWebRequest www1 = UnityWebRequest.Get(url);
        yield return www1.SendWebRequest();
        // Debug.Log("send request1");
        contents = www1.downloadHandler.text;
        // Debug.Log(contents);
       if(contents!=null)
        parsestuff();
        textbox.text = "JsonFile Downloaded!!!!!!!!...";

    }
    private IEnumerator GetPlayerImage(string url1, string url2, string url3, string name)
    {

        //request First image;
        UnityWebRequest www1 = UnityWebRequestTexture.GetTexture(url1);
        yield return www1.SendWebRequest();
        // Debug.Log("send request1");

        Texture2D myTexture1 = DownloadHandlerTexture.GetContent(www1);

        Rect rec1 = new Rect(0, 0, myTexture1.width, myTexture1.height);
        Sprite spriteToUse1 = Sprite.Create(myTexture1, rec1, new Vector2(0.5f, 0.5f), 100);






        UnityWebRequest www2 = UnityWebRequestTexture.GetTexture(url2);
        yield return www2.SendWebRequest();
        //Debug.Log("send request1");
        Texture2D myTexture2 = DownloadHandlerTexture.GetContent(www2);

        Rect rec2 = new Rect(0, 0, myTexture2.width, myTexture2.height);
        Sprite spriteToUse2 = Sprite.Create(myTexture2, rec2, new Vector2(0.5f, 0.5f), 100);




        UnityWebRequest www3 = UnityWebRequestTexture.GetTexture(url3);
        yield return www3.SendWebRequest();
        //Debug.Log("send request1");

        Texture2D myTexture3 = DownloadHandlerTexture.GetContent(www3);

        Rect rec3 = new Rect(0, 0, myTexture3.width, myTexture3.height);
        Sprite spriteToUse3 = Sprite.Create(myTexture3, rec3, new Vector2(0.5f, 0.5f), 100);







        if (WriteImageOnDisk(name, picture1: spriteToUse1, picture2: spriteToUse2, picture3: spriteToUse3))
        {
            //  if (a + 1 < questions.Count) { Start(); }
            coroutineCounter.Add(1);

        }





    }
    private bool WriteImageOnDisk(string fileName, Sprite picture1, Sprite picture2, Sprite picture3)
    {
        // image.sprite = playerImage;
        byte[] textureBytes1 = picture1.texture.EncodeToPNG();
        byte[] textureBytes2 = picture2.texture.EncodeToPNG();

        byte[] textureBytes3 = picture3.texture.EncodeToPNG();

        ImagePathList tempImagelist = new ImagePathList();



        File.WriteAllBytes(Application.persistentDataPath + "/" + fileName + "1.png", textureBytes1);
        //Debug.Log("File Written On Disk! " + fileName + "1");
        tempImagelist.option_1 = fileName + "1";



        File.WriteAllBytes(Application.persistentDataPath + "/" + fileName + "2.png", textureBytes2);
        // Debug.Log("File Written On Disk! " + fileName + "2");
        tempImagelist.option_2 = fileName + "2";

        File.WriteAllBytes(Application.persistentDataPath + "/" + fileName + "3.png", textureBytes3);
        // Debug.Log("File Written On Disk! " + fileName + "3");
        tempImagelist.option_3 = fileName + "3";



        //image.sprite = Resources.Load(Application.dataPath + "/Resources/" + fileName) as Sprite;

        image_PathList.Add(tempImagelist);

        return true;

    }

}
[System.Serializable]
public class QuestionsClass
{
    public string id;
    public string question;
    public string optiona;
    public string optionb;
    public string optionc;
    public string optiond;
    public string answer;


}
[System.Serializable]
public class ImagePathList
{
    public string option_1;
    public string option_2;
    public string option_3;




}
[System.Serializable]
public class LoadedImageTexture
{
    public Texture2D Option1;
    public Texture2D Option2;
    public Texture2D Option3;


}
[System.Serializable]
public class QuestionList
{
    public string subject;
    public List<QuestionsClass> data = new List<QuestionsClass>();

}


