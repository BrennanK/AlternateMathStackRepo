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
    // Start is called before the first frame update
    public WorkAnimation workAnimation;

    public SwitchActive switchActive;

    void Start()
    {
        workAnimation = FindObjectOfType<WorkAnimation>().GetComponent<WorkAnimation>();
        switchActive = FindObjectOfType<SwitchActive>().GetComponent<SwitchActive>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWorkAnimation() {
        workAnimation.ChangeAnimation();
        Debug.Log("Send ChangeAnimation()");
    }

    public void SetDeactivateBoxStack()
    {
        switchActive.DeactivateBoxStack();
        Debug.Log("Send DeactivateBoxStack()");
    }

}
