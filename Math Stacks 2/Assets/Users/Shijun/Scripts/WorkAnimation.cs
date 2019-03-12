// Author: Shijun Guo
// Description: Initialize the animation for the background (Worker and Truck);
// Date: 03/08/2019
// Last Edited By: 
// Last Edited Date: 

/*
 * 动画的控制器，
 * trigger用来确定是否开启动画
 * isAnimaton用来定义播放动画的状态
 */
using System.Collections.Generic;
using UnityEngine;

public class WorkAnimation : MonoBehaviour
{

    public Animator animator;

    public bool isAnimating;
    private bool trigger;

    public bool testTrigger;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        trigger = true;
    }

    private void Update()
    {

        // Use for test the animation by pressign Space
        if (trigger && testTrigger)
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && !isAnimating)
            {
                // Equal with after checking the resualts in AnswerChecker.cs
                isAnimating = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && isAnimating)
            {
            }
        }

        
        if (trigger)
        {

            if (isAnimating)
            {
                animator.SetBool("isAnimating", true);
                Debug.Log("Play the Walking Animation");

                trigger = false;
                isAnimating = false;
                Debug.Log("Turn Off Trigger & isAnimation");
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
