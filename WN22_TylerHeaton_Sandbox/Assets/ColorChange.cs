using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChange : MonoBehaviour
{
    public GameObject myObject;
    Transform _scaleObject;

    public MeshRenderer meshColor;

    public Slider red, green, blue;
    public Slider scaleSlider;

    Color localColor;
  

    // Start is called before the first frame update
    void Start()
    {
        // localColor = myObject.GetComponent<MeshRenderer>().material.color;
        _scaleObject = myObject.GetComponent<Transform>();
    }

  

    public void SetScale()
    {
        Vector3 newScale = new Vector3(scaleSlider.value, scaleSlider.value, scaleSlider.value);
        _scaleObject.localScale = newScale;
    }

    public void SetColor()
    {
        Color color = meshColor.material.color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        meshColor.material.color = color;
        meshColor.material.SetColor("_Emission", color);
        localColor = color;
     
    }

    public void ColorSave()
    {


        myObject.GetComponent<MeshRenderer>().sharedMaterial.color = localColor;
        

    }
}
