using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeFlash : MonoBehaviour
{
    public Animator AM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        AM.SetBool("Flash", true);
    }
}
