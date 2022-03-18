using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SaveSerial : MonoBehaviour
{
    int intToSave;
    float floatToSave;
    string stringToSave;
    bool boolToSave;
    

    //public GameObject displayObject;

    //Text for displaying information
    public TextMeshProUGUI floatText;
    public TextMeshProUGUI intText;
    public TextMeshProUGUI dataText;
    public TextMeshProUGUI preamble;

    public Slider floatSlider, intSlider;
    public Toggle inputBool;
    
    

    public TMP_InputField nameString;

    //complex variables
    bool onShowObject = false;
    Color saveObjectColor = Color.blue;


    public void ChangeSliderValue()
    {
        floatToSave = floatSlider.value;
        intToSave = Mathf.RoundToInt(intSlider.value);
        intText.text = intToSave.ToString();
        floatText.text = floatToSave.ToString();

    }

    public void UpdateInfo()
    {
        boolToSave = inputBool;
        intToSave = Mathf.RoundToInt(intSlider.value);
        floatToSave = floatSlider.value;
        stringToSave = nameString.text;
        dataText.text = stringToSave;
    }

    void DisplayInfo()
    {
        intText.text = intToSave.ToString();
        floatText.text = floatToSave.ToString();
        intSlider.value = (float)intToSave;
        floatSlider.value = floatToSave;
        Debug.Log("Both sliders updated");
    }

    private void Update()
    {
        
    }

    public void SaveGame()
    {
        UpdateInfo();
      
        //Constructs a new binary format object
        BinaryFormatter bf = new BinaryFormatter();
        //Constructs a new file stream object
        FileStream file = File.Create(Application.persistentDataPath + "/myData.vxr");
        //Constructs a new SaveData object to access the serializable variables
        SaveData data = new SaveData();
        //Saves local variable values to SaveData vaiables
        data.savedInt = intToSave;
        data.savedFloat = floatToSave;
        data.savedString = stringToSave;
        data.savedBool = boolToSave;
        
        bf.Serialize(file, data);
        //Closes file stream
        file.Close();
        dataText.text = "Hi "+stringToSave +". Your number is " + intToSave.ToString();
        Debug.Log("Your game is saved");

    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/myData.vxr"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/myData.vxr", FileMode.Open);

            SaveData data = bf.Deserialize(file) as SaveData;
            file.Close();

            intToSave = data.savedInt;
            floatToSave = data.savedFloat;
            boolToSave = data.savedBool;
            stringToSave = data.savedString;

           
            Debug.Log("Your data has been retrieved");
            dataText.text = "Hello " + stringToSave + ". Your integer was " + intToSave.ToString() + " and your float was " + floatToSave.ToString();
            DisplayInfo();
        }
        else Debug.LogError("There is no saved data!");
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
                      + "/myData.vxr"))
        {
            File.Delete(Application.persistentDataPath
                              + "/myData.vxr");
            intToSave = 0;
            floatToSave = 0.0f;
            boolToSave = false;
            stringToSave = "";
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    public void QuitGame()
    {
        SaveGame();
        UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }
}

[Serializable]

class SaveData
{
    public int savedInt;
    public float savedFloat;
    public string savedString;
    public bool savedBool;
}
