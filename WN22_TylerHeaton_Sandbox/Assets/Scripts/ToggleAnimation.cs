using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimation : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
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
