using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject box;
    public GameObject ball;

    Material mat;
    Color[] swapColor = { new Color32(255, 0, 0, 255), new Color32(0, 255, 0, 255), new Color32(0, 0, 255, 255) };


    public void ToggleObjects(GameObject target)
    {
        mat = target.GetComponent<MeshRenderer>().sharedMaterial;
        if (target.gameObject.activeSelf)
        {
            target.SetActive(false);
           
            
        }
        else { target.SetActive(true); var i = Random.Range(0, 2); mat.color = swapColor[2]; }

       
    }

   
}


