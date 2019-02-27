using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        transform.Rotate(0, -180, 0);
    }
}
