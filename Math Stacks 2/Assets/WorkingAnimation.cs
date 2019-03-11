using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public WorkAnimation WA;
    void Start()
    {
        WA = FindObjectOfType<WorkAnimation>().GetComponent<WorkAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeAM() {
        WA.ChangeAnimation();
    }

}
