using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBox : MonoBehaviour
{
    private Boxcount bcount;// Start is called before the first frame update
    void Start()
    {
        SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBox()
    {
        bcount = FindObjectOfType<Boxcount>().GetComponent<Boxcount>();
        bcount.specialboxs.Add(this.gameObject);
    }
}
