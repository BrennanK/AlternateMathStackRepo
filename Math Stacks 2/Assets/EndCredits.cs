using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndCredits : MonoBehaviour
{
    public GameObject crditScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndPlay()
    {
        crditScene.SetActive(false);
        
    }
}
