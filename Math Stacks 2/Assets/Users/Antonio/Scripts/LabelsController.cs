using UnityEngine;
using UnityEngine.SceneManagement;

public class LabelsController : MonoBehaviour
{
    public static LabelsController LCInstance;
    public Tape _tape;
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
    private TutorialK TK;
    private Scissors Sci;
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
        _tape = FindObjectOfType<Tape>().GetComponent<Tape>();
        stopAll = false;
        Sci = FindObjectOfType<Scissors>().GetComponent<Scissors>();
    }

    private void OnMouseDown()
    {
        if (_tape.isTapeOn != true && enabled)
        {
            distance = Camera.main.WorldToScreenPoint(transform.position);
            positionX = Input.mousePosition.x - distance.x;
            positionY = Input.mousePosition.y - distance.y;
        }
    }

    private void OnMouseDrag()
    {
        if (_tape.isTapeOn != true && enabled)
        {
            Raycasts();
            var CurrentPosition =
                new Vector3(Input.mousePosition.x - positionX, Input.mousePosition.y - positionY, distance.z);
            var WorldPosition = Camera.main.ScreenToWorldPoint(CurrentPosition);
            transform.position = WorldPosition;
            isLabelMoving = true;
            Sci.disableKinematic = true;
        }
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

                    if (hit.collider.GetComponent<NumberGen>().hasStamp == true)
                    {
                        oldLabel = hit.collider.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
                        Destroy(oldLabel);
                        hit.collider.GetComponent<NumberGen>().InvokeEvaluation();
                    }
                    GameObject[] temp = SceneManager.GetSceneByName("Test_Scene").GetRootGameObjects();
                    for (int i = 0; i < temp.Length; i++)
                    {

                        if (temp[i].name == "TutorialTwo")
                        {
                            TK = temp[i].GetComponent<TutorialK>();
                            TK.PutStamp();
                        }
                    }
                    hitObject = hit.collider.gameObject.transform.GetChild(0).GetChild(0).gameObject;
                    transform.position = hitObject.transform.position;
                    gameObject.transform.SetParent(hitObject.transform);
                    hit.collider.gameObject.GetComponent<NumberGen>().canEvaluate = true;
                    hit.collider.GetComponent<NumberGen>().hasStamp = true;
                    stopAll = true;
                    stmp.canMake = true;

                    GetComponent<LabelsController>().enabled = false;
                }
            }
        }

        Sci.disableKinematic = false;
        isLabelMoving = false;
    }

    private void Raycasts()
    {
        rayForward = new Ray(transform.GetComponent<Renderer>().bounds.center, Vector3.back);
        Debug.DrawRay(rayForward.origin, rayForward.direction * 1, Color.blue);
    }
}