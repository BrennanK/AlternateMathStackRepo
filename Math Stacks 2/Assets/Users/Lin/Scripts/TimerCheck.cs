using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    

    private TimerTest timeChange;
    
    void Start()
    {
        timeChange = FindObjectOfType<TimerTest>().GetComponent<TimerTest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void numberCorrect()
    {
      timeChange.AddTime(); 
    }

    public void numberWrong()
    {
       timeChange.DeleteTime();
    }
}
