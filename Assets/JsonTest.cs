using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    string jasonsample;

    string path;
    string jsonString;
    private void Start()
    {
        path = Application.dataPath+ "/jasonsampleTest.json";
        jsonString = File.ReadAllText(path);
        CreateFromJSON(jsonString);
        Debug.Log(CreateFromJSON(jsonString));
        //Debug.Log(CreateFromJSON(jsonString)[1].city);
    }

    public static  List<quiz> CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<List<quiz>>(jsonString);
    }
    
    public class jasonclass 
    {
        public quiz[] quiz;

    }

}
[System.Serializable]
public class quiz 
{
    public string firstName;
    public string lastName;
    public  float age;
    public  string streetaddress;
    public  string city;
    //public phoneNumbers[] phoneNumbers;


}
[System.Serializable]
public class phoneNumbers 
{
    public string Mobile;
    public string Home;
}