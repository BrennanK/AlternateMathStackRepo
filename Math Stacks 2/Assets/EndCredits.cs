using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndCredits : MonoBehaviour
{
    public GameObject crditScene;

    private MenuManager MM;
    // Start is called before the first frame update
    void Start()
    {
        MM= FindObjectOfType<MenuManager>().GetComponent<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndPlay()
    {
        crditScene.SetActive(false);
        MM.Back();
    }
}
