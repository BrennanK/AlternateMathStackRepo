using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class TutorialK : MonoBehaviour
{
    public GameObject[] popUps;

    private int popUpIndex;
    // Start is called before the first frame update
    private bool button;

    public GameObject buttons;
    //public GameObject skipButton;
    public GameObject panel;
    public GameObject bpanel;
    private bool intutorial;
    
    public float currentlevel = 0f;
    private GameManager GM;
    private bool trigger1 = true;//popupindex set
    void Start()
    {
        popUpIndex = 0;
        button = true;
        panel.SetActive(false);
        bpanel.SetActive(true);
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentlevel = GM.currLevels;
    }

    // Update is called once per frame
    void Update()
    {
        if (intutorial == true)
        {
            buttons.SetActive(true);
            if (Time.timeScale == 1)
            {
                panel.SetActive(true);
                for (int i = 0; i < popUps.Length; i++)
                {
                    if (i == popUpIndex)
                    {
                        popUps[i].SetActive(true);
                        
                        
                    }
                    else
                    {
                        popUps[i].SetActive(false);
                    }
                }

                if (popUpIndex > 12)
                {
                    buttons.SetActive(false);
                    bpanel.SetActive(true);
                    button = false;
                    intutorial = false;
                }
                if (button == false)
                {
                    buttons.SetActive(false);
                }
                if (popUpIndex == 11)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (trigger1)
                        {
                            trigger1 = false;    
                            StartCoroutine("WaitAndChange", 2f);
                        }
                    }
                }
                if (popUpIndex == 12)
                {
                    if (trigger1)
                    {
                        trigger1 = false;
                        StartCoroutine("WaitAndChange", 3f);
                    }

                }
            }

            if (Time.timeScale == 0)
            {
                panel.SetActive(false);
            }
        }

        if (intutorial == false)
        {
            if (Time.timeScale == 1)
            {
                bpanel.SetActive(true);
            }
            if (Time.timeScale == 0)
            {
                bpanel.SetActive(false);
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            popUpIndex++;

        }
        */
       
    }
    IEnumerator WaitAndChange(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        popUpIndex++;
        trigger1 = true;


    }

    public void levelSelect(int level)
    {
        currentlevel = level;
        Debug.Log("Level has Changed");
    }
    public void InTutorial()
    {
        popUpIndex = 0;
        button = true;
        intutorial = true;
        bpanel.SetActive(false);
        
    }
    public void Skip()
    {
        popUpIndex = 15;
        button = false;

    }
   
    public void BoxMove()
    {
        if (popUpIndex == 0)
        {
            
               popUpIndex++;
        }
    }
    public void BoxEnter()
    {
        if (popUpIndex == 1)
        {

            popUpIndex++;
        }
    }
    public void UseTape()
    {
        if (popUpIndex == 2)
        {

            popUpIndex++;
        }
    }
    public void SuccessUseTape()
    {
        
        if (popUpIndex == 3)
        {

            popUpIndex++;
        }
    }
    public void UseScissor()
    {
        if (popUpIndex == 4)
        {

            popUpIndex++;
        }
    }
    public void ScissorCut()
    {
        if (popUpIndex == 5)
        {
            if (currentlevel >= 2)
            {
                popUpIndex++;
            }

            if (currentlevel < 2)
            {
                popUpIndex = 11;
                Debug.Log("junp to 11");
            }
            //popUpIndex++;
        }
    }
    public void UseStamp()
    {
        if (popUpIndex == 6)
        {
            
            popUpIndex++;
        }
    }
    public void ClickNumber()
    {
        if (popUpIndex == 7)
        {

            popUpIndex++;
        }
    }
    public void ClickOperator()
    {
        if (popUpIndex == 8)
        {

            popUpIndex++;
        }
    }
    public void ClickCrate()
    {
        if (popUpIndex == 9)
        {

            popUpIndex++;
        }
    }
    public void PutStamp()
    {
        if (popUpIndex == 10)
        {

            popUpIndex++;
        }
    }
}