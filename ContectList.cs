

using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

using System.IO;


using UnityEngine.Android;



using TMPro;


public class ContectList : MonoBehaviour
{
    public static ContectList instance;

    public  AndroidPlugin AP;

    public TMP_InputField nameField;

    public TMP_InputField phoneField;

    public TMP_InputField EmailField;

    public Button Save;

    // public InputField AddressField;

    private void Awake()
    {
        instance = this;
    }

    public void ButtonDown()
    {
        AndroidPlugin.sendStr(nameField.text,EmailField.text,phoneField.text);
       // StartCoroutine(AP.ShowContacts());
       
        Debug.Log(nameField.text);
       
    }

  






}


