using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckAnimation : MonoBehaviour
{
    public Animator animator;

    public bool isAnimating;
    private bool trigger;

    private void Start()
    {
        trigger = true;
    }

    private void Update()
    {
        if (trigger)
        {
            if (isAnimating)
            {
                animator.SetBool("isAnimating", true);

                trigger = false;
                isAnimating = false;
            }
        }

    }

    public void ChangeAnimation()
    {
        trigger = true;
        animator.SetBool("isAnimating", false);
    }
}
