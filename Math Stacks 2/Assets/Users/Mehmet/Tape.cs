﻿// Author: Mehmet Holbert
// Description: Controls Tape Functionality
// Date: 2/1/2019
// Last Edited By: 
// Last Edited Date: 2/7/2019
using UnityEngine;

public class Tape : MonoBehaviour
{
    protected const float minDistance = 1.5f;
    private Vector3 _currentPosition;
    private Vector3 _initialPosition;
    private LineRenderer _lineRenderer;
    private GameObject _tape;
    public GameObject Box1, Box2;
    public BoxController[] boxes;
    protected GameObject empty;
    private RaycastHit hit;
    public bool isTapeOn;
    public Material lineMat;
    protected Vector3 midPoint;
    private Ray rayForward;
    public GameObject tape;
    protected Tape tapeParent;
    private float tmpx1;
    private float tmpx2;
    private float tmpy1;
    private float tmpy2;

    public void EnableTapeMode()
    {
        isTapeOn = !isTapeOn;
    }

    public void Start()
    {
        tapeParent = FindObjectOfType<Tape>().GetComponent<Tape>();
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.material = lineMat;
        _lineRenderer.SetWidth(0.2f, 0.2f);
        _lineRenderer.enabled = false;
    }

    private void Press()
    {
        Raycasts();
        Debug.Log("On Press creating Ray");
        if (Physics.Raycast(rayForward, out hit))
        {
            Debug.Log("On Press Raycasting out to hit: " + hit.collider.name);
            Debug.DrawRay(rayForward.origin, rayForward.direction, Color.yellow);
            if (hit.collider.gameObject.GetComponent<NumberGen>())
            {
                Debug.Log("On Press hit a Box");
                if (Box1 == null)
                {
                    Debug.Log("adding Box1");
                    Box1 = hit.collider.gameObject;
                }
            }
        }
    }


    private void Release()
    {
        Raycasts();
        Debug.Log("On Release creating Ray");
        if (Physics.Raycast(rayForward, out hit))
        {
            Debug.Log("On Release Raycasting out to hit: " + hit.collider.name);
            if (hit.collider.gameObject.GetComponent<NumberGen>())
            {
                Debug.Log("On Release hit a Box");
                if (Box2 == null && Box1 != null && hit.collider.gameObject != Box1)
                {
                    Debug.Log("adding Box2");
                    Box2 = hit.collider.gameObject;
                    Math();
                }
            }
        }
    }

    private void Math()
    {
        tmpx1 = Box1.transform.position.x;
        tmpx2 = Box2.transform.position.x;
        tmpy1 = Box1.transform.position.y;
        tmpy2 = Box2.transform.position.y;

        midPoint = new Vector3((tmpx1 + tmpx2) / 2, (tmpy1 + tmpy2) / 2, Box1.transform.position.z);
    }

    private void Update()
    {
        if (enabled && isTapeOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Box1 = null;
                Debug.Log("On Press");
                Press();
                _initialPosition = GetCurrentMousePosition().GetValueOrDefault();
                _lineRenderer.SetPosition(0, _initialPosition);
                _lineRenderer.SetVertexCount(1);
                _lineRenderer.enabled = true;
            }
            else if (Input.GetMouseButton(0))
            {
                _currentPosition = GetCurrentMousePosition().GetValueOrDefault();
                _lineRenderer.SetVertexCount(2);
                _lineRenderer.SetPosition(1, _currentPosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Box2 = null;
                Debug.Log("On Release");
                Release();
                _lineRenderer.enabled = false;
                var releasePosition = GetCurrentMousePosition().GetValueOrDefault();
                var direction = releasePosition - _initialPosition;
            }

            else
            {
                _lineRenderer.enabled = false;
            }

            var Difx = Mathf.Abs(tmpx2 - tmpx1);
            var Dify = Mathf.Abs(tmpy2 - tmpy1);
            boxes = FindObjectsOfType<BoxController>();
            foreach (var box in boxes) box.GetComponent<BoxController>().enabled = false;
            if (Box1 != null && Box2 != null)
            {
                var Distance = (Box1.transform.position - Box2.transform.position).magnitude;
                if (Distance < minDistance)
                {
                    empty = new GameObject();
                    empty.transform.position = midPoint;
                    empty.AddComponent<MeshRenderer>();

                    if (Difx > 1 && Dify < 1)
                    {
                        empty.AddComponent<BoxCollider>();
                        empty.GetComponent<BoxCollider>().size = new Vector3(2.12f, 1, 1.4f);
                        _tape = Instantiate(tape, empty.transform.position, Quaternion.identity);
                    }
                    else if (Difx < 1 && Dify > 1)
                    {
                        empty.AddComponent<BoxCollider>();
                        empty.GetComponent<BoxCollider>().size = new Vector3(1, 2.12f, 1.4f);
                        Box1.transform.position = new Vector3(empty.transform.position.x, Box1.transform.position.y,
                            Box1.transform.position.z);
                        Box2.transform.position = new Vector3(empty.transform.position.x, Box2.transform.position.y,
                            Box2.transform.position.z);
                        _tape = Instantiate(tape, empty.transform.position, Quaternion.Euler(0, 0, 90));
                    }
                    else
                    {
                        Destroy(empty);
                        isTapeOn = false;
                        Box1 = null;
                        Box2 = null;
                        return;
                    }

                    empty.AddComponent<Rigidbody>();
                    empty.GetComponent<Rigidbody>().constraints =
                        RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                    empty.AddComponent<BoxController>();
                    empty.AddComponent<GroupedBox>();

                    _tape.transform.position = new Vector3(_tape.transform.position.x, _tape.transform.position.y,
                        _tape.transform.position.z + 1);
                    _tape.transform.parent = empty.transform;
                    Box1.transform.parent = empty.transform;
                    Box2.transform.parent = empty.transform;
                    Destroy(Box1.GetComponent<Rigidbody>());
                    Destroy(Box2.GetComponent<Rigidbody>());
                    Box1.GetComponent<BoxCollider>().isTrigger = true;
                    Box2.GetComponent<BoxCollider>().isTrigger = true;
                    Destroy(Box1.GetComponent<BoxController>());
                    Destroy(Box2.GetComponent<BoxController>());

                    Box1 = null;
                    Box2 = null;
                    foreach (var box in boxes) box.GetComponent<BoxController>().enabled = true;
                    isTapeOn = false;
                }
            }
        }
    }

    private Vector3? GetCurrentMousePosition()
    {
        var screenpoint = Input.mousePosition;
        screenpoint.z = -5;
        var ray = Camera.main.ScreenPointToRay(screenpoint);
        var plane = new Plane(Vector3.forward, Vector3.zero);

        float rayDistance;
        if (plane.Raycast(ray, out rayDistance)) return ray.GetPoint(rayDistance);

        return null;
    }

    private void Raycasts()
    {
        rayForward = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}