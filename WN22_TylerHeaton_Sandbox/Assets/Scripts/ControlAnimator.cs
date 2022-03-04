using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimator : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    string _animParameter;
    public void StartAnimatorPlayback()
    {
        StartCoroutine(PlayBack());
    }
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Toggle", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            StartAnimatorPlayback();
        }
    }

    IEnumerator PlayBack()
    {
        animator.SetBool(_animParameter, true);
        yield return new WaitForSeconds(2);
        animator.SetBool(_animParameter, false);
        
    }
}
