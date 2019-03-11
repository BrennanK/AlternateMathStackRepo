// Author: Shijun Guo
// Description: Initialize the animation for the background (Worker and Truck);
// Date: 03/08/2019
// Last Edited By: 
// Last Edited Date: 
using System.Collections.Generic;
using UnityEngine;

public class WorkAnimation : MonoBehaviour
{

    public Animator animator;

    public bool isAnimating;
    private bool trigger;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        trigger = true;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && !isAnimating)
        //{
        //    animator.SetBool("isAnimating", true);
        //    isAnimating = true;
        //}
        //else if(Input.GetKeyDown(KeyCode.Space) && isAnimating)
        //{
        //    animator.SetBool("isAnimating", false);
        //    isAnimating = false;
        //}
        if (trigger)
        {

            if (isAnimating)
            {
                animator.SetBool("isAnimating", true);
                trigger = false;
                isAnimating = false;
                Debug.Log("AnimatorTrue");
            }
        }
        /*
        else if (!isAnimating)
        {
            animator.SetBool("isAnimating", false);
            isAnimating = false;
            Debug.Log("AnimatorFalse");
        }
        */
    }
    public void ChangeAnimation() {

        trigger = true;
        animator.SetBool("isAnimating", false);
    }
}
