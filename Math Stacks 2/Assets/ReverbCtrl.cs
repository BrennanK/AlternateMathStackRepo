using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ReverbCtrl : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioMixerSnapshot[] snapshots;
    public float[] weights;

    public void BlendSnapshot(int triggerNr)
    {
        switch (triggerNr)
        {
            case 1:
                weights[0] = 1.0f;
                weights[1] = 0.0f;
                mixer.TransitionToSnapshots(snapshots,weights,1.0f);
                break;
            case 2:
                weights[0] = 0.75f;
                weights[1] = 0.25f;
                mixer.TransitionToSnapshots(snapshots, weights, 1.0f);
                break;
            case 3:
                weights[0] = 0.0f;
                weights[1] = 1.0f;
                mixer.TransitionToSnapshots(snapshots, weights, 1.0f);
                break;

        }
    }

    public void caseone()
    {
        BlendSnapshot(1);
    }
    public void caseTwo()
    {
        BlendSnapshot(2);
    }
    public void caseThree()
    {
        BlendSnapshot(3);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
