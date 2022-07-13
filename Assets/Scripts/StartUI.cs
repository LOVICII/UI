using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public GameObject LoginUI;
    public GameObject RegisterUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoginClicked()
    {
        LoginUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OnRegisterClicked()
    {
        RegisterUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
