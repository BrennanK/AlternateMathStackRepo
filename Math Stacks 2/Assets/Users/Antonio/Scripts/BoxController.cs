// Author: Antonio Perez
// Description: Controls the touch movement of the value boxes and turns on/off the functionallity of the value boxes when the 
// game is paused. 
// Date: 05/February/2019
// Last Edited By: Antonio Perez
// Last Edited Date: 05/February/2019
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class BoxController : MonoBehaviour
{
    Vector3 distance;
    float positionX;
    float positionY;
    float gravityModifier; 

    private string SortingLayerName = "Default";
    private int SortingOrder = 0;

    MeshRenderer meshRenderer;

    Ray rayDown;
    RaycastHit hit;

    Rigidbody rb;
    private Tape _tape;
    private MenuManager mng;
    private Camera cam;
    private Canvas canvas;

    public bool canEvaluate;
    public bool isBeingHeld;

   
    
    private void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = SortingLayerName;
        meshRenderer.sortingOrder = SortingOrder;

        //casts a ray from the center of the object
        rayDown = new Ray(transform.GetComponent<Renderer>().bounds.center, Vector3.forward);
        Debug.DrawRay(rayDown.origin, rayDown.direction * 1, Color.blue);

        rb = GetComponent<Rigidbody>();
        _tape = FindObjectOfType<Tape>().GetComponent<Tape>();
        mng = GameObject.Find("UI Screens").GetComponent<MenuManager>();

        canEvaluate = false;
   

        canvas = GetComponentInChildren<Canvas>();

        if (this.gameObject.GetComponent<BlankID>() != null)
        {
            canvas.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if(!isBeingHeld)
        rb.velocity += new Vector3(0f, -9.81f * Time.fixedDeltaTime, 0f);
    }

    private void Update()
    {
       // Reevaluate();
    }

    private void OnMouseDown()
    {
        if (enabled && !mng.Paused && _tape.isTapeOn != true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            SortingOrder = 2;

            distance = Camera.main.WorldToScreenPoint(transform.position);
            positionX = Input.mousePosition.x - distance.x;
            positionY = Input.mousePosition.y - distance.y;
        }

        Debug.Log("ray hit"+ rayDown);
    }

    private void OnMouseDrag()
    {
        if (enabled && !mng.Paused && _tape.isTapeOn != true)
        {
            //rb.useGravity = false;
            Vector3 CurrentPosition = new Vector3(Input.mousePosition.x - positionX, Input.mousePosition.y - positionY, distance.z);
            Vector3 WorldPosition = Camera.main.ScreenToWorldPoint(CurrentPosition);
            
            //Debug.Log("object position" + WorldPosition);
            if (WorldPosition.x > -7 && WorldPosition.y > 0.5 && WorldPosition.x < 7 && WorldPosition.y < 7.5)
            {
                transform.position = WorldPosition;
            }
        }

        isBeingHeld = true;
    }

    private void OnMouseUp()
    {
        if (enabled && !mng.Paused && _tape.isTapeOn != true)
        {
            rb.useGravity = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            SortingOrder = 0;

            //checks if the ray hits something at 1 distance
            if (Physics.Raycast(rayDown, out hit, 1))
            {
                if (hit.transform.tag == "Ground")
                {
                    rb.useGravity = false;
                }
            }
        }

        isBeingHeld = false;
    }

    //private void Reevaluate()
    //{
    //    if (canEvaluate)
    //    {
    //        Invoke("InvokeEvaluation", 0.1f);
    //        canEvaluate = false;
    //    }
    //}

   

    
}