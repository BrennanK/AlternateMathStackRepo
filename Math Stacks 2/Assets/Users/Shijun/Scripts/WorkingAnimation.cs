/* Author: Shijun Guo
 * Description: Animator for the worker
 * AnswerChecker.cs
 *  - Reference
 *  - Trigger of animator
 */
// Date: 03/11/2019
// Last Edited By: 
// Last Edited Date: 
using System.Collections.Generic;
using UnityEngine;

public class WorkingAnimation : MonoBehaviour
{
    public WorkAnimation workAnimation;

    public SwitchActive switchActive;

    public GameObject boxStackAnimation;

    void Start()
    {
        workAnimation = FindObjectOfType<WorkAnimation>().GetComponent<WorkAnimation>();
        switchActive = FindObjectOfType<SwitchActive>().GetComponent<SwitchActive>();
        //boxStackAnimation = GameObject.Find("BoxStack_Animation");
        //Debug.Log(boxStackAnimation);
    }

    void Update()
    {
        
    }

    public void ChangeWorkAnimation() {
        workAnimation.ChangeAnimation();
        //Debug.Log("Send ChangeAnimation()");
    }

    public void SetDeactivateBoxStack()
    {
        switchActive.DeactivateBoxStack();
        //Debug.Log("Send DeactivateBoxStack()");
    }

    public void SetActivateBoxStack()
    {
        boxStackAnimation.SetActive(true);
    }
}
