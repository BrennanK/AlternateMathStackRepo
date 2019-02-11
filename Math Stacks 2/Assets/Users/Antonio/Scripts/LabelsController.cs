using UnityEngine;

public class LabelsController : MonoBehaviour
{
    public static LabelsController LCInstance;
    private StampGen stmp;
    private Vector3 distance;
    private RaycastHit hit;

    private GameObject hitObject;
    private GameObject oldLabel;
    private float positionX;
    private float positionY;
    public bool isLabelMoving;
    private Ray rayForward;

    private bool stopAll;
    
    void Awake()
    {
        if (LCInstance == null)
        {
            LCInstance = this;
        }
        else if(LCInstance != this)
        {
            LCInstance = this;
        }
    }

    private void Start()
    {
        stmp = GameObject.Find("UI Screens").GetComponent<StampGen>();
        stopAll = false;
    }

    private void OnMouseDown()
    {
        distance = Camera.main.WorldToScreenPoint(transform.position);
        positionX = Input.mousePosition.x - distance.x;
        positionY = Input.mousePosition.y - distance.y;
    }

    private void OnMouseDrag()
    {
        Raycasts();
        var CurrentPosition =
            new Vector3(Input.mousePosition.x - positionX, Input.mousePosition.y - positionY, distance.z);
        var WorldPosition = Camera.main.ScreenToWorldPoint(CurrentPosition);
        transform.position = WorldPosition;
        isLabelMoving = true;
    }

    private void OnMouseUp()
    {
        if (!stopAll)
        {
            if (Physics.Raycast(rayForward, out hit, 1))
            {
                if (hit.transform.tag == "Draggable")
                {
                    if (hit.collider.gameObject.GetComponent<BlankID>() != null)
                    {
                        hit.collider.gameObject.GetComponentInChildren<Canvas>().enabled = true;
                    }

                    if (stmp.gameobjectHere == true)
                    {
                        oldLabel = hit.collider.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
                        hit.collider.gameObject.GetComponent<BoxController>().startingValue = hit.collider.gameObject.GetComponent<BoxController>().oldValue;
                        Destroy(oldLabel);
                        stmp.gameobjectHere = false;
                    }

                    if (stmp.gameobjectHere == false)
                    {
                        hitObject = hit.collider.gameObject.transform.GetChild(0).GetChild(0).gameObject;
                        transform.position = hitObject.transform.position;
                        gameObject.transform.SetParent(hitObject.transform);


                        hit.collider.gameObject.GetComponent<BoxController>().canEvaluate = true;
                        stopAll = true;
                        isLabelMoving = false;
                        stmp.canMake = true;
                        stmp.gameobjectHere = true;
                    }
                }
            }
        }
    }

    private void Raycasts()
    {
        rayForward = new Ray(transform.GetComponent<Renderer>().bounds.center, Vector3.back);
        Debug.DrawRay(rayForward.origin, rayForward.direction * 1, Color.blue);
    }
}