using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActive : MonoBehaviour
{
    public bool isHidding = false;
    //public GameObject BOXES;
    public void Update()
    {
        if (isHidding)
        {
            //BOXES.SetActive(false);
            this.gameObject.SetActive(false);
            isHidding = false;
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    // Equal with after checking the resualts in AnswerChecker.cs
        //    DeactivateBoxStack();
        //}
    }

    public void DeactivateBoxStack()
    {
        isHidding = true;
        Debug.Log("Send DeactivateBoxStack");
    }
}
