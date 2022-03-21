using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeUI : MonoBehaviour
{
    public int intToSave;
    public float floatToSave;
    public string stringToSave;
    public bool boolToSave;
    public int character;

    //Text for displaying information
    public TextMeshProUGUI floatText;
    public TextMeshProUGUI intText;
    public TextMeshProUGUI dataText;
    public string characterText;

    //UI inputs
    public Slider floatSlider, intSlider, sfxVol, musicVol;
    public Dropdown characterClass;
    public TMP_InputField nameString;


    public void ChangeSliderValue()
    {
        floatToSave = floatSlider.value;
        intToSave = Mathf.RoundToInt(intSlider.value);
        intText.text = intToSave.ToString();
        floatText.text = floatToSave.ToString();
    }

    public void CharacterChange()
    {
        switch (characterClass.value)
        {
            case 0:
                character = 1;
                characterText = "Archer";
                break;
            case 1:
                character = 2;
                characterText = "Mage";
                break;
            case 2:
                character = 3;
                characterText = "Berzerker";
                break;
            default:
                Debug.Log("Please choose a character class");
                break;

        }
    }

    public void UpdateInfo()
    {
        
        intToSave = Mathf.RoundToInt(intSlider.value);
        floatToSave = floatSlider.value;
        stringToSave = nameString.text;
        dataText.text = stringToSave;
    }

    public void DisplayInfo()
    {
        intText.text = intToSave.ToString();
        intSlider.value = (float)intToSave;
        floatText.text = floatToSave.ToString();
        floatSlider.value = floatToSave;
        Debug.Log("Both sliders updated");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        
        // Application.Quit();
    }
}
