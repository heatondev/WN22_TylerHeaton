using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorSlider : MonoBehaviour
{
    MeshRenderer _mesh;
    Transform _moveObject;

    public Slider red, green, blue;

    public GameObject myObject;
    // Start is called before the first frame update
    void Start()
    {
        _mesh = myObject.GetComponent<MeshRenderer>();
        _moveObject = myObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    public void OnEdit()
    {
        Color color = _mesh.material.color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        _mesh.material.color = color;
        _mesh.material.SetColor("_EmissionColor", color);
    }

    public void OnScale()
    {
       
        Vector3 newScale = new Vector3(red.value, green.value, blue.value);
        _moveObject.localScale = newScale;
        Debug.Log(newScale);
    }
}
