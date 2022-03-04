using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartAnimation : MonoBehaviour
{
    public Animator holocube;
    public Animator ball;

    public TextMeshProUGUI buttonText;
    public MeshRenderer mesh;
    float meshAlpha = 255f;

    public Text onOffLabel;
    public Color textColor;

    public AudioSource buttonClick;
    // Start is called before the first frame update
    void Start()
    {
       
       // onOffLabel.color = textColor;
        //holocube.ResetTrigger("StartRot");
        if (!ball.GetBool("Start"))
        {
            onOffLabel.text = "Off";
           
        }
    }

    public void playAnimation()
    {
        
        
       // buttonClick.Play();
       if (!ball.GetBool("Start"))
        {
            ball.SetBool("Start", true);
            onOffLabel.text = "On";
            buttonText.text = "Stop";
        }
        else
        {
        ball.SetBool("Start", false);
           buttonText.text = "Start";
        onOffLabel.text = "Off";
        
        }
    }
    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.R))
        {
            holocube.SetTrigger("StartRot");
        }
    }


}
