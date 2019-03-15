// Author: Antonio Perez
// Description: Controls the touch movement of the value boxes and turns on/off the functionallity of the value boxes when the 
// game is paused. 
// Date: 05/February/2019
// Last Edited By: Antonio Perez
// Last Edited Date: 05/February/2019

using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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
    Ray groupedRay;
    RaycastHit hit;
    RaycastHit groupedHit;

    Rigidbody rb;
    private Tape _tape;
    private MenuManager mng;
    private Camera cam;
    private Canvas canvas;

    public bool isBeingHeld;
    private TutorialK TK;
    private Vector3 lockPosition;
    public AudioSource pickAu;
    public AudioSource droupAu;
    private bool soundPlay = true;
    public bool isStop;
    private bool canParticle;
    private int particleCounter;
    private ParticleSystem dustCloud;

    private void Awake()
    {
        TK = FindObjectOfType<TutorialK>().GetComponent<TutorialK>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = SortingLayerName;
        meshRenderer.sortingOrder = SortingOrder;

        rayDown = new Ray(transform.GetComponent<Renderer>().bounds.center, Vector3.forward);
        Debug.DrawRay(rayDown.origin, rayDown.direction * 1, Color.blue);

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = false;
        canParticle = false;
        _tape = FindObjectOfType<Tape>().GetComponent<Tape>();
        mng = GameObject.Find("UI Screens").GetComponent<MenuManager>();

        canvas = GetComponentInChildren<Canvas>();

        if (this.gameObject.GetComponent<BlankID>() != null)
        {
            canvas.enabled = false;
        }

        GameObject pick = GameObject.Find("Pick");
        pickAu = pick.GetComponent<AudioSource>();

        GameObject drop = GameObject.Find("Drop");
        droupAu = drop.GetComponent<AudioSource>();

        dustCloud = Resources.Load<ParticleSystem>("DustCloud");
        particleCounter = 0;
    }

    private void FixedUpdate()
    {
        if (isStop)
        {
            rb.velocity = new Vector3(0,0,0);
        }

        else
        {
            if (!isBeingHeld)
            {
                rb.velocity += new Vector3(0f, -9.81f * Time.fixedDeltaTime, 0f);
            }

            if (rb.velocity.y >= -5f)
            {
                rb.velocity = new Vector3(0f, -5f, 0f);
            }
        }
    }

    private void Update()
    {
        if (gameObject.name == "New Game Object")
        {
            groupedRay = new Ray(transform.GetComponent<Renderer>().bounds.center, Vector3.down * 2.5f);
            Debug.DrawRay(groupedRay.origin, groupedRay.direction * 2, Color.blue);

            if (Physics.Raycast(groupedRay, out groupedHit, 2f))
            {
                if (groupedHit.transform.tag == "Ground" && particleCounter <= 0)
                {
                    Instantiate(dustCloud, groupedHit.point, transform.rotation);
                    particleCounter++;
                }
            }
        }
    }

    public void KinematicON()
    {
        rb.isKinematic = true;
    }
    private void OnMouseDown()
    {
        if (enabled && !mng.Paused && _tape.isTapeOn != true)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            SortingOrder = 2;

            distance = Camera.main.WorldToScreenPoint(transform.position);
            positionX = Input.mousePosition.x - distance.x;
            positionY = Input.mousePosition.y - distance.y;
            pickAu.Play();
        }
    }

    private void OnMouseDrag()
    {
        if (enabled && !mng.Paused && _tape.isTapeOn != true)
        {
            Vector3 CurrentPosition = new Vector3(Input.mousePosition.x - positionX, Input.mousePosition.y - positionY, distance.z);
            Vector3 WorldPosition = Camera.main.ScreenToWorldPoint(CurrentPosition);
            
            if (WorldPosition.x > -7 && WorldPosition.y > 0 && WorldPosition.x < 6 && WorldPosition.y < 7.5)
            {
                if (WorldPosition.x >-1.05 && WorldPosition.x <6 && WorldPosition.y > 0 & WorldPosition.y < 3)
                {
                    transform.position = lockPosition;
                    Debug.Log("DO not enter");
                }

                else
                {
                    transform.position = WorldPosition;
                    lockPosition = WorldPosition;
                    TK.BoxMove();
                }
            }

            else
            {
                transform.position = lockPosition;
            }
        }

        isBeingHeld = true;
    }

    private void OnMouseUp()
    {
        if (enabled && !mng.Paused && _tape.isTapeOn != true)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            SortingOrder = 0;
        }

        isBeingHeld = false;
        particleCounter--;
    }
    public void OnCollisionEnter(Collision other)
    {
        Vector3 position = this.transform.position;

        if (other.gameObject.tag == "Draggable")
        {
            isBeingHeld = true;
        }

        if (other.gameObject.tag != "Draggable")
        {
            if (gameObject.name != "New Game Object")
            {
                Instantiate(dustCloud.gameObject, transform.position - new Vector3(0, 0.7f, -1f), transform.rotation);
            }
        }

        if (soundPlay)
        {
            soundPlay = false;
            droupAu.Play();
            StartCoroutine("WaitTime", 0.5f);
        }
    }

    IEnumerator WaitTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        soundPlay = true;
    }
}