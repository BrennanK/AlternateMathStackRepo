using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]//important!!
public class PlayerData 
{
    /*
    public int numberData;
    // Start is called before the first frame update
    public PlayerData(SafeUI sui)
    {
        numberData = sui.showNumber;
    }
    */
    public int tutorialI;
    public PlayerData(TutorialK Ttk)
    {
        tutorialI = Ttk.tutorialNum;
        Debug.Log("changed number "+ tutorialI);
    }

}
