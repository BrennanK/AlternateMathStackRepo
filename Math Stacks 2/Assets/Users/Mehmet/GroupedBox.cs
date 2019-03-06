// Author: Mehmet Holbert
// Description: Controls the Group Boxes colliders
// Date: 2/1/2019
// Last Edited By: 
// Last Edited Date: 2/7/2019
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupedBox : MonoBehaviour
{
    public NumberGen[] BoxChildren = new NumberGen[2];
    private Vector3 boxSize;
    void Start()
    {
        boxSize = GetComponent<BoxCollider>().size;
    
    }
    void FixedUpdate()
    {

        if (LabelsController.LCInstance != null)
        {
            BoxChildren = GetComponentsInChildren<NumberGen>();
            if (LabelsController.LCInstance.isLabelMoving)
            {
                Destroy(this.gameObject.GetComponent<BoxController>());
                Destroy(this.gameObject.GetComponent<Rigidbody>());
                Destroy(this.gameObject.GetComponent<BoxCollider>());
                if (GetComponent<BoxCollider>() == null)
                {
                    foreach (var box in BoxChildren)
                    {
                        if (box.GetComponent<BoxController>() == null)
                        {
                            box.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                            box.gameObject.AddComponent<Rigidbody>();
                            box.GetComponent<Rigidbody>().constraints =
                                RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

                            box.gameObject.AddComponent<BoxController>();
                            box.gameObject.GetComponent<BoxController>().isStop = true;
                            box.GetComponent<Rigidbody>().isKinematic = true;
                        }
                    }
                }

            }
            else
            {
                if (GetComponent<BoxCollider>() != null)
                {
                    foreach (var box in BoxChildren)
                    {
                        Destroy(box.gameObject.GetComponent<BoxController>());
                        Destroy(box.gameObject.GetComponent<Rigidbody>());
                 
                        box.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                        
                    }
                }
                else
                {
                    this.gameObject.AddComponent<BoxCollider>();
                    GetComponent<BoxCollider>().size = boxSize;
                    this.gameObject.AddComponent<Rigidbody>();
                   this.GetComponent<Rigidbody>().constraints =
                        RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                    this.gameObject.AddComponent<BoxController>();
                    foreach (var box in BoxChildren)
                    {
                        Destroy(box.gameObject.GetComponent<BoxController>());
                        Destroy(box.gameObject.GetComponent<Rigidbody>());
                        box.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    }
                }
            }
        }
    }
}
