using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimator : MonoBehaviour
{
    public Animator animator;

    public void StartAnimatorPlayback()
    {
        StartCoroutine(PlayBack());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayBack()
    {
        animator.SetBool("StartPlayback", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("StartPlayback", false);
    }
}
