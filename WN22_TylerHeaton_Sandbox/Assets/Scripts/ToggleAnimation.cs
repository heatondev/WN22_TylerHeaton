using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimation : MonoBehaviour
{

    public Animator animator;
    SavePrefs savedStuff;

    void Awake()
    {
       
    }

   public  int isStarted;
  public  int isSwitched;

    // Start is called before the first frame update
    void Start()
    {
        if (isStarted == 1)
        {
            animator.SetBool("Started", true);
        } else animator.SetBool("Started", false);

        if (isSwitched == 1)
        {
            animator.SetBool("Switched", true);
        }
        else animator.SetBool("Switched", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AnimationTransition();
            Debug.Log("Toggled");
        }
    }

    public void AnimationTransition()
    {
        if (!animator.GetBool("Toggle"))
        {
            animator.SetBool("Toggle", true);
        }
        else animator.SetBool("Toggle", false);
    }
}
