using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavePrefs : MonoBehaviour
{
    //Text for displaying information
    public TextMeshProUGUI floatText;
    public TextMeshProUGUI intText;
    public TextMeshProUGUI dataText;
    public TextMeshProUGUI preamble;

    //variables to be saved
    int intToSave;
    float floatToSave;
    string stringToSave;

    //inputs for changing variables
    public Slider floatSlider;
    public Slider intSlider;
    public TMP_InputField nameString;

    //complex variables
    bool onShowObject = false;
    Color saveObjectColor = Color.blue;
    

    private void Start()
    {
     LoadGame();
    }


    public void ChangeSliderValue()
    {
        floatToSave = floatSlider.value;
        intToSave = Mathf.RoundToInt(intSlider.value);
        intText.text = intToSave.ToString();
        floatText.text = floatToSave.ToString();
    }
  // saves playerpref keys and values
    public void SaveGame()
    {
        intToSave = Mathf.RoundToInt(intSlider.value);
        floatToSave = floatSlider.value;
        stringToSave = nameString.text;
        PlayerPrefs.SetInt("SavedInteger", intToSave);
        PlayerPrefs.SetInt("SavedInteger2", 5);
        PlayerPrefs.SetFloat("SavedFloat", floatToSave);
        PlayerPrefs.SetString("SavedString", stringToSave);
        PlayerPrefs.Save();
        dataText.text = "Your number is " + intToSave.ToString();
        Debug.Log("Game data saved!");
    }
    //loads values from playerprefs
   public void LoadGame()
    {
        //check to see if key/value has been saved
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            intToSave = PlayerPrefs.GetInt("SavedInteger");       
            floatToSave = PlayerPrefs.GetFloat("SavedFloat");
            stringToSave = PlayerPrefs.GetString("SavedString");
          
            dataText.text = "Hello " + stringToSave + ". Your integer was " + intToSave.ToString() + " and your float was " + floatToSave.ToString();
            Debug.Log("Game data loaded!");
        }
        else
        { Debug.LogError("There is no save data!"); }
        StartCoroutine(UpdateUI());
    }

   
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        intToSave = 0;
        floatToSave = 0.0f;
        // stringToSave = "";
        dataText.text = "Your number is " + intToSave.ToString();
       StartCoroutine( UpdateUI());
       
        Debug.Log("Data reset complete");
    }

    public void QuitGame()
    {
        SaveGame();
        UnityEditor.EditorApplication.isPlaying = false;
       // Application.Quit();
    }
    IEnumerator UpdateUI()
    {
         
        intText.text = intToSave.ToString();
        yield return new WaitForSeconds(0.1f);
        floatText.text = floatToSave.ToString();
            yield return new WaitForSeconds(0.1f);
        intSlider.value = intToSave;
            yield return new WaitForSeconds(0.1f);
        floatSlider.value = floatToSave;
        Debug.Log(floatToSave);
        //preamble.text = "Enter Name";

    }
}
