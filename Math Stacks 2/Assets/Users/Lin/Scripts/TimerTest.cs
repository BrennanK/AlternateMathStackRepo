using System.Collections;
using System.Collections.Generic;
using ChrisTutorials.Persistent;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TimerTest : MonoBehaviour
{
    public float time = 180f;
    [SerializeField] private Text timerText;
    [SerializeField] private Slider slider;
    public AudioSource au;
    public AudioSource au2;
    public bool playMusic = false;
    public bool isplaying = false;

    //public AudioManager.AudioChannel channel1;

    public float[] weights;

    public AudioMixerSnapshot[] snapshot;

    public AudioMixer AM;

    private bool normal = false;
    //public AudioManager.AudioChannel channel2;
    private void Start()
    {
        slider.maxValue = 180f;
        slider.minValue = 0f;
        
    }

    private void Update()
    {
        timerText.text = "Time Left: " + Mathf.Round(time);
        time -= Time.deltaTime;
        slider.value = time;
       
    }

    private void FixedUpdate()
    {
         if (time <= 0f)
        {
            time = 0f;
        }
        if (time < 100f)
        {
            //Debug.Log("Start Play Music");
            playMusic = true;
            normal = false;
        }
        
        if (time > 100f)
        {
            playMusic = false;
            isplaying = false;
            au.Stop();
            

        }
        
        if ( !playMusic&& !normal)
        {
            normal = true;
            weights[0] = 1f;
            weights[1] = 0f;
            AM.TransitionToSnapshots(snapshot, weights, .2f);
            Debug.Log("Is still Running");
        }
        
        if (playMusic && !isplaying)
        {
            isplaying = true;
            au.Stop();
            au.Play();
            weights[0] = 0f;
            weights[1] = 1f;
            AM.TransitionToSnapshots(snapshot, weights, .2f);
            Debug.Log("Start Play Music");
        }
    }

    public void AddTime()
    {
        time += 10f;
        if (time >= 180f)
        {
            time = 180f;
        }
    }

    public void DeleteTime()
    {
        time -= 10f;
        if (time <= 0f)
        {
            time = 0f;
        }
    }
}
