using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject exhaust;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayExhoust()
    {
        exhaust.SetActive(true);
    }

    public void StopExhaust()
    {
        exhaust.SetActive(false);
    }
}
