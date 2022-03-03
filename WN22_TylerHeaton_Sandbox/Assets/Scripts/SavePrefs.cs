using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavePrefs : MonoBehaviour
{
    public TextMeshProUGUI floatText;
    public TextMeshProUGUI intText;
    int intToSave = 5;
    float floatToSave = 10f;

    public Slider floatSlider;
    public Slider intSlider;

    private void Start()
    {
      ChangeSliderValue();
    }

    private void Update()
    {
       
    }

    public void ChangeSliderValue()
    {
        //string intMessage = intSlider.value.ToString();
        // string floatMessage = floatSlider.value.ToString();
        floatToSave = floatSlider.value;
        floatText.text = floatToSave.ToString();
        intToSave = Mathf.RoundToInt(intSlider.value);
        intText.text = intToSave.ToString();
    }
    //string stringToSave = "";

    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(0, 0, 125, 50), "Raise Integer"))
    //        intToSave++;
    //    if (GUI.Button(new Rect(0, 100, 125, 50), "Raise Float"))
    //        floatToSave += 0.1f;
    //    //stringToSave = GUI.TextField(new Rect(0, 200, 125, 25),
    //    //           stringToSave, 15);
    //    GUI.Label(new Rect(375, 0, 125, 50), "Integer value is "
    //               + intToSave);
    //    GUI.Label(new Rect(375, 100, 125, 50), "Float value is "
    //               + floatToSave.ToString("F1"));
    //    //GUI.Label(new Rect(375, 200, 125, 50), "String value is "
    //    //          + stringToSave);
    //    if (GUI.Button(new Rect(750, 0, 125, 50), "Save Your Game"))
    //        SaveGame();
    //    if (GUI.Button(new Rect(750, 100, 125, 50),
    //                "Load Your Game"))
    //        LoadGame();
    //    if (GUI.Button(new Rect(750, 200, 125, 50),
    //                "Reset Save Data"))
    //        ResetData();
    //}
    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedInteger", intToSave);
        PlayerPrefs.SetFloat("SavedFloat", floatToSave);
      //  PlayerPrefs.SetString("SavedString", stringToSave);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

   public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            intToSave = PlayerPrefs.GetInt("SavedInteger");
            floatToSave = PlayerPrefs.GetFloat("SavedFloat");
          // stringToSave = PlayerPrefs.GetString("SavedString");
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        intToSave = 0;
        floatToSave = 0.0f;
       // stringToSave = "";
        Debug.Log("Data reset complete");
    }
}
