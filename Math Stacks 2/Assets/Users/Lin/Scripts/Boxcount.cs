using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxcount : MonoBehaviour
{
    public List<GameObject> boxs;

    public List<GameObject> specialboxs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeletAll()
    {
        /*
        for (int i = 0; i < boxs.Count; i++)
        {
            Destroy(boxs[i]);
        }
        */
        //boxs = new List<GameObject>();
        boxs.Clear();
        specialboxs.Clear();
        Debug.Log("Function called");
    }

}
