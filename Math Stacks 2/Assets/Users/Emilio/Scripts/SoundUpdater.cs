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
    [SerializeField] Slider[] BGMSlider;
    [SerializeField] Slider[] FXSlider;

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
    private float bgmVolume;
    private float fxVolume;
    private bool volumeT = true;
    private bool changing = false;
    private void Start()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        BGMSlider[0].value = PlayerPrefs.GetFloat("MusicVolume");
        FXSlider[0].value = PlayerPrefs.GetFloat("SoundVolume");
        
        
        BGMSlider[1].value = PlayerPrefs.GetFloat("MusicVolume");
        FXSlider[1].value = PlayerPrefs.GetFloat("SoundVolume");
        
        audioMix.SetFloat("MasterVolume", MasterSlider.value);
        audioMix.SetFloat("MusicVolume", BGMSlider[0].value);
        audioMix.SetFloat("SoundVolume", FXSlider[0].value);
        /*
        audioMix.SetFloat("MusicVolume", BGMSlider[1].value);
        audioMix.SetFloat("SoundVolume", FXSlider[1].value);
        */
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
            if (volumeT)
            {
                bgmVolume = BGMSlider[0].value;
                fxVolume = FXSlider[0].value;
                bgmVolume = BGMSlider[1].value;
                fxVolume = FXSlider[1].value;
                volumeT = false;
            }
            //audioMix.SetFloat("MasterVolume", MasterSlider.value = -50f);
            audioMix.SetFloat("MusicVolume", BGMSlider[0].value = -50f);
            audioMix.SetFloat("SoundVolume", FXSlider[0].value = -50f);
            /*
            audioMix.SetFloat("MusicVolume", BGMSlider[1].value = -50f);
            audioMix.SetFloat("SoundVolume", FXSlider[1].value = -50f);
            */
        }

        if (changing)
        {
            audioMix.SetFloat("MusicVolume", BGMSlider[0].value);
            audioMix.SetFloat("MusicVolume", BGMSlider[1].value);
            audioMix.SetFloat("SoundVolume", FXSlider[0].value);
            audioMix.SetFloat("SoundVolume", FXSlider[1].value);
            changing = false;
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
        audioMix.SetFloat("MusicVolume", BGMSlider[0].value);
        PlayerPrefs.SetFloat("MusicVolume", BGMSlider[0].value);
        BGMSlider[1].value = BGMSlider[0].value;
        changing = true;
    }
    public void SetBGMM()
    {
        
        audioMix.SetFloat("MusicVolume", BGMSlider[1].value);
        PlayerPrefs.SetFloat("MusicVolume", BGMSlider[1].value);
        BGMSlider[0].value = BGMSlider[1].value;
        changing = true;
    }

    public void SetFX()
    {
        audioMix.SetFloat("SoundVolume", FXSlider[0].value);
        PlayerPrefs.SetFloat("SoundVolume", FXSlider[0].value);
        FXSlider[1].value = BGMSlider[0].value;
        changing = true;

    }
    public void SetFXM()
    {
        
        audioMix.SetFloat("SoundVolume", FXSlider[1].value);
        PlayerPrefs.SetFloat("SoundVolume", FXSlider[1].value);
        FXSlider[0].value = BGMSlider[1].value;
        changing = true;
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
            audioMix.SetFloat("MusicVolume", BGMSlider[0].value = bgmVolume);
            audioMix.SetFloat("SoundVolume", FXSlider[0].value = fxVolume);
            audioMix.SetFloat("MusicVolume", BGMSlider[1].value = bgmVolume);
            audioMix.SetFloat("SoundVolume", FXSlider[1].value = fxVolume);
            volumeT = true;
        }
    }
}