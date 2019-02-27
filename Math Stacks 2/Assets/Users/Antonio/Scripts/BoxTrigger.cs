using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public List<Collider> colliders = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Draggable")
        {
            colliders.Add(other.gameObject.GetComponent<Collider>());

            if (colliders.Count > 1)
            {
                foreach (Collider C in colliders)
                {
                    if (C.name == "BlankBox")
                    {
                        Destroy(gameObject);
                    }

                    if (C.name == "K_3Box")
                    {
                        Destroy(gameObject);
                    }

                    if (C.name == "MainBox")
                    {
                        Debug.Log("Destroyed MainBox");
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Draggable")
        {
            colliders.Remove(other.gameObject.GetComponent<Collider>());
        }
    }
}
