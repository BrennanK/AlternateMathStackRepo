using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private GameObject ResetPoint;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<NumberGen>())
        {
            col.transform.position = ResetPoint.transform.position;
        }
    }
  
}
