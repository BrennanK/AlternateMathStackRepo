// Author: Mehmet Holbert
// Description: Retrieves value from Gen to show on moving stamp
// Date: 2/1/2019
// Last Edited By: 
// Last Edited Date: 2/7/2019
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stamp : MonoBehaviour
{
    public string stampOpperator;
    public int stampNumber;
    public TextMeshPro stmptxt;

    void Awake()
    {
        stmptxt = stmptxt.GetComponent<TextMeshPro>();
    }

    public void StampValue(string _Op, int _Num)
    { Debug.Log(_Op);
        stampOpperator = _Op;
        Debug.Log(_Num);
        stampNumber = _Num;
        stmptxt.text = stampOpperator + stampNumber.ToString();
        
    }
}
