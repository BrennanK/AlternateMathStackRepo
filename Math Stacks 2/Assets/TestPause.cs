using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Time = UnityEngine.Time;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TestPause : MonoBehaviour
{
    public AudioMixerSnapshot normal;

    public AudioMixerSnapshot pause;

    //private Canvas canvas;
   // public GameObject Pausetest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           // Pausetest.SetActive(true);
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Lowpass();
    }

    void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            pause.TransitionTo(0.05f);
        }
        else
        {
            normal.TransitionTo(0.05f);
        }
    }

    public void setBack()
    {
       // Pausetest.SetActive(false);
    }
}
