using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.Json;
using UnityEngine.SceneManagement;


public class JsonSystem : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;

    public GameObject registerPanel;

    public GameObject successPanel;

    public GameObject warningText;


    public void Register()
    {
        
        string oldjson = File.ReadAllText(Application.dataPath + "/Data.json");

        Data data = new Data();
        data.username = usernameInput.text;
        data.password = passwordInput.text;


        string[] userArray = oldjson.Split(char.Parse(";"));
        int user_count = userArray.Length;
        for (int i=1;i<user_count;i++)
        {
            Data userdata = JsonUtility.FromJson<Data>(userArray[i]);
            if (userdata.username==usernameInput.text)
            {
                
                Debug.Log("Same username");
                warningText.SetActive(true);
                return;
            }
        }
        Debug.Log("Success");
        
        string json = JsonUtility.ToJson(data,true);
        string newjson = oldjson + ";" + json;
        File.WriteAllText(Application.dataPath + "/Data.json", newjson);

        registerPanel.SetActive(false);
        successPanel.SetActive(true);

    }

    public void Login()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data.json");
        string[] userArray = json.Split(char.Parse(";"));

        int user_count = userArray.Length;
        for (int i=1;i<user_count;i++)
        {
            Data data = JsonUtility.FromJson<Data>(userArray[i]);
            if (data.username==usernameInput.text && data.password==passwordInput.text)
            {
                
                Debug.Log("Success");
                SceneManager.LoadScene(1);
                return;
            }
        }
        Debug.Log("Fail");
        warningText.SetActive(true);
    }

    public void GoToLogin()
    {
        // GameObject loginMenu = GameObject.Find("LoginMenu");
        // loginMenu.SetActive(true);
        this.gameObject.SetActive(false);

    }


}
