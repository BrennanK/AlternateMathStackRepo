﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActive : MonoBehaviour
{
    public bool isHidding = false;
    //public GameObject BOXES;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Equal with after checking the resualts in AnswerChecker.cs
            DeactivateBoxStack();
        }


        if (isHidding)
        {
            //BOXES.SetActive(false);
            this.gameObject.SetActive(false);
            isHidding = true;
        }
        //else if (!isHidding)
        //{
        //    this.gameObject.SetActive(true);
        //}
    }

    public void DeactivateBoxStack()
    {
        isHidding = true;
        Debug.Log("Send DeactivateBoxStack");
    }
}
