using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JsonSystem : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;


    public void WriteJson()
    {
        Data data = new Data();
        data.username = usernameInput.text;
        data.password = passwordInput.text;

        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath + "/Data.json", json);
    }

    public void ReadJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data.json");
        Data data = JsonUtility.FromJson<Data>(json);

        usernameInput.text = data.username;
        passwordInput.text = data.password;
    }

}
