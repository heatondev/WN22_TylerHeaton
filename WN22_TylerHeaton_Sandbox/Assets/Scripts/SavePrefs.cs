using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavePrefs : MonoBehaviour
{
    ChangeUI ui;
    ToggleAnimation toggle;
   

    private void Awake()
    {
        ui = GetComponent<ChangeUI>();
        toggle = GetComponent<ToggleAnimation>();
    }


    private void Start()
    {
     LoadGame();
    }


   
  // saves playerpref keys and values
    public void SaveGame()
    {
        ui.UpdateInfo();
        //intToSave = Mathf.RoundToInt(ui.intSlider.value);
        //floatToSave = ui.floatSlider.value;
        //stringToSave = ui.nameString.text;
        PlayerPrefs.SetInt("SavedInteger", ui.intToSave);
      
        PlayerPrefs.SetFloat("SavedFloat", ui.floatToSave);
        PlayerPrefs.SetString("SavedString", ui.stringToSave);
        PlayerPrefs.SetInt("StartBool", toggle.isStarted);
        PlayerPrefs.Save();
        ui.dataText.text = "Your number is " + ui.intToSave.ToString()+ ". You are a " + ui.characterText;
        Debug.Log("Game data saved!");
    }
    //loads values from playerprefs
   public void LoadGame()
    {
        //check to see if key/value has been saved
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            ui.intToSave = PlayerPrefs.GetInt("SavedInteger");
            ui.floatToSave = PlayerPrefs.GetFloat("SavedFloat");
            ui.stringToSave = PlayerPrefs.GetString("SavedString");
            toggle.isStarted = PlayerPrefs.GetInt("StartBool");
            toggle.isSwitched = PlayerPrefs.GetInt("isSwitched");
          
            ui.dataText.text = "Hello " + ui.stringToSave + ". Your integer was " + ui.intToSave.ToString() + " and your float was " + ui.floatToSave.ToString() + ". You are a "+ui.characterText;
            Debug.Log("Game data loaded!");
        }
        else
        { Debug.LogError("There is no save data!"); }
        StartCoroutine(UpdateUI());
    }

   
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        ui.intToSave = 0;
        ui.floatToSave = 0.0f;
        // stringToSave = "";
        ui.dataText.text = "Your number is " + ui.intToSave.ToString();
       StartCoroutine( UpdateUI());
       
        Debug.Log("Data reset complete");
    }

   
    IEnumerator UpdateUI()
    {
         
        ui.intText.text = ui.intToSave.ToString();
        yield return new WaitForSeconds(0.1f);
        ui.floatText.text = ui.floatToSave.ToString();
            yield return new WaitForSeconds(0.1f);
        ui.intSlider.value = ui.intToSave;
            yield return new WaitForSeconds(0.1f);
        ui.floatSlider.value = ui.floatToSave;
        Debug.Log(ui.floatToSave);
        //preamble.text = "Enter Name";

    }
}
