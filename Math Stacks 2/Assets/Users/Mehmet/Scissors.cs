// Author: Mehmet Holbert
// Description: Controls Scissor Functionality
// Date: 2/1/2019
// Last Edited By: 
// Last Edited Date: 2/7/2019
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scissors : MonoBehaviour
{
    public NumberGen[] BoxChildren = new NumberGen[2];
    private BoxController[] boxes;
    public GameObject GrpBox;
    private RaycastHit hit;
    public bool isScissorsOn;
    private Ray rayForward;
    private TutorialK TK;
    public void EnableScissorMode()
    {
        GameObject[] temp = SceneManager.GetSceneByName("Test_Scene").GetRootGameObjects();
        for (int i = 0; i < temp.Length; i++)
        {
            
            if (temp[i].name == "TutorialTwo")
            {
                TK = temp[i].GetComponent<TutorialK>();
                TK.UseScissor();
            }
        }
        isScissorsOn = true;
    }

    private void Press()
    {
        if (enabled)
            if (isScissorsOn)
            {
                Raycasts();
                if (Physics.Raycast(rayForward, out hit))
                    if (hit.collider.gameObject.GetComponent<GroupedBox>())
                    {
                        Debug.Log("hit a Box");
                        GrpBox = hit.collider.gameObject;
                        Cut();
                    }
            }
    }

    private void Cut()
    {
        BoxChildren = GrpBox.GetComponentsInChildren<NumberGen>();
        GrpBox.GetComponent<BoxCollider>().isTrigger = true;
        foreach (var box in BoxChildren)
        {
            box.transform.parent = null;
           
            box.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            box.gameObject.AddComponent<Rigidbody>();
            box.gameObject.GetComponent<Rigidbody>().useGravity = true;
            box.gameObject.GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            box.gameObject.AddComponent<BoxController>();
        }

        Destroy(GrpBox);
        GrpBox = null;
        BoxChildren = null;
        isScissorsOn = false;
        TK.ScissorCut();
    }

    private void FixedUpdate()
    {
        if (isScissorsOn)
        {
            boxes = FindObjectsOfType<BoxController>();
            if (Input.GetButtonDown("Fire1"))
            {
                GrpBox = null;
                Press();
            }

            foreach (var box in boxes) box.GetComponent<BoxController>().enabled = false;
        }
        else
        {
            boxes = FindObjectsOfType<BoxController>();
            foreach (var box in boxes) box.GetComponent<BoxController>().enabled = true;
        }
    }

    private void Raycasts()
    {
        rayForward = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("Raycasting from mousePosition");
        Debug.DrawRay(rayForward.origin, rayForward.direction * 1, Color.blue);
    }
}