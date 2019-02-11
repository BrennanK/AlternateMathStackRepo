using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Time = UnityEngine.Time;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SoundUpdater : MonoBehaviour
{
    public AudioMixer audioMix;
    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider FXSlider;

    public bool Muted;
    private bool menuPause;
        //private bool menuBack;
    /*
    private float mu1;
    private float mu2;
    private float mu3;
    */
    public AudioMixerSnapshot normal;
    public AudioMixerSnapshot pause;
    private void Start()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        BGMSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        FXSlider.value = PlayerPrefs.GetFloat("SoundVolume");

        audioMix.SetFloat("MasterVolume", MasterSlider.value);
        audioMix.SetFloat("MusicVolume", BGMSlider.value);
        audioMix.SetFloat("SoundVolume", FXSlider.value);
        /*
        mu1 = MasterSlider.value;
        mu2 = BGMSlider.value;
        mu3 = FXSlider.value;
        */
    }

    private void Update()
    {
        if (Muted == true)
        {
            audioMix.SetFloat("MasterVolume", MasterSlider.value = -50f);
            audioMix.SetFloat("MusicVolume", BGMSlider.value = -50f);
            audioMix.SetFloat("SoundVolume", FXSlider.value = -50f);
        }
        /*
        if (menuPause == true)
        {
            audioMix.SetFloat("MasterVolume", MasterSlider.value = -10f);
            audioMix.SetFloat("MusicVolume", BGMSlider.value = -10f);
            audioMix.SetFloat("SoundVolume", FXSlider.value = -10f);
            menuPause = false;
        }

        if (menuBack == true)
        {
            audioMix.SetFloat("MasterVolume", MasterSlider.value = 10f);
            audioMix.SetFloat("MusicVolume", BGMSlider.value = 10f);
            audioMix.SetFloat("SoundVolume", FXSlider.value = 10f);
            menuBack = false;
        }
        */
    }

    public void Pause(bool pp)
    {
        
        menuPause = pp;
        Lowpass(menuPause);
    }
    /*
    public void VolumeBack(bool pause)
    {
        
        menuBack = pause;
    }
    */
    private void Lowpass(bool pp)
    {
        if (pp)
        {
            pause.TransitionTo(0.05f);
        }
        else
        {
            normal.TransitionTo(0.05f);
        }
    }
    public void SetMaster()
    {
        audioMix.SetFloat("MasterVolume", MasterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
    }

    public void SetBGM()
    {
        audioMix.SetFloat("MusicVolume", BGMSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", BGMSlider.value);
    }

    public void SetFX()
    {
        audioMix.SetFloat("SoundVolume", FXSlider.value);
        PlayerPrefs.SetFloat("SoundVolume", FXSlider.value);
    }

    public void MuteToggle()
    {
        if (Muted == false)
        {
            Muted = true;
        }
        else
        {
            Muted = false;
        }
    }
}